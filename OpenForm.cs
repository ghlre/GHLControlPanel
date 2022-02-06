using GHLCP.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class OpenForm : Form
    {
        private Gamedir result;

        public OpenForm()
        {
            InitializeComponent();
            txtLocal.Text = Properties.Settings.Default.pastFile;
            txtFtpUri.Text = Properties.Settings.Default.pastFtpUri;
            txtFtpUsername.Text = Properties.Settings.Default.pastFtpUsername;
        }

        public OpenForm(string path) : this()
        {
            if (File.Exists(path))
                OpenLocalGameFiles();
        }

        public Gamedir Result { get => result; }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            GameFinderDialog.FileName = txtLocal.Text;

            if (GameFinderDialog.ShowDialog() == DialogResult.OK)
            {
                txtLocal.Text = GameFinderDialog.FileName;
                OpenLocalGameFiles();
            }
        }

        private void btnLocal_Click(object sender, EventArgs e) => OpenLocalGameFiles();

        private void btnFtp_Click(object sender, EventArgs e)
        {
            try
            {
                FtpGamedirFactory gamedirFactory = new FtpGamedirFactory(txtFtpUri.Text, txtFtpUsername.Text, txtFtpPassword.Text);
                bool open = OpenGameFiles(gamedirFactory);

                if (open)
                {
                    Properties.Settings.Default.pastFtpUri = txtFtpUri.Text;
                    Properties.Settings.Default.pastFtpUsername = txtFtpUsername.Text;
                    Properties.Settings.Default.Save();
                }
            } catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Instance.Error(ex.Message);
            }
        }

        private bool OpenLocalGameFiles()
        {
            LocalGamedirFactory gamedirFactory = new LocalGamedirFactory(txtLocal.Text);
            bool open = OpenGameFiles(gamedirFactory);

            if (open)
            {
                Properties.Settings.Default.pastFile = txtLocal.Text;
                Properties.Settings.Default.initialDirectory = result.ToString();
                Properties.Settings.Default.Save();
            }

            return open;
        }

        private bool OpenGameFiles(GamedirFactory gamedirFactory)
        {
            Gamedir gamedir;

            try
            {
                gamedir = gamedirFactory.Get();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Instance.Error(ex.Message);
                return false;
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Instance.Error(ex.Message);
                return false;
            }

            if (!gamedir.FileManager.FileExists(gamedir.GetPath("/Audio/AudioTracks/Setlists.xml")))
            {
                MessageBox.Show("This copy of the game is not extracted correctly (or is not GHL at all!). Please extract the game and try again.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (gamedir.FileManager.FileExists(gamedir.GetPath("/FAR/DiscOnly/GameBoot.far")))
            {
                MessageBox.Show("\"gameboot.far\" exists in your GHL install directory. GHLCP will now remove this to enable custom tracks to appear in the quickplay menu.", "Guitar Hero Live Control Panel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gamedir.FileManager.Delete(gamedir.GetPath("/FAR/DiscOnly/GameBoot.far"));
                return false;
            }

            result = gamedir;
            DialogResult = DialogResult.OK;
            return true;
        }

        private void btnLocalClear_Click(object sender, EventArgs e)
        {
            txtLocal.Text = string.Empty;
        }

        private void btnFtpClear_Click(object sender, EventArgs e)
        {
            txtFtpUri.Text = string.Empty;
            txtFtpUsername.Text = string.Empty;
            txtFtpPassword.Text = string.Empty;
        }
    }
}
