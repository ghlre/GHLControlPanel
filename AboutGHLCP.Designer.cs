namespace GHLCP
{
    partial class AboutGHLCP
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
            this.ghlControlPanel = new System.Windows.Forms.Label();
            this.ghlCpVersion = new System.Windows.Forms.Label();
            this.dby = new System.Windows.Forms.Label();
            this.developedByLabel = new System.Windows.Forms.Label();
            this.pleaseContribute = new System.Windows.Forms.LinkLabel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ghlControlPanel
            // 
            this.ghlControlPanel.AutoSize = true;
            this.ghlControlPanel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghlControlPanel.Location = new System.Drawing.Point(228, 19);
            this.ghlControlPanel.Name = "ghlControlPanel";
            this.ghlControlPanel.Size = new System.Drawing.Size(301, 28);
            this.ghlControlPanel.TabIndex = 1;
            this.ghlControlPanel.Text = "Guitar Hero Live Control Panel";
            // 
            // ghlCpVersion
            // 
            this.ghlCpVersion.AutoSize = true;
            this.ghlCpVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghlCpVersion.Location = new System.Drawing.Point(230, 47);
            this.ghlCpVersion.Name = "ghlCpVersion";
            this.ghlCpVersion.Size = new System.Drawing.Size(91, 15);
            this.ghlCpVersion.TabIndex = 2;
            this.ghlCpVersion.Text = "version 0.1-beta";
            // 
            // dby
            // 
            this.dby.AutoSize = true;
            this.dby.Location = new System.Drawing.Point(254, 85);
            this.dby.Name = "dby";
            this.dby.Size = new System.Drawing.Size(76, 13);
            this.dby.TabIndex = 3;
            this.dby.Text = "Developed by:";
            // 
            // developedByLabel
            // 
            this.developedByLabel.AutoSize = true;
            this.developedByLabel.Location = new System.Drawing.Point(336, 85);
            this.developedByLabel.Name = "developedByLabel";
            this.developedByLabel.Size = new System.Drawing.Size(88, 13);
            this.developedByLabel.TabIndex = 4;
            this.developedByLabel.Text = "InvoxiPlayGames";
            // 
            // pleaseContribute
            // 
            this.pleaseContribute.AutoSize = true;
            this.pleaseContribute.Location = new System.Drawing.Point(230, 191);
            this.pleaseContribute.Name = "pleaseContribute";
            this.pleaseContribute.Size = new System.Drawing.Size(240, 13);
            this.pleaseContribute.TabIndex = 5;
            this.pleaseContribute.TabStop = true;
            this.pleaseContribute.Text = "Source available on GitHub - put your name here!";
            this.pleaseContribute.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pleaseContribute_LinkClicked);
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.Transparent;
            this.logoBox.Image = global::GHLCP.Properties.Resources.GHLCP;
            this.logoBox.Location = new System.Drawing.Point(12, 12);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(200, 200);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // AboutGHLCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 228);
            this.Controls.Add(this.pleaseContribute);
            this.Controls.Add(this.developedByLabel);
            this.Controls.Add(this.dby);
            this.Controls.Add(this.ghlCpVersion);
            this.Controls.Add(this.ghlControlPanel);
            this.Controls.Add(this.logoBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutGHLCP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Guitar Hero Live Control Panel";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label ghlControlPanel;
        private System.Windows.Forms.Label ghlCpVersion;
        private System.Windows.Forms.Label dby;
        private System.Windows.Forms.Label developedByLabel;
        private System.Windows.Forms.LinkLabel pleaseContribute;
    }
}