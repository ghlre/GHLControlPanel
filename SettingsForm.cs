using System;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            chbImportVideo.Checked = Properties.Settings.Default.importVideo;
            chbImportParent.Checked = Properties.Settings.Default.importParent;
            txtRPCS3exe.Text = Properties.Settings.Default.rpcs3Exe;
        }

        private void btnRPCS3exe_Click(object sender, EventArgs e)
        {
            OpenFileDialog rpcs3exeDialog = new OpenFileDialog
            {
                Title = "Open RPCS3 executable",
                Filter = "RPCS3 executable|rpcs3.exe",
                FileName = txtRPCS3exe.Text
            };

            if (rpcs3exeDialog.ShowDialog() == DialogResult.OK)
            {
                txtRPCS3exe.Text = rpcs3exeDialog.FileName;
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            chbImportVideo.Checked = true;
            chbImportParent.Checked = false;
            txtRPCS3exe.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.importVideo = chbImportVideo.Checked;
            Properties.Settings.Default.importParent = chbImportParent.Checked;
            Properties.Settings.Default.rpcs3Exe = txtRPCS3exe.Text;

            Properties.Settings.Default.Save();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
