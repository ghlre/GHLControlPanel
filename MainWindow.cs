using GHLCP.Diagnostics;
using GHLCP.FileManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using System.Xml;

namespace GHLCP
{

    public partial class MainWindow : Form
    {
        private Gamedir gamedir;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PopulateInstalled() => PopulateInstalled(gamedir);

        private void PopulateInstalled(IEnumerable<Trackconfig> tracks)
        {
            installedListView.Items.Clear();

            foreach (Trackconfig trackconfig in tracks)
            {
                installedListView.Items.Add(trackconfig.GetListViewItem());
            }

            installedListView.Sorting = SortOrder.Ascending;
            installedListView.ListViewItemSorter = null;
            installedListView.ColumnClick += ListView_ColumnClick;
        }

        private void PopulateActive()
        {
            activeListView.Items.Clear();

            foreach (string id in gamedir.Active)
            {
                activeListView.Items.Add(gamedir[id].GetListViewItem(id));
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
                switch (((ListView)o).Sorting)
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
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/Configs/ConfigScore.xml")))
            {
                configScore.Load(stream);
            }
            XmlNode singleNoteScore = configScore.SelectNodes("Config/SingleNoteScore")[0];

            XmlDocument configStreak = new XmlDocument();
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/Configs/Config_Streak.xml")))
            {
                configStreak.Load(stream);
            }
            XmlNode maxMultiplier = configStreak.SelectNodes("Config/MaxMultiplier")[0];
            XmlNode streakPerMultiplierLevel = configStreak.SelectNodes("Config/StreakPerMultiplierLevel")[0];
            XmlNode streakValueExpertTen = configStreak.SelectNodes("Config/StreakValueExpert10")[0];

            pointsPerNote.Value = Convert.ToInt32(singleNoteScore.InnerText);
            maximumMultiplier.Value = Convert.ToInt32(maxMultiplier.InnerText);
            notesPerMultiplier.Value = Convert.ToInt32(streakPerMultiplierLevel.InnerText);
            noteStreakFix.Checked = (streakValueExpertTen.InnerText == "999999");

            XmlDocument gameui = new XmlDocument();
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/UI/GameUI.xml")))
            {
                gameui.Load(stream);
            }
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
            OpenForm openForm = new OpenForm(Properties.Settings.Default.pastFile);

            if (openForm.Result != null || openForm.ShowDialog() == DialogResult.OK)
                gamedir = openForm.Result;

            if (gamedir == null)
            {
                Application.Exit();
            } else
            {
                OpenGameFiles();

                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    foreach (string arg in args.Skip(1))
                    {
                        gamedir.HandleImport(arg);
                    }
                }
            }
        }

        private void installedRefresh_Click(object sender, EventArgs e)
        {
            gamedir.ReadInstalled();
            PopulateInstalled();
        }

        private void buildXMLItem_Click(object sender, EventArgs e)
        {
            gamedir.WriteActive();
            MessageBox.Show("Built and saved Setlists/Tracklisting XML files!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void installedListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            installedRemove.Enabled = false;
            installedEdit.Enabled = false;

            if (installedListView.SelectedIndices.Count == 0)
            {
                installedSetActive.Text = "Add To Quickplay";
                installedSetActive.Enabled = false;
            } else
            {
                installedSetActive.Enabled = true;

                if (installedListView.SelectedIndices.Count == 1)
                {
                    installedEdit.Enabled = true;
                }

                foreach (ListViewItem selectedItem in installedListView.SelectedItems)
                {
                    if (gamedir.FileManager.FileExists(gamedir.GetPath("/Audio/AudioTracks/" + selectedItem.SubItems[0].Text + "/manifest.txt")) && !gamedir[selectedItem.SubItems[0].Text].IsDefault)
                    {
                        installedRemove.Enabled = true;
                        break;
                    }
                }

                installedSetActive.Text = "Add To Quickplay";
                foreach (ListViewItem selecteditem in installedListView.SelectedItems)
                {
                    if (gamedir.Active.Contains(selecteditem.SubItems[0].Text))
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
            {
                gamedir.Active.Remove(item.SubItems[0].Text);
                item.Remove();
            }
            trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
        }

        private void installedSetActive_Click(object sender, EventArgs e)
        {
            bool shouldRemove = gamedir.Active.Contains(installedListView.SelectedItems[0].SubItems[0].Text);

            if (shouldRemove)
            {
                foreach (ListViewItem item in installedListView.SelectedItems)
                {
                    gamedir.Active.Remove(item.SubItems[0].Text);
                }

                installedSetActive.Text = "Add To Quickplay";

                PopulateActive();
            } else
            {
                foreach (ListViewItem item in installedListView.SelectedItems)
                {
                    gamedir.Active.Add(item.SubItems[0].Text);
                    activeListView.Items.Add((ListViewItem)item.Clone());
                    activeListView.Sort();
                }

                if (installedListView.SelectedIndices.Count == 1)
                {
                    installedSetActive.Text = "Remove From Quickplay";
                } else
                {
                    installedSetActive.Enabled = false;
                }

                trackCountLabel.Text = "Track count:" + activeListView.Items.Count + "/" + installedListView.Items.Count;
            }
        }

        private void activeRefresh_Click(object sender, EventArgs e)
        {
            bool shouldRefresh = (MessageBox.Show("Are you sure you want to refresh? This will remove all pending changes you have made.", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            if (shouldRefresh)
            {
                gamedir.ReadActive();
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
                new WaitingForm(gamedir, ImportSongDialog.FileNames).ShowDialog();
                PopulateInstalled();
                PopulateActive();
            }
        }

        private void installedRemove_Click(object sender, EventArgs e)
        {
            string msg = "";

            foreach (ListViewItem item in installedListView.SelectedItems)
            {
                Trackconfig trackconfig = gamedir[item.SubItems[0].Text];

                if (gamedir.FileManager.FileExists(gamedir.GetPath("/Audio/AudioTracks/" + trackconfig.Id + "/manifest.txt")))
                {
                    if (trackconfig.IsDefault)
                    {
                        msg += "ID " + trackconfig.Id + ", " + trackconfig.Trackname + " by " + trackconfig.Artist + " is a default track and therefore can not be safely removed.\n";
                    } else
                    {
                        gamedir.RemoveTrack(trackconfig);
                    }
                } else
                {
                    msg += "ID " + trackconfig.Id + ", " + trackconfig.Trackname + " by " + trackconfig.Artist + " doesn't have a manifest and therefore can not be safely removed.\n";
                }
            }

            if (msg != "")
            {
                MessageBox.Show(msg, "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopulateInstalled();
            PopulateActive();
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
            Process.Start("https://twitter.com/intent/tweet?text=@ATVIAssist%20" + funnyQuoteHaha[new Random().Next(funnyQuoteHaha.Length)].Replace(" ", "%20"));
        }

        private void saveModsItem_Click(object sender, EventArgs e)
        {
            XmlDocument configScore = new XmlDocument();
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/Configs/ConfigScore.xml")))
            {
                configScore.Load(stream);
            }
            XmlNode singleNoteScore = configScore.SelectNodes("Config/SingleNoteScore")[0];

            XmlDocument configStreak = new XmlDocument();
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/Configs/Config_Streak.xml")))
            {
                configStreak.Load(stream);
            }
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

            if (!gamedir.FileManager.FileExists(gamedir.GetPath("/Audio/AudioTracks/Setlists.xml.bak")) || !gamedir.FileManager.FileExists(gamedir.GetPath("/Audio/AudioTracks/Tracklisting.xml.bak")))
            {
                gamedir.Backup(gamedir.GetPath("/Audio/AudioTracks/Setlists.xml"));
                gamedir.Backup(gamedir.GetPath("/Audio/AudioTracks/Tracklisting.xml"));
            }

            using (Stream stream = gamedir.FileManager.OpenWrite(gamedir.GetPath("/Configs/ConfigScore.xml")))
            {
                configScore.Save(stream);
            }

            using (Stream stream = gamedir.FileManager.OpenWrite(gamedir.GetPath("/Configs/Config_Streak.xml")))
            {
                configStreak.Save(stream);
            }

            XmlDocument gameui = new XmlDocument();
            using (Stream stream = gamedir.FileManager.OpenRead(gamedir.GetPath("/UI/GameUI.xml")))
            {
                gameui.Load(stream);
            }
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

            Logger.Instance.Debug(gameui.OuterXml);

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

            gamedir.Backup(gamedir.GetPath("/UI/GameUI.xml"));
            using (Stream stream = gamedir.FileManager.OpenWrite(gamedir.GetPath("/UI/GameUI.xml")))
            {
                gameui.Save(stream);
            }

            MessageBox.Show("Saved modified game files!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void installedEdit_Click(object sender, EventArgs e)
        {
            if (new EditSong(gamedir, gamedir[installedListView.SelectedItems[0].SubItems[0].Text]).ShowDialog() == DialogResult.Yes)
            {
                PopulateInstalled();
                PopulateActive();
            }
        }

        private void activeEdit_Click(object sender, EventArgs e)
        {
            if (new EditSong(gamedir, gamedir[activeListView.SelectedItems[0].SubItems[0].Text]).ShowDialog() == DialogResult.Yes)
            {
                PopulateInstalled();
                PopulateActive();
            }
        }

        private void applyHyperspeed_Click(object sender, EventArgs e)
        {
            TrackconfigHighway highway = new TrackconfigHighway()
            {
                Beginner = Convert.ToDouble(speedBBox.Value),
                Easy = Convert.ToDouble(speedEBox.Value),
                Medium = Convert.ToDouble(speedMBox.Value),
                Hard = Convert.ToDouble(speedHBox.Value),
                Expert = Convert.ToDouble(speedXBox.Value)
            };

            foreach (Trackconfig trackconfig in gamedir)
            {
                trackconfig.Highway = highway.Clone() as TrackconfigHighway;
                gamedir.WriteTrackconfig(trackconfig);
            }

            MessageBox.Show("Applied batch highway speeds!", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void disableVideosItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("This will disable all background videos on stock songs in order to resolve issues on truncated copies of the game. Are you sure you want to continue?", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                foreach (Trackconfig trackconfig in gamedir.Where(track => track.IsDefault))
                {
                    trackconfig.Video.HasVideo = false;
                    gamedir.WriteTrackconfig(trackconfig);
                }
            }
        }

        private void disableAllVideosItem_Click(object sender, EventArgs e)
        {
            foreach (Trackconfig trackconfig in gamedir)
            {
                trackconfig.Video.HasVideo = false;
                gamedir.WriteTrackconfig(trackconfig);
            }
        }

        private void enableCustomVIdeosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Trackconfig trackconfig in gamedir.Where(track => !track.IsDefault))
            {
                trackconfig.Video.HasVideo = true;
                gamedir.WriteTrackconfig(trackconfig);
            }
        }

        private void enableCustomParentSetlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to enable custom parent setlists? This may cause some crashes.", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnableCustomParentSetlists(true);
            }
        }

        private void disableCustomParentSetlistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableCustomParentSetlists(false);
        }

        private void launchInRPCS3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gamedir.FileManager is LocalFileManager && !File.Exists(Properties.Settings.Default.rpcs3Exe))
            {
                MessageBox.Show("Please select your RPCS3 executable.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenFileDialog rpcs3ExeDialog = new OpenFileDialog
                {
                    Title = "Open RPCS3 executable",
                    Filter = "RPCS3 executable|rpcs3.exe"
                };

                if (rpcs3ExeDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.rpcs3Exe = rpcs3ExeDialog.FileName;
                    Properties.Settings.Default.Save();
                } else
                {
                    return;
                }
            }

            Process.Start(
                new ProcessStartInfo(Properties.Settings.Default.rpcs3Exe, $"\"{gamedir}/EBOOT.BIN\"")
                {
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.rpcs3Exe)
                }
            );
        }

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCsvDialog = new OpenFileDialog
            {
                Title = "Import Songlist CSV",
                Filter = "CSV file|*.csv"
            };

            if (openCsvDialog.ShowDialog() == DialogResult.OK)
            {
                gamedir.ImportSonglistCSV(openCsvDialog.FileName);
                PopulateActive();
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveCSVDialog.ShowDialog() == DialogResult.OK)
            {
                gamedir.ExportSonglistCSV(saveCSVDialog.FileName);
            }
        }

        private void randomizeSonglistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamedir.RandomizeSonglist();
            PopulateActive();
        }

        private void OpenGameFiles()
        {
            bool isLocal = gamedir.FileManager is LocalFileManager;
            launchInRPCS3ToolStripMenuItem.Enabled = uppercaseFix.Enabled = isLocal && gamedir.Platform is PlatformPS3;
            openInFileExplorerToolStripMenuItem.Enabled = isLocal;

            PopulateInstalled();
            PopulateActive();
            ReadGameModifications();
        }

        private void openGameFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm openForm = new OpenForm();

            if (openForm.ShowDialog() == DialogResult.OK)
            {
                gamedir = openForm.Result;
                OpenGameFiles();
            }
        }

        /// <summary>Enable or disable the parent setlists of all the installed custom songs</summary>
        /// <param name="enable">Enable parent setlists if true, disable if false</param>
        private void EnableCustomParentSetlists(bool enable)
        {
            foreach (Trackconfig trackconfig in gamedir.Where(track => !track.IsDefault && track.Stagefright.Enabled != enable))
            {
                gamedir.SetParentSetlist(trackconfig, enable);
                gamedir.WriteTrackconfig(trackconfig);
            }
        }

        /// <summary>Recursively apply uppercase to each file and directory from the root directory</summary>
        /// <param name="root">Root directory to apply uppercase to</param>
        public static void UppercaseDir(string root)
        {
            foreach (string file in Directory.GetFiles(root))
            {
                File.Move(file, file.ToUpper());
            }

            foreach (string dir in Directory.GetDirectories(root))
            {
                Directory.Move(dir, dir + "temp"); // Move to a temporary directory to avoid IOException
                Directory.Move(dir + "temp", dir.ToUpper());
                foreach (string file in Directory.GetFiles(dir.ToUpper()))
                {
                    File.Move(file, file.ToUpper());
                }

                UppercaseDir(dir.ToUpper());
            }
        }

        private void openInFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@gamedir.ToString());
        }

        private void uppercaseFix_Click(object sender, EventArgs e)
        {
            UppercaseDir(gamedir.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void activeClear_Click(object sender, EventArgs e)
        {
            gamedir.Active = new List<string>();
            PopulateActive();
        }

        private void searchInstalled_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(gamedir);

            if (search.ShowDialog() == DialogResult.Yes)
            {
                PopulateInstalled(search.Result);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string searchLower = searchBox.Text.ToLower();

            PopulateInstalled(gamedir.Where(track => track.Trackname.ToLower().Contains(searchLower) ||
            track.Artist.ToLower().Contains(searchLower) ||
            track.Id.ToLower().Contains(searchLower)));
        }
    }

    public static class TrackconfigExtension
    {
        public static ListViewItem GetListViewItem(this Trackconfig trackconfig)
        {
            return new ListViewItem(new string[] { trackconfig.Id, trackconfig.Trackname, trackconfig.Artist, trackconfig.Intensity.ToString() });
        }

        public static ListViewItem GetListViewItem(this Trackconfig trackconfig, string id)
        {
            if (trackconfig == null)
                return new ListViewItem(new string[] { id, "Track unavailable" }) { ForeColor = Color.Red };
            return trackconfig.GetListViewItem();
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
