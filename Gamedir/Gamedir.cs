using GHLCP.Diagnostics;
using GHLCP.FileManager;
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
        private readonly IFileManager fileManager;

        private Dictionary<string, Trackconfig> installed;
        private List<string> active;

        private static readonly XmlSerializer trackconfigSerializer = new XmlSerializer(typeof(Trackconfig));

        public Gamedir(string gamedir, Platform platform, IFileManager fileManager)
        {
            this.gamedir = gamedir;
            this.platform = platform;
            this.fileManager = fileManager;

            ReadInstalled();
            ReadActive();
        }

        public Gamedir(string gamedir, Platform platform) 
            : this(gamedir, platform, new LocalFileManager())
        {
        }

        #region Properties

        public List<string> Active { get => active; set => active = value; }

        public Platform Platform { get => platform; }

        public IFileManager FileManager { get => fileManager; }

        #endregion

        public string GetPath(string path)
        {
            return string.Concat(gamedir, platform.GetRelPath(path));
        }

        public void ReadInstalled()
        {
            installed = new Dictionary<string, Trackconfig>();
            string trackconfigFilename = platform.GetRelPath("/trackconfig.xml");
            string trackconfigPath;

            foreach (string dir in fileManager.GetDirectories(GetPath("/Audio/AudioTracks")))
            {
                trackconfigPath = string.Concat(dir, trackconfigFilename);
                if (fileManager.FileExists(trackconfigPath))
                {
                    using (Stream stream = fileManager.OpenRead(trackconfigPath))
                    {
                        Trackconfig trackconfig = trackconfigSerializer.Deserialize(stream) as Trackconfig;
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
            using (Stream stream = fileManager.OpenRead(GetPath("/Audio/AudioTracks/Setlists.xml")))
            {
                document.Load(stream);
            }

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
            using (Stream stream = fileManager.OpenRead(setlistsPath))
            {
                setlists.Load(stream);
            }

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
            using (Stream stream = fileManager.OpenWrite(setlistsPath))
            {
                setlists.Save(stream);
            }
        }

        public void WriteTracklisting()
        {
            string tracklistingPath = GetPath("/Audio/AudioTracks/Tracklisting.xml");
            XmlDocument tracklisting = new XmlDocument();
            XmlDeclaration declaration = tracklisting.CreateXmlDeclaration("1.0", "us-ascii", null);
            tracklisting.AppendChild(declaration);

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
            using (Stream stream = fileManager.OpenWrite(tracklistingPath))
            {
                tracklisting.Save(stream);
            }
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
                if (installed.Keys.Contains(id))
                {
                    Trackconfig trackconfig = installed[id];

                    songlist = string.Concat(songlist, "\n", 
                        string.Join(",", trackconfig.Id, trackconfig.Artist, trackconfig.Trackname, trackconfig.Intensity));
                }
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
                HashSet<string> manifest = fileManager.FileExists(manifestFile) ? new HashSet<string>(fileManager.ReadAllLines(manifestFile)) : new HashSet<string>();

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    List<string> pathElements = entry.FullName.Split('/').ToList();
                    if (pathElements.Count >= 4)
                    {
                        string extractFor = pathElements[1].ToLower();
                        pathElements.RemoveRange(0, 2);
                        string path = platform.GetRelPath(string.Join("/", pathElements));

                        if (platform.Extracts(extractFor))
                        {
                            if (!entry.FullName.EndsWith("/"))
                            {
                                manifest.Add(path);
                                pathElements.RemoveAt(pathElements.Count - 1);
                                string folderPath = platform.GetRelPath(string.Join("/", pathElements));

                                if (!fileManager.DirectoryExists(GetPath(string.Concat("/", folderPath))))
                                {
                                    RaiseImportProgressChanged($"Creating \"{entry.FullName}\" in \"{GetPath(string.Concat("/", folderPath))}\"");
                                    fileManager.CreateDirectory(GetPath(string.Concat("/", folderPath)));
                                }
                                RaiseImportProgressChanged($"Extracting \"{entry.FullName}\" to \"{GetPath(string.Concat("/", path))}\"");
                                using (Stream zipStream = entry.Open())
                                {
                                    using (Stream stream = fileManager.OpenWrite(GetPath(string.Concat("/", path))))
                                    {
                                        zipStream.CopyTo(stream);
                                    }
                                }
                            }
                        }
                    }
                }

                fileManager.WriteAllLines(manifestFile, manifest);

                if (!fileManager.FileExists(GetPath("/Audio/AudioTracks/" + id + "/trackconfig.xml")))
                    throw new InvalidOperationException("Trackconfig not found. Please import the track data before the video");

                Trackconfig trackconfig = ReadTrackconfig(id);

                installed[id] = trackconfig;

                bool trackconfigChanged = false;

                if (Properties.Settings.Default.importVideo &&
                    manifest.Any(file => file.EndsWith("video.xml", StringComparison.OrdinalIgnoreCase)) &&
                    !trackconfig.Video.HasVideo)
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

                        if (fileManager.FileExists(GetPath("/" + source + "video.xml")))
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
            using (Stream stream = fileManager.OpenRead(GetPath("/Audio/AudioTracks/" + id + "/trackconfig.xml")))
            {
                return trackconfigSerializer.Deserialize(stream) as Trackconfig;
            }
        }

        public void WriteTrackconfig(Trackconfig trackconfig)
        {
            string trackconfigPath = GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/trackconfig.xml");
            if (!fileManager.FileExists(string.Concat(trackconfigPath, platform.GetRelPath(".bak"))))
            {
                Backup(trackconfigPath);
            }

            using (Stream stream = fileManager.OpenWrite(trackconfigPath))
            {
                trackconfigSerializer.Serialize(stream, trackconfig);
            }
        }

        public void RemoveTrack(Trackconfig trackconfig)
        {
            string manifestPath = GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt");
            IEnumerable<string> manifest = fileManager.ReadAllLines(manifestPath);
            
            foreach (string filepath in manifest)
            {
                if (filepath.EndsWith("/") || filepath == "")
                {

                } else
                {
                    try
                    {
                        fileManager.Delete(GetPath(string.Concat("/", filepath)));
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Warning(ex.Message);
                    }
                }
            }

            installed.Remove(trackconfig.Id);
            active.Remove(trackconfig.Id);
            fileManager.Delete(manifestPath);
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

            if (source != dest && fileManager.FileExists(GetPath("/" + source + "video.xml")))
            {
                if (!fileManager.DirectoryExists(GetPath("/" + dest)))
                {
                    fileManager.CreateDirectory(GetPath("/" + dest));
                }

                MoveVideo(trackconfig, source, dest);
            }

            stagefright.Enabled = enable;
            stagefright.ParentSetlist = parentSetlist;
        }

        private string GetVideoRelPath(string parentSetlist, bool enabled)
        {
            return platform.GetRelPath(enabled ? "setlists/" + parentSetlist + "/video/positive/" : "Video/" + parentSetlist + "/positive/");
        }

        private void MoveVideo(Trackconfig trackconfig, string source, string dest)
        {
            HashSet<string> manifest = new HashSet<string>(fileManager.ReadAllLines(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt")));
            
            if (!fileManager.DirectoryExists(GetPath("/" + dest)))
            {
                fileManager.CreateDirectory(GetPath("/" + dest));
            }

            foreach (string file in fileManager.GetFiles(GetPath("/" + source)))
            {
                manifest.Remove(source + Path.GetFileName(file));

                if (fileManager.FileExists(GetPath("/" + dest + Path.GetFileName(file))))
                {
                    Backup(GetPath("/" + dest + Path.GetFileName(file)));
                    fileManager.Delete(GetPath("/" + dest + Path.GetFileName(file)));
                }

                fileManager.Move(file, GetPath("/" + dest + Path.GetFileName(file)));
                manifest.Add(dest + Path.GetFileName(file));
            }

            fileManager.WriteAllLines(GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt"), manifest);
        }

        #endregion

        public void Backup(string path)
        {
            fileManager.Copy(path, string.Concat(path, platform.GetRelPath(".bak")));
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
