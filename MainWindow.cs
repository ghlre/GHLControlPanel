using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Web;

namespace GHLCP
{
    public partial class MainWindow : Form
    {
        string platform = "";
        string version = "";
        string gamedir = "";

        WaitingForm waitingform = new WaitingForm();


        string[] defaultTracks = { "GHL1003", "GHL1004", "GHL1005", "GHL1006", "GHL1007", "GHL1008", "GHL1009", "GHL1010", "GHL1011", "GHL1012", "GHL1013", "GHL1014", "GHL1015", "GHL1016", "GHL1017", "GHL1018", "GHL1019", "GHL1020", "GHL1021", "GHL1022", "GHL1023", "GHL1024", "GHL1025", "GHL1026", "GHL1027", "GHL1028", "GHL1029", "GHL1030", "GHL1031", "GHL1032", "GHL1033", "GHL1034", "GHL1035", "GHL1036", "GHL1037", "GHL1038", "GHL1039", "GHL1040", "GHL1041", "GHL1042", "GHL1043", "GHL1044", "GHL1045", "TST1798", "GHTVFree" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PopulateInstalled()
        {
            installedListView.Items.Clear();
            foreach (string path in Directory.GetDirectories(gamedir + "\\Audio\\AudioTracks"))
            {
                if (!File.Exists(path + "\\trackconfig.xml"))
                {
                    return;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(path + "\\trackconfig.xml");
                XmlElement track = doc.DocumentElement;
                if (track.HasAttribute("intensity"))
                {
                    installedListView.Items.Add(new ListViewItem(new string[] { track.GetAttributeNode("id").InnerText, track.GetAttributeNode("trackname").InnerText, track.GetAttributeNode("artist").InnerText, track.GetAttributeNode("intensity").InnerText }));
                }
                else
                {
                    installedListView.Items.Add(new ListViewItem(new string[] { track.GetAttributeNode("id").InnerText, track.GetAttributeNode("trackname").InnerText, track.GetAttributeNode("artist").InnerText, "0" }));
                }
            }
            installedListView.Sort();
        }

        private void PopulateActive()
        {
            activeListView.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(gamedir + "\\Audio\\AudioTracks\\Setlists.xml");
            foreach (XmlElement child in doc.SelectNodes("Classes/Class"))
            {
                if (child.FirstChild.InnerText == "GHLive_Quickplay_AllTracks") {
                    foreach (XmlElement track in child.LastChild.ChildNodes)
                    {
                        if (!File.Exists(gamedir + "\\Audio\\AudioTracks\\" + track.InnerText + "\\trackconfig.xml"))
                        {
                            return;
                        }
                        XmlDocument document = new XmlDocument();
                        document.Load(gamedir + "\\Audio\\AudioTracks\\" + track.InnerText + "\\trackconfig.xml");
                        XmlElement trackconfig = document.DocumentElement;
                        if (trackconfig.HasAttribute("intensity"))
                        {
                            activeListView.Items.Add(new ListViewItem(new string[] { trackconfig.GetAttributeNode("id").InnerText, trackconfig.GetAttributeNode("trackname").InnerText, trackconfig.GetAttributeNode("artist").InnerText, trackconfig.GetAttributeNode("intensity").InnerText }));
                        }
                        else
                        {
                            activeListView.Items.Add(new ListViewItem(new string[] { trackconfig.GetAttributeNode("id").InnerText, trackconfig.GetAttributeNode("trackname").InnerText, trackconfig.GetAttributeNode("artist").InnerText, "0" }));
                        }
                    }
                }
            }
            activeListView.Sort();
        }

        private void ReadGameModifications()
        {
            XmlDocument configScore = new XmlDocument();
            configScore.Load(gamedir + "\\Configs\\ConfigScore.xml");
            XmlNode singleNoteScore = configScore.SelectNodes("Config/SingleNoteScore")[0];

            XmlDocument configStreak = new XmlDocument();
            configStreak.Load(gamedir + "\\Configs\\Config_Streak.xml");
            XmlNode maxMultiplier = configStreak.SelectNodes("Config/MaxMultiplier")[0];
            XmlNode streakPerMultiplierLevel = configStreak.SelectNodes("Config/StreakPerMultiplierLevel")[0];

            pointsPerNote.Value = Convert.ToInt32(singleNoteScore.InnerText);
            maximumMultiplier.Value = Convert.ToInt32(maxMultiplier.InnerText);
            notesPerMultiplier.Value = Convert.ToInt32(streakPerMultiplierLevel.InnerText);

            XmlDocument gameui = new XmlDocument();
            gameui.Load(gamedir + "\\UI\\GameUI.xml");
            XmlNodeList splashes = gameui.SelectNodes("/Classes/Class/Property/Value/Class/Property/Value/Class/Property/Value/Class[@Type='CGameUISplashScreen']");
            foreach (XmlNode splash in splashes)
            {
                if (splash.InnerText.Contains("ATVI_logo"))
                {
                    showActiSplash.Checked = true;
                }
                if (splash.InnerText.Contains("fsg_logo"))
                {
                    showFSGSplash.Checked = true;
                }
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please select the executable of your Guitar Hero Live installation.\nSupported Consoles: Wii U, Xbox 360, PlayStation 3 and iOS", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (GameFinderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<String> filenames = GameFinderDialog.FileName.Split('\\').ToList<String>();
                    string filename = filenames[filenames.Count - 1];
                    switch (filename)
                    {
                        case "GHLive.rpx":
                            platform = "Wii U";
                            filenames.Remove(filename);
                            filenames.Remove("code");
                            filenames.Add("content");
                            gamedir = String.Join("\\", filenames);
                            break;
                        case "EBOOT.BIN":
                            platform = "PlayStation 3";
                            filenames.Remove(filename);
                            gamedir = String.Join("\\", filenames);
                            break;
                        case "default.xex":
                            platform = "Xbox 360";
                            filenames.Remove(filename);
                            gamedir = String.Join("\\", filenames);
                            break;
                        case "GHLive":
                            platform = "iOS";
                            filenames.Remove(filename);
                            gamedir = String.Join("\\", filenames);
                            MessageBox.Show("iOS does not currently support importing GHLCP compatible songs.");
                            break;
                        default:
                            MessageBox.Show("That isn't a Guitar Hero Live executable!");
                            Application.Exit();
                            break;
                    }

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            } else
            {
                Application.Exit();
            }
            if (!File.Exists(gamedir+ "\\Audio\\AudioTracks\\Setlists.xml"))
            {
                MessageBox.Show("This copy of the game is not extracted correctly (or is not GHL at all!). Please extract the game and try again.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                return;
            }
            Text = $"Guitar Hero Live Control Panel ({platform})";
            PopulateInstalled();
            PopulateActive();
            ReadGameModifications();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                bool skipfirst = true;
                foreach (string arg in args)
                {
                    if (skipfirst)
                    {

                    } else
                    {
                        HandleImport(arg);
                    }
                    skipfirst = false;
                }
            }
        }

        private void installedRefresh_Click(object sender, EventArgs e)
        {
            PopulateInstalled();
        }

        private void buildXMLItem_Click(object sender, EventArgs e)
        {
            XmlDocument setlists = new XmlDocument();
            setlists.Load(gamedir + "\\Audio\\AudioTracks\\Setlists.xml");
            foreach (XmlElement child in setlists.SelectNodes("Classes/Class"))
            {
                if (child.FirstChild.InnerText == "GHLive_Quickplay_AllTracks")
                {
                    child.LastChild.RemoveAll();
                    XmlElement shit = (XmlElement)child.LastChild;
                    shit.SetAttribute("Name", "Tracks");
                    foreach (ListViewItem item in activeListView.Items)
                    {
                        XmlElement trackelem = setlists.CreateElement("Value");
                        trackelem.InnerText = item.SubItems[0].Text;
                        child.LastChild.AppendChild(trackelem);
                    }
                }
            }
            XmlDocument tracklisting = new XmlDocument();
            XmlElement elem = tracklisting.CreateElement("Tracks");
            elem.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            elem.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            foreach (ListViewItem item in installedListView.Items)
            {
                XmlElement trackelem = tracklisting.CreateElement("Track");
                trackelem.SetAttribute("id", item.SubItems[0].Text);
                elem.AppendChild(trackelem);
            }
            tracklisting.AppendChild(elem);
            File.Copy(gamedir + "\\Audio\\AudioTracks\\Setlists.xml", gamedir + "\\Audio\\AudioTracks\\Setlists.xml.bak", true);
            File.Copy(gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml", gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml.bak", true);
            File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\Setlists.xml", setlists.OuterXml);
            File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml", "<?xml version=\"1.0\" encoding=\"us-ascii\"?>"+tracklisting.OuterXml);
            MessageBox.Show("Built and saved Setlists/Tracklisting XML files!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void installedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (installedListView.SelectedIndices.Count == 0)
            {
                installedSetActive.Text = "Add To Quickplay";
                installedSetActive.Enabled = false;
                installedRemove.Enabled = false;
                installedEdit.Enabled = false;
            } else
            {
                installedSetActive.Enabled = true;
                installedRemove.Enabled = true;
                installedEdit.Enabled = true;
                if (defaultTracks.Contains(installedListView.SelectedItems[0].SubItems[0].Text))
                {
                    installedRemove.Enabled = false;
                } else if (!File.Exists(gamedir + "\\Audio\\AudioTracks\\"+ installedListView.SelectedItems[0].SubItems[0].Text+"\\manifest.txt"))
                {
                    installedRemove.Enabled = false;
                }
                installedSetActive.Text = "Add To Quickplay";
                foreach (ListViewItem item in activeListView.Items)
                {
                    if (item.SubItems[0].Text == installedListView.SelectedItems[0].SubItems[0].Text)
                    {
                        installedSetActive.Text = "Remove From Quickplay";
                    }
                }
            }
        }

        private void activeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeListView.SelectedIndices.Count == 0)
            {
                activeRemove.Enabled = false;
                activeEdit.Enabled = false;
            }
            else
            {
                activeRemove.Enabled = true;
                activeEdit.Enabled = true;
            }
        }

        private void activeRemove_Click(object sender, EventArgs e)
        {
            activeListView.SelectedItems[0].Remove();
        }

        private void installedSetActive_Click(object sender, EventArgs e)
        {
            bool shouldRemove = false;
            foreach (ListViewItem item in activeListView.Items)
            {
                if (item.SubItems[0].Text == installedListView.SelectedItems[0].SubItems[0].Text)
                {
                    shouldRemove = true;
                }
            }
            if (shouldRemove)
            {
                foreach (ListViewItem item in activeListView.Items)
                {
                    if (item.SubItems[0].Text == installedListView.SelectedItems[0].SubItems[0].Text)
                    {
                        item.Remove();
                        installedSetActive.Text = "Add To Quickplay";
                    }
                }
            } else
            {
                activeListView.Items.Add((ListViewItem)installedListView.SelectedItems[0].Clone());
                activeListView.Sort();
                installedSetActive.Text = "Remove From Quickplay";
            }
        }

        private void activeRefresh_Click(object sender, EventArgs e)
        {
            bool shouldRefresh = (MessageBox.Show("Are you sure you want to refresh? This will remove all pending changes you have made.", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            if (shouldRefresh)
            {
                PopulateActive();
            }
        }

        private void reloadGameMods_Click(object sender, EventArgs e)
        {
            ReadGameModifications();
        }

        private void GHTVMaxUpgrades_Click(object sender, EventArgs e)
        {
            pointsPerNote.Value = 72;
            maximumMultiplier.Value = 7;
            notesPerMultiplier.Value = 6;
        }

        private void defaultMods_Click(object sender, EventArgs e)
        {
            pointsPerNote.Value = 50;
            maximumMultiplier.Value = 4;
            notesPerMultiplier.Value = 10;
            showActiSplash.Checked = true;
            showFSGSplash.Checked = true;
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            new AboutGHLCP().ShowDialog(this);
        }

        private void importTracksItem_Click(object sender, EventArgs e)
        {
            if (platform == "iOS")
            {
                MessageBox.Show("iOS does not currently support importing songs through the Control Panel.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ImportSongDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string file in ImportSongDialog.FileNames)
                    {
                        HandleImport(file);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an unknown error that occurred while importing one or more of your songs.");
                }
            }
        }

        private void HandleImport(string filename)
        {
            string filenameNP = filename.Split('\\')[filename.Split('\\').Length - 1];
            decimal filesize = Math.Round((decimal)File.ReadAllText(filename).Length/1000000, 2);
            using (ZipArchive archive = ZipFile.OpenRead(filename))
            {
                var metadata = archive.GetEntry("meta.xml");
                if (metadata != null)
                {
                    using (var zipEntryStream = metadata.Open())
                    {
                        XmlDocument meta = new XmlDocument();
                        meta.Load(zipEntryStream);
                        bool compatible = false;
                        foreach (XmlNode platformnode in meta.SelectNodes("SongInfo/Platforms/Platform"))
                        {
                            if (platformnode.InnerText == platform)
                            {
                                compatible = true;
                            }
                        }
                        if (!compatible)
                        {
                            MessageBox.Show($"\"{filenameNP}\" is not compatible with your current platform. ({platform})", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DialogResult result = MessageBox.Show($"Are you sure you want to import \"{filenameNP}\"?\n" +
                            $"{meta.SelectNodes("SongInfo/Artist")[0].InnerText} - {meta.SelectNodes("SongInfo/Title")[0].InnerText}\n" +
                            $"Charted by: {meta.SelectNodes("SongInfo/Charter")[0].InnerText}\n" +
                            $"Filesize: {filesize} MB", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        string songID = meta.SelectNodes("SongInfo/ID")[0].InnerText;
                        if (result == DialogResult.Yes)
                        {
                            string manifestfile = "";
                            waitingform.Show(this);
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (!entry.FullName.EndsWith("/"))
                                {
                                    if (entry.FullName.StartsWith("Generic/"))
                                    {
                                        Console.WriteLine($"Extracting \"{entry.FullName}\" to \"{gamedir + "\\" + entry.FullName.Replace("Generic/", "")}\"");
                                        if (platform == "PlayStation 3")
                                        {
                                            manifestfile += entry.FullName.ToUpper().Replace("GENERIC/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.ToUpper().Replace("GENERIC/", ""));
                                        }
                                        else
                                        {
                                            manifestfile += entry.FullName.Replace("Generic/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.Replace("Generic/", ""));
                                        }
                                    }
                                    if (entry.FullName.StartsWith("Vorbis/") && platform != "iOS")
                                    {
                                        Console.WriteLine($"Extracting \"{entry.FullName}\" to \"{gamedir + "\\" + entry.FullName.Replace("Vorbis/", "")}\"");
                                        if (platform == "PlayStation 3")
                                        {
                                            manifestfile += entry.FullName.ToUpper().Replace("VORBIS/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.ToUpper().Replace("VORBIS/", ""));
                                        }
                                        else
                                        {
                                            manifestfile += entry.FullName.Replace("Vorbis/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.Replace("Vorbis/", ""));
                                        }
                                    }
                                    if (entry.FullName.StartsWith("MP4/") && platform != "Xbox 360")
                                    {
                                        Console.WriteLine($"Extracting \"{entry.FullName}\" to \"{gamedir + "\\" + entry.FullName.Replace("MP4/", "")}\"");
                                        if (platform == "PlayStation 3")
                                        {
                                            manifestfile += entry.FullName.ToUpper().Replace("MP4/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.ToUpper().Replace("MP4/", ""));
                                        }
                                        else
                                        {
                                            manifestfile += entry.FullName.Replace("MP4/", "") + "\n";
                                            entry.ExtractToFile(gamedir + "\\" + entry.FullName.Replace("MP4/", ""));
                                        }
                                    }
                                } else
                                {
                                    if (entry.FullName.StartsWith("Generic/"))
                                    {
                                        if (!Directory.Exists(gamedir + "\\" + entry.FullName.Replace("Generic/", "")))
                                        {
                                            Console.WriteLine($"Creating \"{entry.FullName}\" in \"{gamedir + "\\" + entry.FullName.Replace("Generic/", "")}\"");
                                            if (platform == "PlayStation 3")
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.ToUpper().Replace("GENERIC/", ""));
                                            }
                                            else
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.Replace("Generic/", ""));
                                            }
                                        }
                                    }
                                    if (entry.FullName.StartsWith("Vorbis/") && platform != "iOS")
                                    {
                                        if (!Directory.Exists(gamedir + "\\" + entry.FullName.Replace("Vorbis/", "")))
                                        {
                                            Console.WriteLine($"Creating \"{entry.FullName}\" in \"{gamedir + "\\" + entry.FullName.Replace("Vorbis/", "")}\"");
                                            if (platform == "PlayStation 3")
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.ToUpper().Replace("VORBIS/", ""));
                                            }
                                            else
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.Replace("Vorbis/", ""));
                                            }
                                        }
                                    }
                                    if (entry.FullName.StartsWith("MP4/") && platform != "Xbox 360" && platform != "iOS")
                                    {
                                        if (!Directory.Exists(gamedir + "\\" + entry.FullName.Replace("MP4/", "")))
                                        {
                                            Console.WriteLine($"Creating \"{entry.FullName}\" in \"{gamedir + "\\" + entry.FullName.Replace("MP4/", "")}\"");
                                            if (platform == "PlayStation 3")
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.ToUpper().Replace("MP4/", ""));
                                            }
                                            else
                                            {
                                                Directory.CreateDirectory(gamedir + "\\" + entry.FullName.Replace("MP4/", ""));
                                            }
                                        }
                                    }
                                    if (entry.FullName.StartsWith("webm/") && platform == "Xbox 360")
                                    {
                                        if (!Directory.Exists(gamedir + "\\" + entry.FullName.Replace("webm/", "")))
                                        {
                                            Console.WriteLine($"Creating \"{entry.FullName}\" in \"{gamedir + "\\" + entry.FullName.Replace("webm/", "")}\"");
                                            Directory.CreateDirectory(gamedir + "\\" + entry.FullName.Replace("webm/", ""));
                                        }
                                    }
                                }
                            }
                            File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + songID + "\\manifest.txt", manifestfile);
                            waitingform.Hide();
                            PopulateInstalled();
                        }
                    }
                } else
                {
                    MessageBox.Show($"\"{filenameNP}\" is not a valid GHLCP importable song.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void installedRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(gamedir + "\\Audio\\AudioTracks\\" + installedListView.SelectedItems[0].SubItems[0].Text + "\\manifest.txt"))
            {
                MessageBox.Show("This song doesn't have a manifest and therefore can not be safely removed.");
            }
            string[] filesToRemove = File.ReadAllLines(gamedir + "\\Audio\\AudioTracks\\" + installedListView.SelectedItems[0].SubItems[0].Text + "\\manifest.txt");
            foreach(string filepath in filesToRemove)
            {
                if (filepath.EndsWith("\\") || filepath == "")
                {

                } else
                {
                    File.Delete(gamedir + "\\" + filepath);
                }
            }
        }

        private void fuckYouActivision_Click(object sender, EventArgs e)
        {
            string[] funnyQuoteHaha = {
                "please bring back GHTV my kids are starving",
                "GHL, more like GHWhere is GHTV please bring it back",
                "Woah why can my Guitar hero live not work?",
                "how do I use Guitar Hero Live Control Panel to import songs?",
                "what's the big deal buster I need my guitar heroes!",
                "HUH GIVE ME GHTV RIGHT NOW",
                "TV mode where is? It gone guitar hero?",
                "Why can't I get DLC on Guitar Hero III?",
                "please allow access to the GHTV servers we know you didnt shut them down",
                "42 songs on Guitar Hero Live is simply no good. Do better, and bring GHTV back, you cons!",
                "Rock Band 4 is better.",
                "Why did you ruin Guitar Hero?",
                "Sorry for the inquiry, but why does Guitar Hero Live GHTV mode not work?",
                "wheres ghtv on guitar hero please i can't sleep i've been feeling ill i have the shakes,,,., just bring it back... please...."
            };
            Process.Start("https://twitter.com/intent/tweet?text=@ATVIAssist%20"+funnyQuoteHaha[new Random().Next(funnyQuoteHaha.Length)].Replace(" ", "%20"));
        }

        private void saveModsItem_Click(object sender, EventArgs e)
        {
            XmlDocument configScore = new XmlDocument();
            configScore.Load(gamedir + "\\Configs\\ConfigScore.xml");
            XmlNode singleNoteScore = configScore.SelectNodes("Config/SingleNoteScore")[0];

            XmlDocument configStreak = new XmlDocument();
            configStreak.Load(gamedir + "\\Configs\\Config_Streak.xml");
            XmlNode maxMultiplier = configStreak.SelectNodes("Config/MaxMultiplier")[0];
            XmlNode streakPerMultiplierLevel = configStreak.SelectNodes("Config/StreakPerMultiplierLevel")[0];

            singleNoteScore.InnerText = pointsPerNote.Value.ToString();
            maxMultiplier.InnerText = maximumMultiplier.Value.ToString();
            streakPerMultiplierLevel.InnerText = notesPerMultiplier.Value.ToString();
            
            File.Copy(gamedir + "\\Audio\\AudioTracks\\Setlists.xml", gamedir + "\\Audio\\AudioTracks\\Setlists.xml.bak", true);
            File.Copy(gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml", gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml.bak", true);
            File.WriteAllText(gamedir + "\\Configs\\ConfigScore.xml", configScore.OuterXml);
            File.WriteAllText(gamedir + "\\Configs\\Config_Streak.xml", configStreak.OuterXml);

            XmlDocument gameui = new XmlDocument();
            gameui.Load(gamedir + "\\UI\\GameUI.xml");
            XmlNodeList splashes = gameui.SelectNodes("/Classes/Class/Property/Value/Class/Property/Value/Class/Property/Value/Class[@Type='CGameUISplashScreen']");
            foreach (XmlNode splash in splashes)
            {
                if (splash.InnerText.Contains("ATVI_logo") && showActiSplash.Checked == false)
                {
                    XmlComment stuffToComment = gameui.CreateComment(splash.ParentNode.OuterXml);
                    splash.ParentNode.ParentNode.ReplaceChild(stuffToComment, splash.ParentNode);
                }
                if (splash.InnerText.Contains("fsg_logo") && showFSGSplash.Checked == false)
                {
                    XmlComment stuffToComment = gameui.CreateComment(splash.ParentNode.OuterXml);
                    splash.ParentNode.ParentNode.ReplaceChild(stuffToComment, splash.ParentNode);
                }
            }
            Console.WriteLine(gameui.OuterXml);
            XmlNodeList commented = gameui.SelectNodes("//comment()");
            foreach (XmlComment comment in commented)
            {
                if ((comment.Value.Contains("ATVI_logo")) & (showActiSplash.Checked))
                {
                    XmlReader nodeReader = XmlReader.Create(new StringReader(comment.Value));
                    XmlNode newNode = gameui.ReadNode(nodeReader);
                    comment.ParentNode.ReplaceChild(newNode, comment);
                }
                if ((comment.Value.Contains("fsg_logo")) & (showFSGSplash.Checked))
                {
                    XmlReader nodeReader = XmlReader.Create(new StringReader(comment.Value));
                    XmlNode newNode = gameui.ReadNode(nodeReader);
                    comment.ParentNode.ReplaceChild(newNode, comment);
                }
            }

            File.Copy(gamedir + "\\UI\\GameUI.xml", gamedir + "\\UI\\GameUI.xml.bak", true);
            File.WriteAllText(gamedir + "\\UI\\GameUI.xml", gameui.OuterXml);


            MessageBox.Show("Saved modified game files!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void installedEdit_Click(object sender, EventArgs e)
        {
            EditSong songDialog = new EditSong();
            songDialog.Populate(installedListView.SelectedItems[0].SubItems[0].Text, gamedir);
            songDialog.ShowDialog();
            PopulateInstalled();
            PopulateActive();
        }

        private void activeEdit_Click(object sender, EventArgs e)
        {
            EditSong songDialog = new EditSong();
            songDialog.Populate(activeListView.SelectedItems[0].SubItems[0].Text, gamedir);
            songDialog.ShowDialog();
            PopulateInstalled();
            PopulateActive();
        }
    }
}
