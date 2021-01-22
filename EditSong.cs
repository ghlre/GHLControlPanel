using System;
using System.Windows.Forms;

namespace GHLCP
{
    public partial class EditSong : Form
    {
        private readonly Gamedir gamedir;
        private readonly Trackconfig trackconfig;
        private bool dontAlertChanges = false;

        public EditSong(Gamedir gamedir, Trackconfig trackconfig)
        {
            InitializeComponent();
            this.gamedir = gamedir;
            this.trackconfig = trackconfig;
        }

        private void EditSong_Load(object sender, EventArgs e)
        {
            Populate();
        }

        public void Populate()
        {
            dontAlertChanges = true;

            idBox.Text = trackconfig.Id;
            artistBox.Text = trackconfig.Artist;
            tracknameBox.Text = trackconfig.Trackname;
            Text = $"Editing Song: {trackconfig.Artist} - {trackconfig.Trackname} [{trackconfig.Id}]";
            unlockedInGHLBox.Checked = trackconfig.UnlockedInGHLiveByDefault;
            intensityBox.Value = trackconfig.Intensity;

            TrackconfigVideo video = trackconfig.Video;
            videoEnabledCheck.Checked = video.HasVideo;
            videoStartBox.Value = Convert.ToDecimal(video.MusicStartTime);

            TrackconfigStagefright stagefright = trackconfig.Stagefright;
            enableStagefright.Checked = stagefright.Enabled;
            parentSetlistBox.Text = stagefright.ParentSetlist;
            careerStartBox.Value = Convert.ToDecimal(stagefright.TrackStartTime);
            careerEndBox.Value = Convert.ToDecimal(stagefright.TrackEndTime);
            quickStartBox.Value = Convert.ToDecimal(stagefright.QuickplayStartTime);
            quickEndBox.Value = Convert.ToDecimal(stagefright.QuickplayEndTime);

            TrackconfigHighway highway = trackconfig.Highway;
            speedBBox.Value = Convert.ToDecimal(highway.Beginner);
            speedEBox.Value = Convert.ToDecimal(highway.Easy);
            speedMBox.Value = Convert.ToDecimal(highway.Medium);
            speedHBox.Value = Convert.ToDecimal(highway.Hard);
            speedXBox.Value = Convert.ToDecimal(highway.Expert);
            opacityBox.Value = Convert.ToDecimal(highway.Opacity);
            transparencyBox.Value = Convert.ToDecimal(highway.Transparency);

            dontAlertChanges = false;
        }

        private void cancelEdit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void videoEnabledCheck_CheckedChanged(object sender, EventArgs e)
        {
            videoStartBox.Enabled = videoEnabledCheck.Checked;
        }

        private void enableStagefright_CheckedChanged(object sender, EventArgs e)
        {
            if (dontAlertChanges)
            {
                return;
            }
            if (trackconfig.IsDefault)
            {
                DialogResult yeah = MessageBox.Show("Disabling the Stagefright metadata on default songs may cause issues such as the career mode crashing the game. Are you sure you want to do this?", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (yeah)
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        dontAlertChanges = true;
                        enableStagefright.Checked = !enableStagefright.Checked;
                        dontAlertChanges = false;
                        break;
                }
            }
        }

        private void saveTrack_Click(object sender, EventArgs e)
        {
            trackconfig.Artist = artistBox.Text;
            trackconfig.Trackname = tracknameBox.Text;
            trackconfig.UnlockedInGHLiveByDefault = unlockedInGHLBox.Checked;
            trackconfig.Intensity = Convert.ToInt32(intensityBox.Value);

            TrackconfigHighway highway = trackconfig.Highway;
            highway.Beginner = Convert.ToDouble(speedBBox.Value);
            highway.Easy = Convert.ToDouble(speedEBox.Value);
            highway.Medium = Convert.ToDouble(speedMBox.Value);
            highway.Hard = Convert.ToDouble(speedHBox.Value);
            highway.Expert = Convert.ToDouble(speedXBox.Value);
            highway.Opacity = Convert.ToDouble(opacityBox.Value);
            highway.Transparency = Convert.ToDouble(transparencyBox.Value);

            TrackconfigVideo video = trackconfig.Video;
            video.HasVideo = videoEnabledCheck.Checked;
            video.MusicStartTime = Convert.ToDouble(videoStartBox.Value);

            TrackconfigStagefright stagefright = trackconfig.Stagefright;
            stagefright.TrackStartTime = Convert.ToDouble(careerStartBox.Value);
            stagefright.TrackEndTime = Convert.ToDouble(careerEndBox.Value);
            stagefright.QuickplayStartTime = Convert.ToDouble(quickStartBox.Value);
            stagefright.QuickplayEndTime = Convert.ToDouble(quickEndBox.Value);

            gamedir.SetParentSetlist(trackconfig, enableStagefright.Checked, parentSetlistBox.Text);

            gamedir.WriteTrackconfig(trackconfig);

            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
