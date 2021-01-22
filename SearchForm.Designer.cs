namespace GHLCP
{
    partial class SearchForm
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
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labId = new System.Windows.Forms.Label();
            this.cmbId = new System.Windows.Forms.ComboBox();
            this.cmbTrackname = new System.Windows.Forms.ComboBox();
            this.labTrackname = new System.Windows.Forms.Label();
            this.cmbIntensity = new System.Windows.Forms.ComboBox();
            this.labIntensity = new System.Windows.Forms.Label();
            this.cmbArtist = new System.Windows.Forms.ComboBox();
            this.labArtist = new System.Windows.Forms.Label();
            this.flowOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowOptions
            // 
            this.flowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowOptions.Controls.Add(this.btnSearch);
            this.flowOptions.Controls.Add(this.btnCancel);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowOptions.Location = new System.Drawing.Point(12, 196);
            this.flowOptions.Name = "flowOptions";
            this.flowOptions.Size = new System.Drawing.Size(288, 28);
            this.flowOptions.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(210, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(129, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labId
            // 
            this.labId.AutoSize = true;
            this.labId.Location = new System.Drawing.Point(12, 9);
            this.labId.Name = "labId";
            this.labId.Size = new System.Drawing.Size(16, 13);
            this.labId.TabIndex = 5;
            this.labId.Text = "Id";
            // 
            // cmbId
            // 
            this.cmbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbId.FormattingEnabled = true;
            this.cmbId.Location = new System.Drawing.Point(13, 26);
            this.cmbId.Name = "cmbId";
            this.cmbId.Size = new System.Drawing.Size(287, 21);
            this.cmbId.Sorted = true;
            this.cmbId.TabIndex = 0;
            // 
            // cmbTrackname
            // 
            this.cmbTrackname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTrackname.FormattingEnabled = true;
            this.cmbTrackname.Location = new System.Drawing.Point(13, 70);
            this.cmbTrackname.Name = "cmbTrackname";
            this.cmbTrackname.Size = new System.Drawing.Size(287, 21);
            this.cmbTrackname.Sorted = true;
            this.cmbTrackname.TabIndex = 1;
            // 
            // labTrackname
            // 
            this.labTrackname.AutoSize = true;
            this.labTrackname.Location = new System.Drawing.Point(12, 53);
            this.labTrackname.Name = "labTrackname";
            this.labTrackname.Size = new System.Drawing.Size(61, 13);
            this.labTrackname.TabIndex = 9;
            this.labTrackname.Text = "Trackname";
            // 
            // cmbIntensity
            // 
            this.cmbIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIntensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIntensity.FormattingEnabled = true;
            this.cmbIntensity.Location = new System.Drawing.Point(13, 157);
            this.cmbIntensity.Name = "cmbIntensity";
            this.cmbIntensity.Size = new System.Drawing.Size(287, 21);
            this.cmbIntensity.Sorted = true;
            this.cmbIntensity.TabIndex = 3;
            // 
            // labIntensity
            // 
            this.labIntensity.AutoSize = true;
            this.labIntensity.Location = new System.Drawing.Point(12, 140);
            this.labIntensity.Name = "labIntensity";
            this.labIntensity.Size = new System.Drawing.Size(46, 13);
            this.labIntensity.TabIndex = 13;
            this.labIntensity.Text = "Intensity";
            // 
            // cmbArtist
            // 
            this.cmbArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbArtist.FormattingEnabled = true;
            this.cmbArtist.Location = new System.Drawing.Point(13, 111);
            this.cmbArtist.Name = "cmbArtist";
            this.cmbArtist.Size = new System.Drawing.Size(287, 21);
            this.cmbArtist.Sorted = true;
            this.cmbArtist.TabIndex = 2;
            // 
            // labArtist
            // 
            this.labArtist.AutoSize = true;
            this.labArtist.Location = new System.Drawing.Point(12, 94);
            this.labArtist.Name = "labArtist";
            this.labArtist.Size = new System.Drawing.Size(30, 13);
            this.labArtist.TabIndex = 11;
            this.labArtist.Text = "Artist";
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 236);
            this.Controls.Add(this.cmbIntensity);
            this.Controls.Add(this.labIntensity);
            this.Controls.Add(this.cmbArtist);
            this.Controls.Add(this.labArtist);
            this.Controls.Add(this.cmbTrackname);
            this.Controls.Add(this.labTrackname);
            this.Controls.Add(this.cmbId);
            this.Controls.Add(this.flowOptions);
            this.Controls.Add(this.labId);
            this.MinimumSize = new System.Drawing.Size(328, 275);
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.Text = "Search";
            this.flowOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowOptions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labId;
        private System.Windows.Forms.ComboBox cmbId;
        private System.Windows.Forms.ComboBox cmbTrackname;
        private System.Windows.Forms.Label labTrackname;
        private System.Windows.Forms.ComboBox cmbIntensity;
        private System.Windows.Forms.Label labIntensity;
        private System.Windows.Forms.ComboBox cmbArtist;
        private System.Windows.Forms.Label labArtist;
    }
}