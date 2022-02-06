namespace GHLCP
{
    partial class OpenForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.labLocal = new System.Windows.Forms.Label();
            this.groupLocal = new System.Windows.Forms.GroupBox();
            this.btnLocalClear = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.groupFtp = new System.Windows.Forms.GroupBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.labFtpPassword = new System.Windows.Forms.Label();
            this.txtFtpUsername = new System.Windows.Forms.TextBox();
            this.labFtpUsername = new System.Windows.Forms.Label();
            this.btnFtpClear = new System.Windows.Forms.Button();
            this.btnFtp = new System.Windows.Forms.Button();
            this.txtFtpUri = new System.Windows.Forms.TextBox();
            this.labFtpUri = new System.Windows.Forms.Label();
            this.GameFinderDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupLocal.SuspendLayout();
            this.groupFtp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(411, 44);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(120, 28);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLocal
            // 
            this.txtLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocal.Location = new System.Drawing.Point(16, 48);
            this.txtLocal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(385, 22);
            this.txtLocal.TabIndex = 0;
            // 
            // labLocal
            // 
            this.labLocal.AutoSize = true;
            this.labLocal.Location = new System.Drawing.Point(16, 27);
            this.labLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labLocal.Name = "labLocal";
            this.labLocal.Size = new System.Drawing.Size(135, 17);
            this.labLocal.TabIndex = 4;
            this.labLocal.Text = "Extracted game files";
            // 
            // groupLocal
            // 
            this.groupLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupLocal.Controls.Add(this.btnLocalClear);
            this.groupLocal.Controls.Add(this.btnLocal);
            this.groupLocal.Controls.Add(this.txtLocal);
            this.groupLocal.Controls.Add(this.btnBrowse);
            this.groupLocal.Controls.Add(this.labLocal);
            this.groupLocal.Location = new System.Drawing.Point(17, 16);
            this.groupLocal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupLocal.Name = "groupLocal";
            this.groupLocal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupLocal.Size = new System.Drawing.Size(539, 122);
            this.groupLocal.TabIndex = 7;
            this.groupLocal.TabStop = false;
            this.groupLocal.Text = "Local";
            // 
            // btnLocalClear
            // 
            this.btnLocalClear.Location = new System.Drawing.Point(124, 81);
            this.btnLocalClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLocalClear.Name = "btnLocalClear";
            this.btnLocalClear.Size = new System.Drawing.Size(100, 28);
            this.btnLocalClear.TabIndex = 3;
            this.btnLocalClear.Text = "Clear";
            this.btnLocalClear.UseVisualStyleBackColor = true;
            this.btnLocalClear.Click += new System.EventHandler(this.btnLocalClear_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(16, 81);
            this.btnLocal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(100, 28);
            this.btnLocal.TabIndex = 2;
            this.btnLocal.Text = "Confirm";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // groupFtp
            // 
            this.groupFtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFtp.Controls.Add(this.txtFtpPassword);
            this.groupFtp.Controls.Add(this.labFtpPassword);
            this.groupFtp.Controls.Add(this.txtFtpUsername);
            this.groupFtp.Controls.Add(this.labFtpUsername);
            this.groupFtp.Controls.Add(this.btnFtpClear);
            this.groupFtp.Controls.Add(this.btnFtp);
            this.groupFtp.Controls.Add(this.txtFtpUri);
            this.groupFtp.Controls.Add(this.labFtpUri);
            this.groupFtp.Location = new System.Drawing.Point(17, 158);
            this.groupFtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupFtp.Name = "groupFtp";
            this.groupFtp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupFtp.Size = new System.Drawing.Size(539, 236);
            this.groupFtp.TabIndex = 8;
            this.groupFtp.TabStop = false;
            this.groupFtp.Text = "FTP";
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpPassword.Location = new System.Drawing.Point(12, 153);
            this.txtFtpPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(513, 22);
            this.txtFtpPassword.TabIndex = 6;
            this.txtFtpPassword.UseSystemPasswordChar = true;
            // 
            // labFtpPassword
            // 
            this.labFtpPassword.AutoSize = true;
            this.labFtpPassword.Location = new System.Drawing.Point(12, 132);
            this.labFtpPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFtpPassword.Name = "labFtpPassword";
            this.labFtpPassword.Size = new System.Drawing.Size(98, 17);
            this.labFtpPassword.TabIndex = 11;
            this.labFtpPassword.Text = "FTP password";
            // 
            // txtFtpUsername
            // 
            this.txtFtpUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpUsername.Location = new System.Drawing.Point(12, 98);
            this.txtFtpUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFtpUsername.Name = "txtFtpUsername";
            this.txtFtpUsername.Size = new System.Drawing.Size(513, 22);
            this.txtFtpUsername.TabIndex = 5;
            // 
            // labFtpUsername
            // 
            this.labFtpUsername.AutoSize = true;
            this.labFtpUsername.Location = new System.Drawing.Point(12, 78);
            this.labFtpUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFtpUsername.Name = "labFtpUsername";
            this.labFtpUsername.Size = new System.Drawing.Size(101, 17);
            this.labFtpUsername.TabIndex = 9;
            this.labFtpUsername.Text = "FTP username";
            // 
            // btnFtpClear
            // 
            this.btnFtpClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFtpClear.Location = new System.Drawing.Point(124, 196);
            this.btnFtpClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFtpClear.Name = "btnFtpClear";
            this.btnFtpClear.Size = new System.Drawing.Size(100, 28);
            this.btnFtpClear.TabIndex = 8;
            this.btnFtpClear.Text = "Clear";
            this.btnFtpClear.UseVisualStyleBackColor = true;
            this.btnFtpClear.Click += new System.EventHandler(this.btnFtpClear_Click);
            // 
            // btnFtp
            // 
            this.btnFtp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFtp.Location = new System.Drawing.Point(16, 196);
            this.btnFtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFtp.Name = "btnFtp";
            this.btnFtp.Size = new System.Drawing.Size(100, 28);
            this.btnFtp.TabIndex = 7;
            this.btnFtp.Text = "Confirm";
            this.btnFtp.UseVisualStyleBackColor = true;
            this.btnFtp.Click += new System.EventHandler(this.btnFtp_Click);
            // 
            // txtFtpUri
            // 
            this.txtFtpUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpUri.Location = new System.Drawing.Point(12, 47);
            this.txtFtpUri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFtpUri.Name = "txtFtpUri";
            this.txtFtpUri.Size = new System.Drawing.Size(513, 22);
            this.txtFtpUri.TabIndex = 4;
            // 
            // labFtpUri
            // 
            this.labFtpUri.AutoSize = true;
            this.labFtpUri.Location = new System.Drawing.Point(16, 27);
            this.labFtpUri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFtpUri.Name = "labFtpUri";
            this.labFtpUri.Size = new System.Drawing.Size(61, 17);
            this.labFtpUri.TabIndex = 4;
            this.labFtpUri.Text = "FTP URI";
            // 
            // GameFinderDialog
            // 
            this.GameFinderDialog.Filter = "Wii U|GHLive.rpx|PlayStation 3|EBOOT.BIN|Xbox 360|default.xex|iOS|GHLive";
            this.GameFinderDialog.Title = "GHL Installation Files";
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 411);
            this.Controls.Add(this.groupFtp);
            this.Controls.Add(this.groupLocal);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(586, 448);
            this.Name = "OpenForm";
            this.ShowIcon = false;
            this.Text = "Open Game Files";
            this.groupLocal.ResumeLayout(false);
            this.groupLocal.PerformLayout();
            this.groupFtp.ResumeLayout(false);
            this.groupFtp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label labLocal;
        private System.Windows.Forms.GroupBox groupLocal;
        private System.Windows.Forms.Button btnLocalClear;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.GroupBox groupFtp;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.Label labFtpPassword;
        private System.Windows.Forms.TextBox txtFtpUsername;
        private System.Windows.Forms.Label labFtpUsername;
        private System.Windows.Forms.Button btnFtpClear;
        private System.Windows.Forms.Button btnFtp;
        private System.Windows.Forms.TextBox txtFtpUri;
        private System.Windows.Forms.Label labFtpUri;
        private System.Windows.Forms.OpenFileDialog GameFinderDialog;
    }
}