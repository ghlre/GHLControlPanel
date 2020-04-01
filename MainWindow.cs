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
using System.Collections;

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
                    continue;
                }
                XmlDocument doc = new XmlDocument();
                StreamReader file = new StreamReader(path + "\\trackconfig.xml", true);
                doc.Load(file.BaseStream);
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
            installedListView.Sorting = SortOrder.Ascending;
            installedListView.ListViewItemSorter = null;
            installedListView.ColumnClick += ListView_ColumnClick;
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
            activeListView.Sorting = SortOrder.Ascending;
            activeListView.ListViewItemSorter = null;
            activeListView.ColumnClick += ListView_ColumnClick;
            trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
        }

        private void ListView_ColumnClick(object o, ColumnClickEventArgs e)
        {
            if (((ListViewItemComparer)((ListView)o).ListViewItemSorter) != null && ((ListViewItemComparer)((ListView)o).ListViewItemSorter).col == e.Column)
            {
                switch(((ListView)o).Sorting)
                {
                    case SortOrder.Ascending:
                        ((ListViewItemComparer)((ListView)o).ListViewItemSorter).descending = true;
                        ((ListView)o).Sorting = SortOrder.Descending;
                        break;
                    default:
                        ((ListViewItemComparer)((ListView)o).ListViewItemSorter).descending = false;
                        ((ListView)o).Sorting = SortOrder.Ascending;
                        break;
                }
                ((ListView)o).Sort();
            } else
            {
                ((ListView)o).Sorting = SortOrder.Ascending;
                ((ListView)o).ListViewItemSorter = new ListViewItemComparer(e.Column);
            }
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
            XmlNode streakValueExpertTen = configStreak.SelectNodes("Config/StreakValueExpert10")[0];

            pointsPerNote.Value = Convert.ToInt32(singleNoteScore.InnerText);
            maximumMultiplier.Value = Convert.ToInt32(maxMultiplier.InnerText);
            notesPerMultiplier.Value = Convert.ToInt32(streakPerMultiplierLevel.InnerText);
            noteStreakFix.Checked = (streakValueExpertTen.InnerText == "999999");

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
            MessageBox.Show("Please select the executable of your Guitar Hero Live installation.\nSupported Consoles: Wii U, Xbox 360, PlayStation 3. iOS support is experimental!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GameFinderDialog.FileName = Properties.Settings.Default.pastFile;
            if (GameFinderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<String> filenames = GameFinderDialog.FileName.Split('\\').ToList<String>();
                    string filename = filenames[filenames.Count - 1];
                    Properties.Settings.Default.pastFile = String.Join("\\", filenames);
                    Properties.Settings.Default.Save();
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
                            Properties.Settings.Default.initialDirectory = String.Join("\\", filenames);
                            gamedir = String.Join("\\", filenames);
                            break;
                        case "default.xex":
                            platform = "Xbox 360";
                            filenames.Remove(filename);
                            Properties.Settings.Default.initialDirectory = String.Join("\\", filenames);
                            gamedir = String.Join("\\", filenames);
                            break;
                        case "GHLive":
                            platform = "iOS";
                            filenames.Remove(filename);
                            Properties.Settings.Default.initialDirectory = String.Join("\\", filenames);
                            gamedir = String.Join("\\", filenames);
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
            if (File.Exists(gamedir + "\\FAR\\DiscOnly\\GameBoot.far"))
            {
                MessageBox.Show("\"gameboot.far\" exists in your GHL install directory. GHLCP will now remove this to enable custom tracks to appear in the quickplay menu.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(gamedir + "\\FAR\\DiscOnly\\GameBoot.far");
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

            // hack to bring window to front.
            this.TopMost = true;
            this.TopMost = false;
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
            foreach (ListViewItem item in activeListView.Items)
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
                if (installedListView.SelectedIndices.Count == 1)
                {
                    installedRemove.Enabled = true;
                    installedEdit.Enabled = true;
                } else
                {
                    installedRemove.Enabled = false;
                    installedEdit.Enabled = false;
                }
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
                    foreach (ListViewItem selecteditem in installedListView.SelectedItems)
                    {
                        if (item.SubItems[0].Text == selecteditem.SubItems[0].Text)
                        {
                            if (installedListView.SelectedIndices.Count > 1)
                            {
                                installedSetActive.Enabled = false;
                            } else
                            {
                                installedSetActive.Text = "Remove From Quickplay";
                            }
                        }
                    }
                }
            }
        }

        private void activeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (activeListView.SelectedIndices.Count) 
            {
                case 0:
                    activeRemove.Enabled = false;
                    activeEdit.Enabled = false; 
                    removeFromQuickplayToolStripMenuItem.Enabled = false;
                    break;

                case 1:
                    activeRemove.Enabled = true; 
                    activeEdit.Enabled = true;
                    removeFromQuickplayToolStripMenuItem.Enabled = true;
                    break;

                default:
                    activeRemove.Enabled = true;
                    activeEdit.Enabled = false;
                    removeFromQuickplayToolStripMenuItem.Enabled = true;
                    break;
            }
        }

        private void activeRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in activeListView.SelectedItems)
                item.Remove();
            trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
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
                foreach(ListViewItem item in installedListView.SelectedItems)
                {
                    activeListView.Items.Add((ListViewItem)item.Clone());
                    activeListView.Sort();
                    if (installedListView.SelectedIndices.Count == 1)
                    {
                        installedSetActive.Text = "Remove From Quickplay";
                    } else
                    {
                        installedSetActive.Enabled = false;
                    }
                }
            }
            trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
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
            PopulateInstalled();
            PopulateActive();
        }

        private void HandleImport(string filename)
        {
            using (ZipArchive archive = ZipFile.OpenRead(filename))
            {
                string manifestfile = "";
                string songID = "";
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    List<string> pathElements = entry.FullName.Split('/').ToList();
                    if (pathElements.Count == 2)
                    {
                        songID = pathElements[0];
                    } else if (pathElements.Count >= 4)
                    {
                        string path = "";
                        string extractFor = pathElements[1].ToLower();
                        pathElements.RemoveRange(0, 2);
                        path = string.Join("/", pathElements);
                        bool shouldExtract = false;
                        if (extractFor == "master" && platform != "iOS") shouldExtract = true;
                        if (extractFor == "360" && platform == "Xbox 360") shouldExtract = true;
                        if (extractFor == "ios" && platform == "iOS") shouldExtract = true;
                        if (extractFor == "ps4" && platform == "PlayStation 4") shouldExtract = true;
                        if (extractFor == "others" && (platform == "PlayStation 4" || platform == "iOS")) shouldExtract = true;
                        if (extractFor == "ps3" && platform == "PlayStation 3")
                        {
                            shouldExtract = true;
                            path = string.Join("/", pathElements).ToUpper();
                        }
                        if (shouldExtract)
                        {
                            if (!entry.FullName.EndsWith("/"))
                            {
                                manifestfile += path + "\n";
                                pathElements.RemoveAt(pathElements.Count - 1);
                                string folderPath = string.Join("/", pathElements);
                                if (!Directory.Exists(gamedir + "\\" + folderPath))
                                {
                                    Console.WriteLine($"Creating \"{entry.FullName}\" in \"{gamedir + "\\" + folderPath}\"");
                                    Directory.CreateDirectory(gamedir + "\\" + folderPath);
                                }
                                Console.WriteLine($"Copying \"{entry.FullName}\" to \"{gamedir + "\\" + path}\"");
                                entry.ExtractToFile(gamedir + "\\" + path, true);
                            }
                        }
                    }
                }
                File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + songID + "\\manifest.txt", manifestfile);
                if (platform == "iOS")
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(gamedir + "\\Audio\\AudioTracks\\" + songID + "\\trackconfig.xml");
                    XmlNode video = document.SelectSingleNode("Track/Video");
                    ((XmlElement)video).SetAttribute("hasVideo", "false");
                    File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + songID + "\\trackconfig.xml", document.OuterXml);
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
            PopulateInstalled();
            trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
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
            XmlNode streakValueExpertTen = configStreak.SelectNodes("Config/StreakValueExpert10")[0];

            singleNoteScore.InnerText = pointsPerNote.Value.ToString();
            maxMultiplier.InnerText = maximumMultiplier.Value.ToString();
            streakPerMultiplierLevel.InnerText = notesPerMultiplier.Value.ToString();
            if (noteStreakFix.Checked)
            {
                streakValueExpertTen.InnerText = "999999";
            } else
            {
                streakValueExpertTen.InnerText = "900";
            }
            
            if (!File.Exists(gamedir + "\\Audio\\AudioTracks\\Setlists.xml.bak") || !File.Exists(gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml.bak"))
            {
                File.Copy(gamedir + "\\Audio\\AudioTracks\\Setlists.xml", gamedir + "\\Audio\\AudioTracks\\Setlists.xml.bak", true);
                File.Copy(gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml", gamedir + "\\Audio\\AudioTracks\\Tracklisting.xml.bak", true);
            }
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

        private void applyHyperspeed_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in installedListView.Items)
            {
                XmlDocument document = new XmlDocument();
                document.Load(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml");
                XmlNode highway = document.SelectSingleNode("Track/Highway");
                ((XmlElement)highway).SetAttribute("newbeginner", speedBBox.Value.ToString());
                ((XmlElement)highway).SetAttribute("neweasy", speedEBox.Value.ToString());
                ((XmlElement)highway).SetAttribute("newmedium", speedMBox.Value.ToString());
                ((XmlElement)highway).SetAttribute("newhard", speedHBox.Value.ToString());
                ((XmlElement)highway).SetAttribute("newexpert", speedXBox.Value.ToString());
                File.Copy(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml.bak", true);
                File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", document.OuterXml);
            }
            MessageBox.Show("Applied batch highway speeds!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportCSVButton_Click(object sender, EventArgs e)
        {
            string output = "Id,Artist,Title,Intensity";
            foreach (ListViewItem item in activeListView.Items)
            {
                output += "\n";
                output += item.SubItems[0].Text + "," + item.SubItems[2].Text + "," + item.SubItems[1].Text + "," + item.SubItems[3].Text;
            }
            if (saveCSVDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveCSVDialog.FileName, output);
            }
        }

        private void disableVideosItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("This will disable all background videos on stock songs in order to resolve issues on truncated copies of the game. Are you sure you want to continue?", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                foreach (string track in defaultTracks)
                {
                    if (File.Exists(gamedir + "\\Audio\\AudioTracks\\" + track + "\\trackconfig.xml"))
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(gamedir + "\\Audio\\AudioTracks\\" + track + "\\trackconfig.xml");
                        XmlNode video = document.SelectSingleNode("Track/Video");
                        ((XmlElement)video).SetAttribute("hasVideo", "false");
                        File.Copy(gamedir + "\\Audio\\AudioTracks\\" + track + "\\trackconfig.xml", gamedir + "\\Audio\\AudioTracks\\" + track + "\\trackconfig.xml.bak", true);
                        File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + track + "\\trackconfig.xml", document.OuterXml);
                    }
                }
            }
        }

        private void disableAllVideosItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in installedListView.Items)
            {
                XmlDocument document = new XmlDocument();
                document.Load(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml");
                XmlNode video = document.SelectSingleNode("Track/Video");
                ((XmlElement)video).SetAttribute("hasVideo", "false");
                File.Copy(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml.bak", true);
                File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", document.OuterXml);
            }
        }

        private void enableCustomVIdeosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in installedListView.Items)
            {
                if (!defaultTracks.Contains(item.SubItems[0].Text))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml");
                    XmlNode video = document.SelectSingleNode("Track/Video");
                    ((XmlElement)video).SetAttribute("hasVideo", "true");
                    File.Copy(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml.bak", true);
                    File.WriteAllText(gamedir + "\\Audio\\AudioTracks\\" + item.SubItems[0].Text + "\\trackconfig.xml", document.OuterXml);
                }
            }
        }
    }
    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        public bool descending = false;
        public int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            if (descending)
            {
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            } else
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }
            
        }
    }
}
