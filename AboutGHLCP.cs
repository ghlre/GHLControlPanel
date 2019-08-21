using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class AboutGHLCP : Form
    {
        public AboutGHLCP()
        {
            InitializeComponent();
        }

        private void pleaseContribute_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/ghlre/GHLControlPanel");
        }
    }
}
