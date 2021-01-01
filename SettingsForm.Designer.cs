namespace GHLCP
{
    partial class SettingsForm
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
            this.groupPreferences = new System.Windows.Forms.GroupBox();
            this.chbImportParent = new System.Windows.Forms.CheckBox();
            this.chbImportVideo = new System.Windows.Forms.CheckBox();
            this.labRPCS3exe = new System.Windows.Forms.Label();
            this.txtRPCS3exe = new System.Windows.Forms.TextBox();
            this.btnRPCS3exe = new System.Windows.Forms.Button();
            this.flowOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.groupPreferences.SuspendLayout();
            this.flowOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPreferences
            // 
            this.groupPreferences.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPreferences.Controls.Add(this.chbImportParent);
            this.groupPreferences.Controls.Add(this.chbImportVideo);
            this.groupPreferences.Location = new System.Drawing.Point(13, 13);
            this.groupPreferences.Name = "groupPreferences";
            this.groupPreferences.Size = new System.Drawing.Size(385, 72);
            this.groupPreferences.TabIndex = 0;
            this.groupPreferences.TabStop = false;
            this.groupPreferences.Text = "Preferences";
            // 
            // chbImportParent
            // 
            this.chbImportParent.AutoSize = true;
            this.chbImportParent.Location = new System.Drawing.Point(6, 43);
            this.chbImportParent.Name = "chbImportParent";
            this.chbImportParent.Size = new System.Drawing.Size(167, 17);
            this.chbImportParent.TabIndex = 1;
            this.chbImportParent.Text = "Enable parent setlist on import";
            this.chbImportParent.UseVisualStyleBackColor = true;
            // 
            // chbImportVideo
            // 
            this.chbImportVideo.AutoSize = true;
            this.chbImportVideo.Checked = true;
            this.chbImportVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbImportVideo.Location = new System.Drawing.Point(7, 20);
            this.chbImportVideo.Name = "chbImportVideo";
            this.chbImportVideo.Size = new System.Drawing.Size(134, 17);
            this.chbImportVideo.TabIndex = 0;
            this.chbImportVideo.Text = "Enable video on import";
            this.chbImportVideo.UseVisualStyleBackColor = true;
            // 
            // labRPCS3exe
            // 
            this.labRPCS3exe.AutoSize = true;
            this.labRPCS3exe.Location = new System.Drawing.Point(13, 92);
            this.labRPCS3exe.Name = "labRPCS3exe";
            this.labRPCS3exe.Size = new System.Drawing.Size(97, 13);
            this.labRPCS3exe.TabIndex = 1;
            this.labRPCS3exe.Text = "RPCS3 executable";
            // 
            // txtRPCS3exe
            // 
            this.txtRPCS3exe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRPCS3exe.Location = new System.Drawing.Point(13, 109);
            this.txtRPCS3exe.Name = "txtRPCS3exe";
            this.txtRPCS3exe.Size = new System.Drawing.Size(289, 20);
            this.txtRPCS3exe.TabIndex = 2;
            // 
            // btnRPCS3exe
            // 
            this.btnRPCS3exe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRPCS3exe.Location = new System.Drawing.Point(308, 105);
            this.btnRPCS3exe.Name = "btnRPCS3exe";
            this.btnRPCS3exe.Size = new System.Drawing.Size(90, 23);
            this.btnRPCS3exe.TabIndex = 3;
            this.btnRPCS3exe.Text = "Browse";
            this.btnRPCS3exe.UseVisualStyleBackColor = true;
            this.btnRPCS3exe.Click += new System.EventHandler(this.btnRPCS3exe_Click);
            // 
            // flowOptions
            // 
            this.flowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowOptions.Controls.Add(this.btnSave);
            this.flowOptions.Controls.Add(this.btnCancel);
            this.flowOptions.Controls.Add(this.btnDefault);
            this.flowOptions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowOptions.Location = new System.Drawing.Point(12, 144);
            this.flowOptions.Name = "flowOptions";
            this.flowOptions.Size = new System.Drawing.Size(386, 28);
            this.flowOptions.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(308, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(117, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(104, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Reset To Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 184);
            this.Controls.Add(this.flowOptions);
            this.Controls.Add(this.btnRPCS3exe);
            this.Controls.Add(this.txtRPCS3exe);
            this.Controls.Add(this.labRPCS3exe);
            this.Controls.Add(this.groupPreferences);
            this.MinimumSize = new System.Drawing.Size(426, 223);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "Settings";
            this.groupPreferences.ResumeLayout(false);
            this.groupPreferences.PerformLayout();
            this.flowOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPreferences;
        private System.Windows.Forms.CheckBox chbImportParent;
        private System.Windows.Forms.CheckBox chbImportVideo;
        private System.Windows.Forms.Label labRPCS3exe;
        private System.Windows.Forms.TextBox txtRPCS3exe;
        private System.Windows.Forms.Button btnRPCS3exe;
        private System.Windows.Forms.FlowLayoutPanel flowOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefault;
    }
}