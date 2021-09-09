using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace GHLCP
{
    public class Gamedir : IEnumerable<Trackconfig>
    {
        private readonly string gamedir;
        private readonly Platform platform;

        private Dictionary<string, Trackconfig> installed;
        private List<string> active;

        private static readonly XmlSerializer trackconfigSerializer = new XmlSerializer(typeof(Trackconfig));

        public Gamedir(string gamedir, Platform platform)
        {
            this.gamedir = gamedir;
            this.platform = platform;

            ReadInstalled();
            ReadActive();
        }

        #region Properties

        public List<string> Active { get => active; set => active = value; }

        public Platform Platform { get => platform; }

        #endregion

        public string GetPath(string path) => gamedir + platform.GetRelPath(path);

        public void ReadInstalled()
        {
            installed = new Dictionary<string, Trackconfig>();
            string trackconfigPath = platform.GetRelPath("/trackconfig.xml");

            foreach (string dir in Directory.GetDirectories(GetPath("/Audio/AudioTracks")))
            {
                if (File.Exists(dir + trackconfigPath))
                {
                    using (StreamReader reader = new StreamReader(dir + trackconfigPath))
                    {
                        Trackconfig trackconfig = trackconfigSerializer.Deserialize(reader) as Trackconfig;
                        installed.Add(trackconfig.Id, trackconfig);
                    }
                }
            }
        }

        #region Active list functions

        public void ReadActive()
        {
            active = new List<string>();
            XmlDocument document = new XmlDocument();
            document.Load(GetPath("/Audio/AudioTracks/Setlists.xml"));

            foreach (XmlElement child in document.SelectNodes("Classes/Class"))
            {
                if (child.FirstChild.InnerText == "GHLive_Quickplay_AllTracks")
                {
                    foreach (XmlElement track in child.LastChild.ChildNodes)
                    {
                        active.Add(track.InnerText);
                    }
                }
            }
        }

        public void WriteActive()
        {
            WriteSetlists();
            WriteTracklisting();
        }

        public void WriteSetlists()
        {
            string setlistsPath = GetPath("/Audio/AudioTracks/Setlists.xml");
            XmlDocument setlists = new XmlDocument();
            setlists.Load(setlistsPath);

            foreach (XmlElement child in setlists.SelectNodes("Classes/Class"))
            {
                if (child.FirstChild.InnerText == "GHLive_Quickplay_AllTracks")
                {
                    child.LastChild.RemoveAll();
                    XmlElement quickplay = (XmlElement)child.LastChild;
                    quickplay.SetAttribute("Name", "Tracks");

                    foreach (string id in active)
                    {
                        XmlElement trackelem = setlists.CreateElement("Value");
                        trackelem.InnerText = id;
                        child.LastChild.AppendChild(trackelem);
                    }
                }
            }

            Backup(setlistsPath);
            File.WriteAllText(setlistsPath, setlists.OuterXml);
        }

        public void WriteTracklisting()
        {
            string tracklistingPath = GetPath("/Audio/AudioTracks/Tracklisting.xml");
            XmlDocument tracklisting = new XmlDocument();
            XmlElement elem = tracklisting.CreateElement("Tracks");

            elem.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            elem.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");

            foreach (string id in active)
            {
                XmlElement trackelem = tracklisting.CreateElement("Track");
                trackelem.SetAttribute("id", id);
                elem.AppendChild(trackelem);
            }

            tracklisting.AppendChild(elem);

            Backup(tracklistingPath);
            File.WriteAllText(tracklistingPath, "<?xml version=\"1.0\" encoding=\"us-ascii\"?>" + tracklisting.OuterXml);
        }

        #endregion

        #region Songlist/CSV functions

        public void ImportSonglistCSV(string filename)
        {
            active = new List<string>();

            foreach (string track in File.ReadAllLines(filename).Skip(1))
            {
                active.Add(track.Split(',')[0]);
            }
        }

        public string ExportSonglistCSV()
        {
            string songlist = "Id,Artist,Title,Intensity";

            foreach (string id in active)
            {
                Trackconfig trackconfig = installed[id];

                songlist += "\n";
                songlist += trackconfig.Id + "," + trackconfig.Artist + "," + trackconfig.Trackname + "," + trackconfig.Intensity;
            }

            return songlist;
        }

        public void ExportSonglistCSV(string filename)
        {
            File.WriteAllText(filename, ExportSonglistCSV());
        }

        public void RandomizeSonglist() => RandomizeSonglist(50);

        public void RandomizeSonglist(int max)
        {
            List<string> pool = installed.Keys.ToList();
            Random random = new Random();
            int i;

            active = new List<string>();

            while (active.Count < max && pool.Count > 0)
            {
                i = random.Next(pool.Count);
                active.Add(pool[i]);
                pool.RemoveAt(i);
            }
        }

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<Trackconfig> GetEnumerator()
        {
            return installed.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Trackconfig this[string id] { get => installed.ContainsKey(id) ? installed[id] : null; set => installed[id] = value; }

        #endregion

        #region Track import

        public delegate void ImportProgressChangedEventHandler(object sender, ImportProgressChangedEventArgs e);

        public event ImportProgressChangedEventHandler ImportProgressChanged;

        protected void RaiseImportProgressChanged(string message)
        {
            ImportProgressChanged?.Invoke(this, new ImportProgressChangedEventArgs(message));
        }

        public virtual void HandleImport(string filename)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filename))
            {
                string id = archive.Entries[0].FullName.Split('/')[0];
                string manifestFile = GetPath("/Audio/AudioTracks/" + id + "/manifest.txt");
                HashSet<string> manifest = File.Exists(manifestFile) ? new HashSet<string>(File.ReadAllLines(manifestFile)) : new HashSet<string>();

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    List<string> pathElements = entry.FullName.Split('/').ToList();
                    if (pathElements.Count >= 4)
                    {
                        string extractFor = pathElements[1].ToLower();
                        pathElements.RemoveRange(0, 2);
                        string path = platform.GetRelPath(String.Join("/", pathElements));

                        if (platform.Extracts(extractFor))
                        {
                            if (!entry.FullName.EndsWith("/"))
                            {
                                manifest.Add(path);
                                pathElements.RemoveAt(pathElements.Count - 1);
                                string folderPath = platform.GetRelPath(String.Join("/", pathElements));

                                if (!Directory.Exists(GetPath("/" + folderPath)))
                                {
                                    RaiseImportProgressChanged($"Creating \"{entry.FullName}\" in \"{GetPath("/" + folderPath)}\"");
                                    Directory.CreateDirectory(GetPath("/" + folderPath));
                                }
                                RaiseImportProgressChanged($"Extracting \"{entry.FullName}\" to \"{GetPath("/" + path)}\"");
                                entry.ExtractToFile(GetPath("/" + path), true);
                            }
                        }
                    }
                }

                File.WriteAllLines(manifestFile, manifest.ToArray());

                if (!File.Exists(GetPath("/Audio/AudioTracks/" + id + "/trackconfig.xml")))
                    throw new InvalidOperationException("Trackconfig not found. Please import the track data before the video");

                Trackconfig trackconfig = ReadTrackconfig(id);

                installed[id] = trackconfig;

                bool trackconfigChanged = false;

                if (Properties.Settings.Default.importVideo && manifest.Where(file => file.ToLower().EndsWith("video.xml")).Count() > 0 && !trackconfig.Video.HasVideo)
                {
                    trackconfig.Video.HasVideo = true;
                    trackconfigChanged = true;
                }

                if (Properties.Settings.Default.importParent)
                {
                    if (!trackconfig.Stagefright.Enabled)
                    {
                        SetParentSetlist(trackconfig, true);
                        trackconfigChanged = true;
                    } else
                    {
                        // Only move video files as they may have been imported after the trackconfig which already has parent setlist enabled
                        string parentSetlist = trackconfig.Stagefright.ParentSetlist;
                        string source = GetVideoRelPath(parentSetlist, false);
                        string dest = GetVideoRelPath(parentSetlist, true);

                        if (File.Exists(GetPath("/" + source + "video.xml")))
                        {
                            MoveVideo(trackconfig, source, dest);
                        }
                    }
                }

                if (trackconfigChanged)
                    WriteTrackconfig(trackconfig);
            }
        }

        #endregion

        #region Trackconfig functions

        public Trackconfig ReadTrackconfig(string id)
        {
            using (StreamReader reader = new StreamReader(GetPath("/Audio/AudioTracks/" + id + "/trackconfig.xml")))
            {
                return trackconfigSerializer.Deserialize(reader) as Trackconfig;
            }
        }

        public void WriteTrackconfig(Trackconfig trackconfig)
        {
            if (!File.Exists(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/trackconfig.xml.bak")))
            {
                Backup(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/trackconfig.xml"));
            }

            using (StreamWriter writer = new StreamWriter(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/trackconfig.xml")))
            {
                trackconfigSerializer.Serialize(writer, trackconfig);
            }
        }

        public void RemoveTrack(Trackconfig trackconfig)
        {
            string[] manifest = File.ReadAllLines(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt"));
            foreach (string filepath in manifest)
            {
                if (filepath.EndsWith("/") || filepath == "")
                {

                } else
                {
                    try
                    {
                        File.Delete(GetPath("/" + filepath));
                    }
                    catch (Exception) { }
                }
            }

            installed.Remove(trackconfig.Id);
            active.Remove(trackconfig.Id);
            File.Delete(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt"));
        }

        #endregion

        #region Stagefright functions

        public void SetParentSetlist(Trackconfig trackconfig, bool enable) => SetParentSetlist(trackconfig, enable, trackconfig.Stagefright.ParentSetlist);

        public void SetParentSetlist(Trackconfig trackconfig, bool enable, string parentSetlist)
        {
            TrackconfigStagefright stagefright = trackconfig.Stagefright;

            // Video files
            string source = GetVideoRelPath(stagefright.ParentSetlist, stagefright.Enabled);
            string dest = GetVideoRelPath(parentSetlist, enable);

            if (source != dest && File.Exists(GetPath("/" + source + "video.xml")))
            {
                MoveVideo(trackconfig, source, dest);
            }

            stagefright.Enabled = enable;
            stagefright.ParentSetlist = parentSetlist;
        }

        private string GetVideoRelPath(string parentSetlist, bool enabled) => platform.GetRelPath(enabled ? "setlists/" + parentSetlist + "/video/positive/" : "Video/" + parentSetlist + "/positive/");

        private void MoveVideo(Trackconfig trackconfig, string source, string dest)
        {
            HashSet<string> manifest = new HashSet<string>(File.ReadAllLines(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt")));

            if (!Directory.Exists(GetPath("/" + dest)))
            {
                Directory.CreateDirectory(GetPath("/" + dest));
            }

            foreach (string file in Directory.GetFiles(GetPath("/" + source)))
            {
                manifest.Remove(source + Path.GetFileName(file));

                if (File.Exists(GetPath("/" + dest + Path.GetFileName(file))))
                {
                    Backup(GetPath("/" + dest + Path.GetFileName(file)));
                    File.Delete(GetPath("/" + dest + Path.GetFileName(file)));
                }

                File.Move(file, GetPath("/" + dest + Path.GetFileName(file)));
                manifest.Add(dest + Path.GetFileName(file));
            }

            File.WriteAllLines(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt"), manifest.ToArray());
        }

        #endregion

        public void Backup(string path)
        {
            File.Copy(path, path + platform.GetRelPath(".bak"), true);
        }

        public override string ToString() => gamedir;
    }

    public class ImportProgressChangedEventArgs : EventArgs
    {
        private readonly string message;

        public ImportProgressChangedEventArgs(string message)
        {
            this.message = message;
        }

        public string Message { get => message; }
    }
}
