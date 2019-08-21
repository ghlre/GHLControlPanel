namespace GHLCP
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.GameFinderDialog = new System.Windows.Forms.OpenFileDialog();
            this.installedListView = new System.Windows.Forms.ListView();
            this.installedIdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedSongHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedArtistHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.installedIntensityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.songTabs = new System.Windows.Forms.TabControl();
            this.installedTracks = new System.Windows.Forms.TabPage();
            this.installedControls = new System.Windows.Forms.Panel();
            this.installedSetActive = new System.Windows.Forms.Button();
            this.installedRemove = new System.Windows.Forms.Button();
            this.installedRefresh = new System.Windows.Forms.Button();
            this.installedEdit = new System.Windows.Forms.Button();
            this.activeTracks = new System.Windows.Forms.TabPage();
            this.activeListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.activeControls = new System.Windows.Forms.Panel();
            this.activeRemove = new System.Windows.Forms.Button();
            this.activeRefresh = new System.Windows.Forms.Button();
            this.activeEdit = new System.Windows.Forms.Button();
            this.gameHacks = new System.Windows.Forms.TabPage();
            this.gameStartupConfig = new System.Windows.Forms.GroupBox();
            this.showFSGSplash = new System.Windows.Forms.CheckBox();
            this.showActiSplash = new System.Windows.Forms.CheckBox();
            this.GHTVMaxUpgrades = new System.Windows.Forms.Button();
            this.defaultMods = new System.Windows.Forms.Button();
            this.reloadGameMods = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.scoringGroup = new System.Windows.Forms.GroupBox();
            this.pointsPerNote = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.multiplierGroup = new System.Windows.Forms.GroupBox();
            this.notesPerMultiplier = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maximumMultiplier = new System.Windows.Forms.NumericUpDown();
            this.controlStrip = new System.Windows.Forms.MenuStrip();
            this.saveStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.buildXMLItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveModsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTracksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTracksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuckYouActivision = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportSongDialog = new System.Windows.Forms.OpenFileDialog();
            this.hmm = new System.Windows.Forms.PictureBox();
            this.songTabs.SuspendLayout();
            this.installedTracks.SuspendLayout();
            this.installedControls.SuspendLayout();
            this.activeTracks.SuspendLayout();
            this.activeControls.SuspendLayout();
            this.gameHacks.SuspendLayout();
            this.gameStartupConfig.SuspendLayout();
            this.scoringGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPerNote)).BeginInit();
            this.multiplierGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesPerMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumMultiplier)).BeginInit();
            this.controlStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmm)).BeginInit();
            this.SuspendLayout();
            // 
            // GameFinderDialog
            // 
            this.GameFinderDialog.Filter = "Wii U|GHLive.rpx|PlayStation 3|EBOOT.BIN|Xbox 360|default.xex|iOS|GHLive";
            this.GameFinderDialog.Title = "GHL Installation Files";
            // 
            // installedListView
            // 
            this.installedListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.installedListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.installedIdHeader,
            this.installedSongHeader,
            this.installedArtistHeader,
            this.installedIntensityHeader});
            this.installedListView.FullRowSelect = true;
            this.installedListView.Location = new System.Drawing.Point(6, 6);
            this.installedListView.MultiSelect = false;
            this.installedListView.Name = "installedListView";
            this.installedListView.Size = new System.Drawing.Size(524, 453);
            this.installedListView.TabIndex = 0;
            this.installedListView.UseCompatibleStateImageBehavior = false;
            this.installedListView.View = System.Windows.Forms.View.Details;
            this.installedListView.SelectedIndexChanged += new System.EventHandler(this.installedListView_SelectedIndexChanged);
            // 
            // installedIdHeader
            // 
            this.installedIdHeader.Text = "ID";
            // 
            // installedSongHeader
            // 
            this.installedSongHeader.Text = "Name";
            this.installedSongHeader.Width = 250;
            // 
            // installedArtistHeader
            // 
            this.installedArtistHeader.Text = "Artist";
            this.installedArtistHeader.Width = 128;
            // 
            // installedIntensityHeader
            // 
            this.installedIntensityHeader.Text = "Intensity";
            // 
            // songTabs
            // 
            this.songTabs.AllowDrop = true;
            this.songTabs.Controls.Add(this.installedTracks);
            this.songTabs.Controls.Add(this.activeTracks);
            this.songTabs.Controls.Add(this.gameHacks);
            this.songTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songTabs.Location = new System.Drawing.Point(0, 24);
            this.songTabs.Name = "songTabs";
            this.songTabs.SelectedIndex = 0;
            this.songTabs.Size = new System.Drawing.Size(549, 522);
            this.songTabs.TabIndex = 1;
            // 
            // installedTracks
            // 
            this.installedTracks.Controls.Add(this.installedControls);
            this.installedTracks.Controls.Add(this.installedListView);
            this.installedTracks.Location = new System.Drawing.Point(4, 22);
            this.installedTracks.Name = "installedTracks";
            this.installedTracks.Padding = new System.Windows.Forms.Padding(3);
            this.installedTracks.Size = new System.Drawing.Size(541, 496);
            this.installedTracks.TabIndex = 0;
            this.installedTracks.Text = "Installed Tracks";
            this.installedTracks.UseVisualStyleBackColor = true;
            // 
            // installedControls
            // 
            this.installedControls.Controls.Add(this.installedSetActive);
            this.installedControls.Controls.Add(this.installedRemove);
            this.installedControls.Controls.Add(this.installedRefresh);
            this.installedControls.Controls.Add(this.installedEdit);
            this.installedControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.installedControls.Location = new System.Drawing.Point(3, 464);
            this.installedControls.Name = "installedControls";
            this.installedControls.Size = new System.Drawing.Size(535, 29);
            this.installedControls.TabIndex = 1;
            // 
            // installedSetActive
            // 
            this.installedSetActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.installedSetActive.Enabled = false;
            this.installedSetActive.Location = new System.Drawing.Point(292, 3);
            this.installedSetActive.Name = "installedSetActive";
            this.installedSetActive.Size = new System.Drawing.Size(136, 23);
            this.installedSetActive.TabIndex = 3;
            this.installedSetActive.Text = "Add To Quickplay";
            this.installedSetActive.UseVisualStyleBackColor = true;
            this.installedSetActive.Click += new System.EventHandler(this.installedSetActive_Click);
            // 
            // installedRemove
            // 
            this.installedRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.installedRemove.Enabled = false;
            this.installedRemove.Location = new System.Drawing.Point(434, 3);
            this.installedRemove.Name = "installedRemove";
            this.installedRemove.Size = new System.Drawing.Size(59, 23);
            this.installedRemove.TabIndex = 2;
            this.installedRemove.Text = "Remove";
            this.installedRemove.UseVisualStyleBackColor = true;
            this.installedRemove.Click += new System.EventHandler(this.installedRemove_Click);
            // 
            // installedRefresh
            // 
            this.installedRefresh.Location = new System.Drawing.Point(3, 3);
            this.installedRefresh.Name = "installedRefresh";
            this.installedRefresh.Size = new System.Drawing.Size(53, 23);
            this.installedRefresh.TabIndex = 1;
            this.installedRefresh.Text = "Refresh";
            this.installedRefresh.UseVisualStyleBackColor = true;
            this.installedRefresh.Click += new System.EventHandler(this.installedRefresh_Click);
            // 
            // installedEdit
            // 
            this.installedEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.installedEdit.Enabled = false;
            this.installedEdit.Location = new System.Drawing.Point(499, 3);
            this.installedEdit.Name = "installedEdit";
            this.installedEdit.Size = new System.Drawing.Size(33, 23);
            this.installedEdit.TabIndex = 0;
            this.installedEdit.Text = "Edit";
            this.installedEdit.UseVisualStyleBackColor = true;
            this.installedEdit.Click += new System.EventHandler(this.installedEdit_Click);
            // 
            // activeTracks
            // 
            this.activeTracks.Controls.Add(this.activeListView);
            this.activeTracks.Controls.Add(this.activeControls);
            this.activeTracks.Location = new System.Drawing.Point(4, 22);
            this.activeTracks.Name = "activeTracks";
            this.activeTracks.Padding = new System.Windows.Forms.Padding(3);
            this.activeTracks.Size = new System.Drawing.Size(541, 496);
            this.activeTracks.TabIndex = 1;
            this.activeTracks.Text = "Quickplay Tracks";
            this.activeTracks.UseVisualStyleBackColor = true;
            // 
            // activeListView
            // 
            this.activeListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.activeListView.FullRowSelect = true;
            this.activeListView.Location = new System.Drawing.Point(6, 6);
            this.activeListView.MultiSelect = false;
            this.activeListView.Name = "activeListView";
            this.activeListView.ShowGroups = false;
            this.activeListView.Size = new System.Drawing.Size(524, 453);
            this.activeListView.TabIndex = 4;
            this.activeListView.UseCompatibleStateImageBehavior = false;
            this.activeListView.View = System.Windows.Forms.View.Details;
            this.activeListView.SelectedIndexChanged += new System.EventHandler(this.activeListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Artist";
            this.columnHeader3.Width = 128;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Intensity";
            // 
            // activeControls
            // 
            this.activeControls.Controls.Add(this.activeRemove);
            this.activeControls.Controls.Add(this.activeRefresh);
            this.activeControls.Controls.Add(this.activeEdit);
            this.activeControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.activeControls.Location = new System.Drawing.Point(3, 464);
            this.activeControls.Name = "activeControls";
            this.activeControls.Size = new System.Drawing.Size(535, 29);
            this.activeControls.TabIndex = 3;
            // 
            // activeRemove
            // 
            this.activeRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activeRemove.Enabled = false;
            this.activeRemove.Location = new System.Drawing.Point(361, 3);
            this.activeRemove.Name = "activeRemove";
            this.activeRemove.Size = new System.Drawing.Size(132, 23);
            this.activeRemove.TabIndex = 3;
            this.activeRemove.Text = "Remove From Quickplay";
            this.activeRemove.UseVisualStyleBackColor = true;
            this.activeRemove.Click += new System.EventHandler(this.activeRemove_Click);
            // 
            // activeRefresh
            // 
            this.activeRefresh.Location = new System.Drawing.Point(3, 3);
            this.activeRefresh.Name = "activeRefresh";
            this.activeRefresh.Size = new System.Drawing.Size(53, 23);
            this.activeRefresh.TabIndex = 1;
            this.activeRefresh.Text = "Refresh";
            this.activeRefresh.UseVisualStyleBackColor = true;
            this.activeRefresh.Click += new System.EventHandler(this.activeRefresh_Click);
            // 
            // activeEdit
            // 
            this.activeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.activeEdit.Enabled = false;
            this.activeEdit.Location = new System.Drawing.Point(499, 3);
            this.activeEdit.Name = "activeEdit";
            this.activeEdit.Size = new System.Drawing.Size(33, 23);
            this.activeEdit.TabIndex = 0;
            this.activeEdit.Text = "Edit";
            this.activeEdit.UseVisualStyleBackColor = true;
            this.activeEdit.Click += new System.EventHandler(this.activeEdit_Click);
            // 
            // gameHacks
            // 
            this.gameHacks.Controls.Add(this.gameStartupConfig);
            this.gameHacks.Controls.Add(this.GHTVMaxUpgrades);
            this.gameHacks.Controls.Add(this.hmm);
            this.gameHacks.Controls.Add(this.defaultMods);
            this.gameHacks.Controls.Add(this.reloadGameMods);
            this.gameHacks.Controls.Add(this.label4);
            this.gameHacks.Controls.Add(this.scoringGroup);
            this.gameHacks.Controls.Add(this.multiplierGroup);
            this.gameHacks.Location = new System.Drawing.Point(4, 22);
            this.gameHacks.Name = "gameHacks";
            this.gameHacks.Padding = new System.Windows.Forms.Padding(3);
            this.gameHacks.Size = new System.Drawing.Size(541, 496);
            this.gameHacks.TabIndex = 2;
            this.gameHacks.Text = "Game Modifications";
            this.gameHacks.UseVisualStyleBackColor = true;
            // 
            // gameStartupConfig
            // 
            this.gameStartupConfig.Controls.Add(this.showFSGSplash);
            this.gameStartupConfig.Controls.Add(this.showActiSplash);
            this.gameStartupConfig.Location = new System.Drawing.Point(232, 18);
            this.gameStartupConfig.Name = "gameStartupConfig";
            this.gameStartupConfig.Size = new System.Drawing.Size(291, 72);
            this.gameStartupConfig.TabIndex = 7;
            this.gameStartupConfig.TabStop = false;
            this.gameStartupConfig.Text = "Game Startup";
            // 
            // showFSGSplash
            // 
            this.showFSGSplash.AutoSize = true;
            this.showFSGSplash.Location = new System.Drawing.Point(11, 45);
            this.showFSGSplash.Name = "showFSGSplash";
            this.showFSGSplash.Size = new System.Drawing.Size(131, 17);
            this.showFSGSplash.TabIndex = 1;
            this.showFSGSplash.Text = "Freestyle Games Sting";
            this.showFSGSplash.UseVisualStyleBackColor = true;
            // 
            // showActiSplash
            // 
            this.showActiSplash.AutoSize = true;
            this.showActiSplash.Location = new System.Drawing.Point(11, 22);
            this.showActiSplash.Name = "showActiSplash";
            this.showActiSplash.Size = new System.Drawing.Size(98, 17);
            this.showActiSplash.TabIndex = 0;
            this.showActiSplash.Text = "Activision Sting";
            this.showActiSplash.UseVisualStyleBackColor = true;
            this.showActiSplash.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // GHTVMaxUpgrades
            // 
            this.GHTVMaxUpgrades.Location = new System.Drawing.Point(18, 186);
            this.GHTVMaxUpgrades.Name = "GHTVMaxUpgrades";
            this.GHTVMaxUpgrades.Size = new System.Drawing.Size(190, 23);
            this.GHTVMaxUpgrades.TabIndex = 6;
            this.GHTVMaxUpgrades.Text = "GHTV Maximum Upgrades";
            this.GHTVMaxUpgrades.UseVisualStyleBackColor = true;
            this.GHTVMaxUpgrades.Click += new System.EventHandler(this.GHTVMaxUpgrades_Click);
            // 
            // defaultMods
            // 
            this.defaultMods.Location = new System.Drawing.Point(343, 269);
            this.defaultMods.Name = "defaultMods";
            this.defaultMods.Size = new System.Drawing.Size(101, 23);
            this.defaultMods.TabIndex = 4;
            this.defaultMods.Text = "Reset To Default";
            this.defaultMods.UseVisualStyleBackColor = true;
            this.defaultMods.Click += new System.EventHandler(this.defaultMods_Click);
            // 
            // reloadGameMods
            // 
            this.reloadGameMods.Location = new System.Drawing.Point(450, 269);
            this.reloadGameMods.Name = "reloadGameMods";
            this.reloadGameMods.Size = new System.Drawing.Size(83, 23);
            this.reloadGameMods.TabIndex = 3;
            this.reloadGameMods.Text = "Reload Config";
            this.reloadGameMods.UseVisualStyleBackColor = true;
            this.reloadGameMods.Click += new System.EventHandler(this.reloadGameMods_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(75, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "More options will be added in the future!";
            // 
            // scoringGroup
            // 
            this.scoringGroup.Controls.Add(this.pointsPerNote);
            this.scoringGroup.Controls.Add(this.label3);
            this.scoringGroup.Location = new System.Drawing.Point(18, 116);
            this.scoringGroup.Name = "scoringGroup";
            this.scoringGroup.Size = new System.Drawing.Size(190, 64);
            this.scoringGroup.TabIndex = 1;
            this.scoringGroup.TabStop = false;
            this.scoringGroup.Text = "Scoring";
            // 
            // pointsPerNote
            // 
            this.pointsPerNote.Location = new System.Drawing.Point(121, 28);
            this.pointsPerNote.Name = "pointsPerNote";
            this.pointsPerNote.Size = new System.Drawing.Size(38, 20);
            this.pointsPerNote.TabIndex = 1;
            this.pointsPerNote.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Points Per Note:";
            // 
            // multiplierGroup
            // 
            this.multiplierGroup.Controls.Add(this.notesPerMultiplier);
            this.multiplierGroup.Controls.Add(this.label2);
            this.multiplierGroup.Controls.Add(this.label1);
            this.multiplierGroup.Controls.Add(this.maximumMultiplier);
            this.multiplierGroup.Location = new System.Drawing.Point(18, 18);
            this.multiplierGroup.Name = "multiplierGroup";
            this.multiplierGroup.Size = new System.Drawing.Size(190, 92);
            this.multiplierGroup.TabIndex = 0;
            this.multiplierGroup.TabStop = false;
            this.multiplierGroup.Text = "Multiplier";
            // 
            // notesPerMultiplier
            // 
            this.notesPerMultiplier.Location = new System.Drawing.Point(121, 57);
            this.notesPerMultiplier.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.notesPerMultiplier.Name = "notesPerMultiplier";
            this.notesPerMultiplier.Size = new System.Drawing.Size(38, 20);
            this.notesPerMultiplier.TabIndex = 3;
            this.notesPerMultiplier.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Notes Per Level:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum Multiplier:";
            // 
            // maximumMultiplier
            // 
            this.maximumMultiplier.Location = new System.Drawing.Point(121, 24);
            this.maximumMultiplier.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.maximumMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maximumMultiplier.Name = "maximumMultiplier";
            this.maximumMultiplier.Size = new System.Drawing.Size(38, 20);
            this.maximumMultiplier.TabIndex = 0;
            this.maximumMultiplier.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // controlStrip
            // 
            this.controlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStrip,
            this.tracksStrip,
            this.aboutStrip});
            this.controlStrip.Location = new System.Drawing.Point(0, 0);
            this.controlStrip.Name = "controlStrip";
            this.controlStrip.Size = new System.Drawing.Size(549, 24);
            this.controlStrip.TabIndex = 2;
            this.controlStrip.Text = "menuStrip1";
            // 
            // saveStrip
            // 
            this.saveStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildXMLItem,
            this.saveModsItem});
            this.saveStrip.Name = "saveStrip";
            this.saveStrip.Size = new System.Drawing.Size(43, 20);
            this.saveStrip.Text = "Save";
            // 
            // buildXMLItem
            // 
            this.buildXMLItem.Name = "buildXMLItem";
            this.buildXMLItem.Size = new System.Drawing.Size(204, 22);
            this.buildXMLItem.Text = "Build Setlists/Tracklisting";
            this.buildXMLItem.Click += new System.EventHandler(this.buildXMLItem_Click);
            // 
            // saveModsItem
            // 
            this.saveModsItem.Name = "saveModsItem";
            this.saveModsItem.Size = new System.Drawing.Size(204, 22);
            this.saveModsItem.Text = "Save Modifications";
            this.saveModsItem.Click += new System.EventHandler(this.saveModsItem_Click);
            // 
            // tracksStrip
            // 
            this.tracksStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadTracksItem,
            this.importTracksItem});
            this.tracksStrip.Name = "tracksStrip";
            this.tracksStrip.Size = new System.Drawing.Size(51, 20);
            this.tracksStrip.Text = "Tracks";
            // 
            // downloadTracksItem
            // 
            this.downloadTracksItem.Enabled = false;
            this.downloadTracksItem.Name = "downloadTracksItem";
            this.downloadTracksItem.Size = new System.Drawing.Size(163, 22);
            this.downloadTracksItem.Text = "Download Tracks";
            // 
            // importTracksItem
            // 
            this.importTracksItem.Name = "importTracksItem";
            this.importTracksItem.Size = new System.Drawing.Size(163, 22);
            this.importTracksItem.Text = "Import Tracks";
            this.importTracksItem.Click += new System.EventHandler(this.importTracksItem_Click);
            // 
            // aboutStrip
            // 
            this.aboutStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatesItem,
            this.aboutSeperator,
            this.aboutItem,
            this.fuckYouActivision});
            this.aboutStrip.Name = "aboutStrip";
            this.aboutStrip.Size = new System.Drawing.Size(52, 20);
            this.aboutStrip.Text = "About";
            // 
            // updatesItem
            // 
            this.updatesItem.Enabled = false;
            this.updatesItem.Name = "updatesItem";
            this.updatesItem.Size = new System.Drawing.Size(171, 22);
            this.updatesItem.Text = "Check for Updates";
            // 
            // aboutSeperator
            // 
            this.aboutSeperator.Name = "aboutSeperator";
            this.aboutSeperator.Size = new System.Drawing.Size(168, 6);
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(171, 22);
            this.aboutItem.Text = "About GHLCP";
            this.aboutItem.Click += new System.EventHandler(this.aboutItem_Click);
            // 
            // fuckYouActivision
            // 
            this.fuckYouActivision.Name = "fuckYouActivision";
            this.fuckYouActivision.Size = new System.Drawing.Size(171, 22);
            this.fuckYouActivision.Text = "Annoy ATVIAssist";
            this.fuckYouActivision.Click += new System.EventHandler(this.fuckYouActivision_Click);
            // 
            // ImportSongDialog
            // 
            this.ImportSongDialog.Filter = "GHLCP Song Files|*.ghlcp;*.zip";
            this.ImportSongDialog.Multiselect = true;
            // 
            // hmm
            // 
            this.hmm.Image = global::GHLCP.Properties.Resources._do;
            this.hmm.Location = new System.Drawing.Point(343, 298);
            this.hmm.Name = "hmm";
            this.hmm.Size = new System.Drawing.Size(190, 190);
            this.hmm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hmm.TabIndex = 5;
            this.hmm.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 546);
            this.Controls.Add(this.songTabs);
            this.Controls.Add(this.controlStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(565, 585);
            this.Name = "MainWindow";
            this.Text = "Guitar Hero Live Control Panel";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.songTabs.ResumeLayout(false);
            this.installedTracks.ResumeLayout(false);
            this.installedControls.ResumeLayout(false);
            this.activeTracks.ResumeLayout(false);
            this.activeControls.ResumeLayout(false);
            this.gameHacks.ResumeLayout(false);
            this.gameHacks.PerformLayout();
            this.gameStartupConfig.ResumeLayout(false);
            this.gameStartupConfig.PerformLayout();
            this.scoringGroup.ResumeLayout(false);
            this.scoringGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPerNote)).EndInit();
            this.multiplierGroup.ResumeLayout(false);
            this.multiplierGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesPerMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumMultiplier)).EndInit();
            this.controlStrip.ResumeLayout(false);
            this.controlStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog GameFinderDialog;
        private System.Windows.Forms.ListView installedListView;
        private System.Windows.Forms.ColumnHeader installedIdHeader;
        private System.Windows.Forms.ColumnHeader installedSongHeader;
        private System.Windows.Forms.ColumnHeader installedArtistHeader;
        private System.Windows.Forms.ColumnHeader installedIntensityHeader;
        private System.Windows.Forms.TabControl songTabs;
        private System.Windows.Forms.TabPage installedTracks;
        private System.Windows.Forms.Panel installedControls;
        private System.Windows.Forms.TabPage activeTracks;
        private System.Windows.Forms.Button installedEdit;
        private System.Windows.Forms.Button installedRefresh;
        private System.Windows.Forms.Button installedSetActive;
        private System.Windows.Forms.Button installedRemove;
        private System.Windows.Forms.Panel activeControls;
        private System.Windows.Forms.Button activeRemove;
        private System.Windows.Forms.Button activeRefresh;
        private System.Windows.Forms.Button activeEdit;
        private System.Windows.Forms.TabPage gameHacks;
        private System.Windows.Forms.MenuStrip controlStrip;
        private System.Windows.Forms.ToolStripMenuItem saveStrip;
        private System.Windows.Forms.ToolStripMenuItem buildXMLItem;
        private System.Windows.Forms.ToolStripMenuItem saveModsItem;
        private System.Windows.Forms.ToolStripMenuItem tracksStrip;
        private System.Windows.Forms.ToolStripMenuItem downloadTracksItem;
        private System.Windows.Forms.ToolStripMenuItem importTracksItem;
        private System.Windows.Forms.ToolStripMenuItem aboutStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem updatesItem;
        private System.Windows.Forms.ToolStripSeparator aboutSeperator;
        private System.Windows.Forms.ListView activeListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox scoringGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox multiplierGroup;
        private System.Windows.Forms.NumericUpDown notesPerMultiplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown maximumMultiplier;
        private System.Windows.Forms.PictureBox hmm;
        private System.Windows.Forms.Button defaultMods;
        private System.Windows.Forms.Button reloadGameMods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown pointsPerNote;
        private System.Windows.Forms.Button GHTVMaxUpgrades;
        private System.Windows.Forms.OpenFileDialog ImportSongDialog;
        private System.Windows.Forms.ToolStripMenuItem fuckYouActivision;
        private System.Windows.Forms.GroupBox gameStartupConfig;
        private System.Windows.Forms.CheckBox showFSGSplash;
        private System.Windows.Forms.CheckBox showActiSplash;
    }
}

