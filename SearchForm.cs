using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class SearchForm : Form
    {
        private IEnumerable<Trackconfig> result;

        public SearchForm(IEnumerable<Trackconfig> tracks)
        {
            InitializeComponent();
            result = tracks;

            cmbId.Items.AddRange(result.Select(track => track.Id).ToArray());
            cmbTrackname.Items.AddRange(result.Select(track => track.Trackname).Distinct().ToArray());
            cmbArtist.Items.AddRange(result.Select(track => track.Artist).Distinct().ToArray());
            cmbIntensity.Items.AddRange(result.Select(track => track.Intensity.ToString()).Distinct().ToArray());
        }

        public IEnumerable<Trackconfig> Result { get => result; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbId.Text.Length > 0)
                result = result.Where(track => track.Id.ToLower().Contains(cmbId.Text.ToLower()));

            if (cmbTrackname.Text.Length > 0)
                result = result.Where(track => track.Trackname.ToLower().Contains(cmbTrackname.Text.ToLower()));

            if (cmbArtist.Text.Length > 0)
                result = result.Where(track => track.Artist.ToLower().Contains(cmbArtist.Text.ToLower()));

            if (cmbIntensity.Text.Length > 0)
                result = result.Where(track => track.Intensity.ToString() == cmbIntensity.Text);

            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
