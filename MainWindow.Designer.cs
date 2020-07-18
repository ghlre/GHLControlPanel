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
            this.components = new System.ComponentModel.Container();
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
            this.contextMenuStripActiveList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromQuickplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeControls = new System.Windows.Forms.Panel();
            this.trackCountLabel = new System.Windows.Forms.Label();
            this.activeRemove = new System.Windows.Forms.Button();
            this.activeRefresh = new System.Windows.Forms.Button();
            this.activeEdit = new System.Windows.Forms.Button();
            this.gameHacks = new System.Windows.Forms.TabPage();
            this.noteStreakFix = new System.Windows.Forms.CheckBox();
            this.batchHyperspeed = new System.Windows.Forms.GroupBox();
            this.speedXBox = new System.Windows.Forms.NumericUpDown();
            this.spxlabel = new System.Windows.Forms.Label();
            this.speedHBox = new System.Windows.Forms.NumericUpDown();
            this.sphlabel = new System.Windows.Forms.Label();
            this.speedMBox = new System.Windows.Forms.NumericUpDown();
            this.spmlabel = new System.Windows.Forms.Label();
            this.speedEBox = new System.Windows.Forms.NumericUpDown();
            this.spelabel = new System.Windows.Forms.Label();
            this.speedBBox = new System.Windows.Forms.NumericUpDown();
            this.spblabel = new System.Windows.Forms.Label();
            this.applyHyperspeed = new System.Windows.Forms.Button();
            this.irreversibleWarning = new System.Windows.Forms.Label();
            this.gameStartupConfig = new System.Windows.Forms.GroupBox();
            this.showFSGSplash = new System.Windows.Forms.CheckBox();
            this.showActiSplash = new System.Windows.Forms.CheckBox();
            this.GHTVMaxUpgrades = new System.Windows.Forms.Button();
            this.hmm = new System.Windows.Forms.PictureBox();
            this.defaultMods = new System.Windows.Forms.Button();
            this.reloadGameMods = new System.Windows.Forms.Button();
            this.moreSoon = new System.Windows.Forms.Label();
            this.scoringGroup = new System.Windows.Forms.GroupBox();
            this.pointsPerNote = new System.Windows.Forms.NumericUpDown();
            this.pointsPerNoteLabel = new System.Windows.Forms.Label();
            this.multiplierGroup = new System.Windows.Forms.GroupBox();
            this.notesPerMultiplier = new System.Windows.Forms.NumericUpDown();
            this.notesPerLevelLabel = new System.Windows.Forms.Label();
            this.maximumMultiplierLabel = new System.Windows.Forms.Label();
            this.maximumMultiplier = new System.Windows.Forms.NumericUpDown();
            this.controlStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchInRPCS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.buildXMLItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveModsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTracksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTracksItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.disableVideosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableAllVideosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableCustomVIdeosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.randomizeSonglistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuckYouActivision = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportSongDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveCSVDialog = new System.Windows.Forms.SaveFileDialog();
            this.songTabs.SuspendLayout();
            this.installedTracks.SuspendLayout();
            this.installedControls.SuspendLayout();
            this.activeTracks.SuspendLayout();
            this.contextMenuStripActiveList.SuspendLayout();
            this.activeControls.SuspendLayout();
            this.gameHacks.SuspendLayout();
            this.batchHyperspeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedXBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedHBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedMBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedEBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBBox)).BeginInit();
            this.gameStartupConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmm)).BeginInit();
            this.scoringGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPerNote)).BeginInit();
            this.multiplierGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesPerMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumMultiplier)).BeginInit();
            this.controlStrip.SuspendLayout();
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
            this.installedListView.HideSelection = false;
            this.installedListView.Location = new System.Drawing.Point(6, 6);
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
            this.activeListView.ContextMenuStrip = this.contextMenuStripActiveList;
            this.activeListView.FullRowSelect = true;
            this.activeListView.HideSelection = false;
            this.activeListView.Location = new System.Drawing.Point(6, 6);
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
            // contextMenuStripActiveList
            // 
            this.contextMenuStripActiveList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromQuickplayToolStripMenuItem});
            this.contextMenuStripActiveList.Name = "contextMenuStripActiveList";
            this.contextMenuStripActiveList.Size = new System.Drawing.Size(203, 26);
            // 
            // removeFromQuickplayToolStripMenuItem
            // 
            this.removeFromQuickplayToolStripMenuItem.Name = "removeFromQuickplayToolStripMenuItem";
            this.removeFromQuickplayToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.removeFromQuickplayToolStripMenuItem.Text = "Remove from Quickplay";
            this.removeFromQuickplayToolStripMenuItem.Click += new System.EventHandler(this.activeRemove_Click);
            // 
            // activeControls
            // 
            this.activeControls.Controls.Add(this.trackCountLabel);
            this.activeControls.Controls.Add(this.activeRemove);
            this.activeControls.Controls.Add(this.activeRefresh);
            this.activeControls.Controls.Add(this.activeEdit);
            this.activeControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.activeControls.Location = new System.Drawing.Point(3, 464);
            this.activeControls.Name = "activeControls";
            this.activeControls.Size = new System.Drawing.Size(535, 29);
            this.activeControls.TabIndex = 3;
            // 
            // trackCountLabel
            // 
            this.trackCountLabel.AutoSize = true;
            this.trackCountLabel.Location = new System.Drawing.Point(62, 8);
            this.trackCountLabel.Name = "trackCountLabel";
            this.trackCountLabel.Size = new System.Drawing.Size(71, 13);
            this.trackCountLabel.TabIndex = 5;
            this.trackCountLabel.Text = "Track count: ";
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
            this.gameHacks.AutoScroll = true;
            this.gameHacks.Controls.Add(this.noteStreakFix);
            this.gameHacks.Controls.Add(this.batchHyperspeed);
            this.gameHacks.Controls.Add(this.gameStartupConfig);
            this.gameHacks.Controls.Add(this.GHTVMaxUpgrades);
            this.gameHacks.Controls.Add(this.hmm);
            this.gameHacks.Controls.Add(this.defaultMods);
            this.gameHacks.Controls.Add(this.reloadGameMods);
            this.gameHacks.Controls.Add(this.moreSoon);
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
            // noteStreakFix
            // 
            this.noteStreakFix.AutoSize = true;
            this.noteStreakFix.Location = new System.Drawing.Point(243, 100);
            this.noteStreakFix.Name = "noteStreakFix";
            this.noteStreakFix.Size = new System.Drawing.Size(182, 17);
            this.noteStreakFix.TabIndex = 10;
            this.noteStreakFix.Text = "Apply 900 Note Streak Expert Fix";
            this.noteStreakFix.UseVisualStyleBackColor = true;
            // 
            // batchHyperspeed
            // 
            this.batchHyperspeed.Controls.Add(this.speedXBox);
            this.batchHyperspeed.Controls.Add(this.spxlabel);
            this.batchHyperspeed.Controls.Add(this.speedHBox);
            this.batchHyperspeed.Controls.Add(this.sphlabel);
            this.batchHyperspeed.Controls.Add(this.speedMBox);
            this.batchHyperspeed.Controls.Add(this.spmlabel);
            this.batchHyperspeed.Controls.Add(this.speedEBox);
            this.batchHyperspeed.Controls.Add(this.spelabel);
            this.batchHyperspeed.Controls.Add(this.speedBBox);
            this.batchHyperspeed.Controls.Add(this.spblabel);
            this.batchHyperspeed.Controls.Add(this.applyHyperspeed);
            this.batchHyperspeed.Controls.Add(this.irreversibleWarning);
            this.batchHyperspeed.Location = new System.Drawing.Point(18, 215);
            this.batchHyperspeed.Name = "batchHyperspeed";
            this.batchHyperspeed.Size = new System.Drawing.Size(190, 195);
            this.batchHyperspeed.TabIndex = 9;
            this.batchHyperspeed.TabStop = false;
            this.batchHyperspeed.Text = "Batch Hyperspeed";
            // 
            // speedXBox
            // 
            this.speedXBox.DecimalPlaces = 2;
            this.speedXBox.Location = new System.Drawing.Point(89, 123);
            this.speedXBox.Name = "speedXBox";
            this.speedXBox.Size = new System.Drawing.Size(79, 20);
            this.speedXBox.TabIndex = 21;
            this.speedXBox.Value = new decimal(new int[] {
            125,
            0,
            0,
            131072});
            // 
            // spxlabel
            // 
            this.spxlabel.AutoSize = true;
            this.spxlabel.Location = new System.Drawing.Point(8, 125);
            this.spxlabel.Name = "spxlabel";
            this.spxlabel.Size = new System.Drawing.Size(57, 13);
            this.spxlabel.TabIndex = 20;
            this.spxlabel.Text = "Speed [X]:";
            // 
            // speedHBox
            // 
            this.speedHBox.DecimalPlaces = 2;
            this.speedHBox.Location = new System.Drawing.Point(89, 97);
            this.speedHBox.Name = "speedHBox";
            this.speedHBox.Size = new System.Drawing.Size(79, 20);
            this.speedHBox.TabIndex = 19;
            this.speedHBox.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            // 
            // sphlabel
            // 
            this.sphlabel.AutoSize = true;
            this.sphlabel.Location = new System.Drawing.Point(8, 99);
            this.sphlabel.Name = "sphlabel";
            this.sphlabel.Size = new System.Drawing.Size(57, 13);
            this.sphlabel.TabIndex = 18;
            this.sphlabel.Text = "Speed [A]:";
            // 
            // speedMBox
            // 
            this.speedMBox.DecimalPlaces = 2;
            this.speedMBox.Location = new System.Drawing.Point(89, 71);
            this.speedMBox.Name = "speedMBox";
            this.speedMBox.Size = new System.Drawing.Size(79, 20);
            this.speedMBox.TabIndex = 17;
            this.speedMBox.Value = new decimal(new int[] {
            77,
            0,
            0,
            131072});
            // 
            // spmlabel
            // 
            this.spmlabel.AutoSize = true;
            this.spmlabel.Location = new System.Drawing.Point(8, 73);
            this.spmlabel.Name = "spmlabel";
            this.spmlabel.Size = new System.Drawing.Size(58, 13);
            this.spmlabel.TabIndex = 16;
            this.spmlabel.Text = "Speed [N]:";
            // 
            // speedEBox
            // 
            this.speedEBox.DecimalPlaces = 2;
            this.speedEBox.Location = new System.Drawing.Point(89, 45);
            this.speedEBox.Name = "speedEBox";
            this.speedEBox.Size = new System.Drawing.Size(79, 20);
            this.speedEBox.TabIndex = 15;
            this.speedEBox.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // spelabel
            // 
            this.spelabel.AutoSize = true;
            this.spelabel.Location = new System.Drawing.Point(8, 47);
            this.spelabel.Name = "spelabel";
            this.spelabel.Size = new System.Drawing.Size(57, 13);
            this.spelabel.TabIndex = 14;
            this.spelabel.Text = "Speed [C]:";
            // 
            // speedBBox
            // 
            this.speedBBox.DecimalPlaces = 2;
            this.speedBBox.Location = new System.Drawing.Point(89, 19);
            this.speedBBox.Name = "speedBBox";
            this.speedBBox.Size = new System.Drawing.Size(79, 20);
            this.speedBBox.TabIndex = 13;
            this.speedBBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // spblabel
            // 
            this.spblabel.AutoSize = true;
            this.spblabel.Location = new System.Drawing.Point(8, 21);
            this.spblabel.Name = "spblabel";
            this.spblabel.Size = new System.Drawing.Size(57, 13);
            this.spblabel.TabIndex = 12;
            this.spblabel.Text = "Speed [B]:";
            // 
            // applyHyperspeed
            // 
            this.applyHyperspeed.Location = new System.Drawing.Point(130, 166);
            this.applyHyperspeed.Name = "applyHyperspeed";
            this.applyHyperspeed.Size = new System.Drawing.Size(54, 23);
            this.applyHyperspeed.TabIndex = 11;
            this.applyHyperspeed.Text = "Apply";
            this.applyHyperspeed.UseVisualStyleBackColor = true;
            this.applyHyperspeed.Click += new System.EventHandler(this.applyHyperspeed_Click);
            // 
            // irreversibleWarning
            // 
            this.irreversibleWarning.AutoSize = true;
            this.irreversibleWarning.ForeColor = System.Drawing.Color.Red;
            this.irreversibleWarning.Location = new System.Drawing.Point(12, 148);
            this.irreversibleWarning.Name = "irreversibleWarning";
            this.irreversibleWarning.Size = new System.Drawing.Size(160, 13);
            this.irreversibleWarning.TabIndex = 0;
            this.irreversibleWarning.Text = "This change is IRREVERSIBLE!";
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
            // moreSoon
            // 
            this.moreSoon.AutoSize = true;
            this.moreSoon.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.moreSoon.Location = new System.Drawing.Point(278, 196);
            this.moreSoon.Name = "moreSoon";
            this.moreSoon.Size = new System.Drawing.Size(195, 13);
            this.moreSoon.TabIndex = 2;
            this.moreSoon.Text = "More options will be added in the future!";
            // 
            // scoringGroup
            // 
            this.scoringGroup.Controls.Add(this.pointsPerNote);
            this.scoringGroup.Controls.Add(this.pointsPerNoteLabel);
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
            // pointsPerNoteLabel
            // 
            this.pointsPerNoteLabel.AutoSize = true;
            this.pointsPerNoteLabel.Location = new System.Drawing.Point(17, 30);
            this.pointsPerNoteLabel.Name = "pointsPerNoteLabel";
            this.pointsPerNoteLabel.Size = new System.Drawing.Size(84, 13);
            this.pointsPerNoteLabel.TabIndex = 0;
            this.pointsPerNoteLabel.Text = "Points Per Note:";
            // 
            // multiplierGroup
            // 
            this.multiplierGroup.Controls.Add(this.notesPerMultiplier);
            this.multiplierGroup.Controls.Add(this.notesPerLevelLabel);
            this.multiplierGroup.Controls.Add(this.maximumMultiplierLabel);
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
            // notesPerLevelLabel
            // 
            this.notesPerLevelLabel.AutoSize = true;
            this.notesPerLevelLabel.Location = new System.Drawing.Point(17, 59);
            this.notesPerLevelLabel.Name = "notesPerLevelLabel";
            this.notesPerLevelLabel.Size = new System.Drawing.Size(86, 13);
            this.notesPerLevelLabel.TabIndex = 2;
            this.notesPerLevelLabel.Text = "Notes Per Level:";
            // 
            // maximumMultiplierLabel
            // 
            this.maximumMultiplierLabel.AutoSize = true;
            this.maximumMultiplierLabel.Location = new System.Drawing.Point(17, 26);
            this.maximumMultiplierLabel.Name = "maximumMultiplierLabel";
            this.maximumMultiplierLabel.Size = new System.Drawing.Size(98, 13);
            this.maximumMultiplierLabel.TabIndex = 1;
            this.maximumMultiplierLabel.Text = "Maximum Multiplier:";
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
            this.gameToolStripMenuItem,
            this.saveStrip,
            this.tracksStrip,
            this.songlistToolStripMenuItem,
            this.aboutStrip});
            this.controlStrip.Location = new System.Drawing.Point(0, 0);
            this.controlStrip.Name = "controlStrip";
            this.controlStrip.Size = new System.Drawing.Size(549, 24);
            this.controlStrip.TabIndex = 2;
            this.controlStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGameFileToolStripMenuItem,
            this.launchInRPCS3ToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // openGameFileToolStripMenuItem
            // 
            this.openGameFileToolStripMenuItem.Name = "openGameFileToolStripMenuItem";
            this.openGameFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openGameFileToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openGameFileToolStripMenuItem.Text = "Open Game Files ...";
            this.openGameFileToolStripMenuItem.Click += new System.EventHandler(this.openGameFileToolStripMenuItem_Click);
            // 
            // launchInRPCS3ToolStripMenuItem
            // 
            this.launchInRPCS3ToolStripMenuItem.Enabled = false;
            this.launchInRPCS3ToolStripMenuItem.Name = "launchInRPCS3ToolStripMenuItem";
            this.launchInRPCS3ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.launchInRPCS3ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.launchInRPCS3ToolStripMenuItem.Text = "Launch in RPCS3";
            this.launchInRPCS3ToolStripMenuItem.Click += new System.EventHandler(this.launchInRPCS3ToolStripMenuItem_Click);
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
            this.buildXMLItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.buildXMLItem.Size = new System.Drawing.Size(246, 22);
            this.buildXMLItem.Text = "Build Setlists/Tracklisting";
            this.buildXMLItem.Click += new System.EventHandler(this.buildXMLItem_Click);
            // 
            // saveModsItem
            // 
            this.saveModsItem.Name = "saveModsItem";
            this.saveModsItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveModsItem.Size = new System.Drawing.Size(246, 22);
            this.saveModsItem.Text = "Save Modifications";
            this.saveModsItem.Click += new System.EventHandler(this.saveModsItem_Click);
            // 
            // tracksStrip
            // 
            this.tracksStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadTracksItem,
            this.importTracksItem,
            this.toolStripSeparator1,
            this.disableVideosItem,
            this.disableAllVideosItem,
            this.enableCustomVIdeosToolStripMenuItem});
            this.tracksStrip.Name = "tracksStrip";
            this.tracksStrip.Size = new System.Drawing.Size(52, 20);
            this.tracksStrip.Text = "Tracks";
            // 
            // downloadTracksItem
            // 
            this.downloadTracksItem.Enabled = false;
            this.downloadTracksItem.Name = "downloadTracksItem";
            this.downloadTracksItem.Size = new System.Drawing.Size(192, 22);
            this.downloadTracksItem.Text = "Download Tracks";
            // 
            // importTracksItem
            // 
            this.importTracksItem.Name = "importTracksItem";
            this.importTracksItem.Size = new System.Drawing.Size(192, 22);
            this.importTracksItem.Text = "Import Tracks";
            this.importTracksItem.Click += new System.EventHandler(this.importTracksItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // disableVideosItem
            // 
            this.disableVideosItem.Name = "disableVideosItem";
            this.disableVideosItem.Size = new System.Drawing.Size(192, 22);
            this.disableVideosItem.Text = "Disable Stock Videos";
            this.disableVideosItem.Click += new System.EventHandler(this.disableVideosItem_Click);
            // 
            // disableAllVideosItem
            // 
            this.disableAllVideosItem.Name = "disableAllVideosItem";
            this.disableAllVideosItem.Size = new System.Drawing.Size(192, 22);
            this.disableAllVideosItem.Text = "Disable All Videos";
            this.disableAllVideosItem.Click += new System.EventHandler(this.disableAllVideosItem_Click);
            // 
            // enableCustomVIdeosToolStripMenuItem
            // 
            this.enableCustomVIdeosToolStripMenuItem.Name = "enableCustomVIdeosToolStripMenuItem";
            this.enableCustomVIdeosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.enableCustomVIdeosToolStripMenuItem.Text = "Enable Custom Videos";
            this.enableCustomVIdeosToolStripMenuItem.Click += new System.EventHandler(this.enableCustomVIdeosToolStripMenuItem_Click);
            // 
            // songlistToolStripMenuItem
            // 
            this.songlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCSVToolStripMenuItem,
            this.exportCSVToolStripMenuItem,
            this.toolStripSeparator2,
            this.randomizeSonglistToolStripMenuItem});
            this.songlistToolStripMenuItem.Name = "songlistToolStripMenuItem";
            this.songlistToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.songlistToolStripMenuItem.Text = "Songlist";
            // 
            // importCSVToolStripMenuItem
            // 
            this.importCSVToolStripMenuItem.Name = "importCSVToolStripMenuItem";
            this.importCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importCSVToolStripMenuItem.Text = "Import Songlist CSV";
            this.importCSVToolStripMenuItem.Click += new System.EventHandler(this.importCSVToolStripMenuItem_Click);
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportCSVToolStripMenuItem.Text = "Export Songlist CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // randomizeSonglistToolStripMenuItem
            // 
            this.randomizeSonglistToolStripMenuItem.Name = "randomizeSonglistToolStripMenuItem";
            this.randomizeSonglistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.randomizeSonglistToolStripMenuItem.Text = "Randomize Songlist";
            this.randomizeSonglistToolStripMenuItem.ToolTipText = "Randomize up to 50 songs";
            this.randomizeSonglistToolStripMenuItem.Click += new System.EventHandler(this.randomizeSonglistToolStripMenuItem_Click);
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
            // saveCSVDialog
            // 
            this.saveCSVDialog.FileName = "songs";
            this.saveCSVDialog.Filter = "CSV file|*.csv|All files|*.*";
            this.saveCSVDialog.Title = "Export Songlist CSV";
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
            this.contextMenuStripActiveList.ResumeLayout(false);
            this.activeControls.ResumeLayout(false);
            this.activeControls.PerformLayout();
            this.gameHacks.ResumeLayout(false);
            this.gameHacks.PerformLayout();
            this.batchHyperspeed.ResumeLayout(false);
            this.batchHyperspeed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedXBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedHBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedMBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedEBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBBox)).EndInit();
            this.gameStartupConfig.ResumeLayout(false);
            this.gameStartupConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hmm)).EndInit();
            this.scoringGroup.ResumeLayout(false);
            this.scoringGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPerNote)).EndInit();
            this.multiplierGroup.ResumeLayout(false);
            this.multiplierGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesPerMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximumMultiplier)).EndInit();
            this.controlStrip.ResumeLayout(false);
            this.controlStrip.PerformLayout();
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
        private System.Windows.Forms.Label pointsPerNoteLabel;
        private System.Windows.Forms.GroupBox multiplierGroup;
        private System.Windows.Forms.NumericUpDown notesPerMultiplier;
        private System.Windows.Forms.Label notesPerLevelLabel;
        private System.Windows.Forms.Label maximumMultiplierLabel;
        private System.Windows.Forms.NumericUpDown maximumMultiplier;
        private System.Windows.Forms.PictureBox hmm;
        private System.Windows.Forms.Button defaultMods;
        private System.Windows.Forms.Button reloadGameMods;
        private System.Windows.Forms.Label moreSoon;
        private System.Windows.Forms.NumericUpDown pointsPerNote;
        private System.Windows.Forms.Button GHTVMaxUpgrades;
        private System.Windows.Forms.OpenFileDialog ImportSongDialog;
        private System.Windows.Forms.ToolStripMenuItem fuckYouActivision;
        private System.Windows.Forms.GroupBox gameStartupConfig;
        private System.Windows.Forms.CheckBox showFSGSplash;
        private System.Windows.Forms.CheckBox showActiSplash;
        private System.Windows.Forms.GroupBox batchHyperspeed;
        private System.Windows.Forms.Label irreversibleWarning;
        private System.Windows.Forms.Button applyHyperspeed;
        private System.Windows.Forms.NumericUpDown speedXBox;
        private System.Windows.Forms.Label spxlabel;
        private System.Windows.Forms.NumericUpDown speedHBox;
        private System.Windows.Forms.Label sphlabel;
        private System.Windows.Forms.NumericUpDown speedMBox;
        private System.Windows.Forms.Label spmlabel;
        private System.Windows.Forms.NumericUpDown speedEBox;
        private System.Windows.Forms.Label spelabel;
        private System.Windows.Forms.NumericUpDown speedBBox;
        private System.Windows.Forms.Label spblabel;
        private System.Windows.Forms.SaveFileDialog saveCSVDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem disableVideosItem;
        private System.Windows.Forms.ToolStripMenuItem disableAllVideosItem;
        private System.Windows.Forms.ToolStripMenuItem enableCustomVIdeosToolStripMenuItem;
        private System.Windows.Forms.CheckBox noteStreakFix;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripActiveList;
        private System.Windows.Forms.ToolStripMenuItem removeFromQuickplayToolStripMenuItem;
        private System.Windows.Forms.Label trackCountLabel;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchInRPCS3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomizeSonglistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

