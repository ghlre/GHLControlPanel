using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class WaitingForm : Form
    {
        private readonly Gamedir gamedir;
        private readonly string[] filenames;

        public WaitingForm(Gamedir gamedir, string[] filenames)
        {
            InitializeComponent();
            this.gamedir = gamedir;
            this.filenames = filenames;

            importProgressBar.Maximum = filenames.Length;
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            UpdateStatusLabel();
            importBackgroundWorker.RunWorkerAsync();
        }

        private void importBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            gamedir.ImportProgressChanged += gamedir_ImportProgressChanged;

            foreach (string file in filenames)
            {
                if (importBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                gamedir.HandleImport(file);
                importBackgroundWorker.ReportProgress(1);
            }
        }

        private void importBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ImportProgressChangedEventArgs progress)
            {
                progressLabel.Text = progress.Message;
            } else
            {
                importProgressBar.Value += e.ProgressPercentage;
                UpdateStatusLabel();
            }
        }

        private void importBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gamedir.ImportProgressChanged -= gamedir_ImportProgressChanged;

            if (e.Cancelled)
            {
                statusLabel.Text = "Track import canceled";
                statusLabel.ForeColor = Color.Red;
            } else if (e.Error != null)
            {
                statusLabel.Text = e.Error is InvalidOperationException ? e.Error.Message : "An unknown error occurred while importing " + Path.GetFileName(filenames[importProgressBar.Value]);
                statusLabel.ForeColor = Color.Red;
            } else
            {
                statusLabel.Text = "Track import completed";
                statusLabel.ForeColor = Color.Green;
            }

            progressLabel.Text = "";
            cancelButton.Enabled = true;
            cancelButton.Text = "Close";
        }

        private void gamedir_ImportProgressChanged(object sender, ImportProgressChangedEventArgs e)
        {
            importBackgroundWorker.ReportProgress(0, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (importBackgroundWorker.IsBusy)
            {
                importBackgroundWorker.CancelAsync();
            } else
            {
                Close();
            }

            cancelButton.Enabled = false;
        }

        private void UpdateStatusLabel()
        {
            if (importProgressBar.Value < filenames.Length)
            {
                statusLabel.Text = $"Importing : {Path.GetFileName(filenames[importProgressBar.Value])}";
            }
        }
    }
}
