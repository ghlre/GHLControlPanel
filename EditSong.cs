using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GHLCP
{
    public partial class EditSong : Form
    {
        private readonly MainWindow mainWindow;
        private readonly string id;
        bool dontAlertChanges = false;
        private XmlDocument document;

        public EditSong(MainWindow mainWindow, string id)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.id = id;
        }

        private string boolToXml(bool bolean)
        {
            switch (bolean)
            {
                case true:
                    return "true";
                case false:
                    return "false";
                default:
                    return "false";
            }
        }

        private void EditSong_Load(object sender, EventArgs e)
        {
            Populate(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml");
        }

        public void Populate(string path)
        {
            dontAlertChanges = true;
            XmlDocument document = new XmlDocument();
            document.Load(path);

            // Track generic details
            XmlElement trackconfig = document.DocumentElement;
            idBox.Text = trackconfig.GetAttributeNode("id").InnerText;
            artistBox.Text = trackconfig.GetAttributeNode("artist").InnerText;
            tracknameBox.Text = trackconfig.GetAttributeNode("trackname").InnerText;
            Text = $"Editing Song: {trackconfig.GetAttributeNode("artist").InnerText} - {trackconfig.GetAttributeNode("trackname").InnerText} [{id}]";
            if (trackconfig.HasAttribute("unlockedInGHLiveByDefault"))
            {
                unlockedInGHLBox.Checked = (trackconfig.GetAttributeNode("unlockedInGHLiveByDefault").InnerText.ToLower() == "true");
            }
            if (trackconfig.HasAttribute("intensity"))
            {
                intensityBox.Value = Convert.ToInt32(trackconfig.GetAttributeNode("intensity").InnerText);
            }

            // Video shit
            XmlNode video = document.SelectSingleNode("Track/Video");
            if (video == null)
            {
                videoEnabledCheck.Enabled = false;
                videoStartBox.Enabled = false;
            } else
            {
                if (((XmlElement)video).HasAttribute("hasVideo"))
                {
                    videoEnabledCheck.Checked = (((XmlElement)video).GetAttributeNode("hasVideo").InnerText.ToLower() == "true");
                }
                if (((XmlElement)video).HasAttribute("musicStartTime"))
                {
                    videoStartBox.Value = Convert.ToDecimal(((XmlElement)video).GetAttributeNode("musicStartTime").InnerText, CultureInfo.InvariantCulture);
                }
            }

            // Stagefright shit
            XmlNode stagefright = document.SelectSingleNode("Track/Stagefright");
            if (stagefright == null)
            {
                parentSetlistBox.Enabled = false;
                careerStartBox.Enabled = false;
                careerEndBox.Enabled = false;
                quickEndBox.Enabled = false;
                quickStartBox.Enabled = false;
            } else
            {
                if (((XmlElement)stagefright).HasAttribute("parentSetlist"))
                {
                    enableStagefright.Checked = true;
                    parentSetlistBox.Text = ((XmlElement)stagefright).GetAttributeNode("parentSetlist").InnerText;
                } else if (((XmlElement)stagefright).HasAttribute("parentSetlistDisabled"))
                {
                    enableStagefright.Checked = false;
                    parentSetlistBox.Text = ((XmlElement)stagefright).GetAttributeNode("parentSetlistDisabled").InnerText;
                }
                careerStartBox.Value = Convert.ToDecimal(((XmlElement)stagefright).GetAttributeNode("trackStartTime").InnerText, CultureInfo.InvariantCulture);
                careerEndBox.Value = Convert.ToDecimal(((XmlElement)stagefright).GetAttributeNode("trackEndTime").InnerText, CultureInfo.InvariantCulture);
                quickStartBox.Value = Convert.ToDecimal(((XmlElement)stagefright).GetAttributeNode("quickplayStartTime").InnerText, CultureInfo.InvariantCulture);
                quickEndBox.Value = Convert.ToDecimal(((XmlElement)stagefright).GetAttributeNode("quickplayEndTime").InnerText, CultureInfo.InvariantCulture);
            }

            // Highway shit
            XmlNode highway = document.SelectSingleNode("Track/Highway");
            speedBBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("newbeginner").InnerText, CultureInfo.InvariantCulture);
            speedEBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("neweasy").InnerText, CultureInfo.InvariantCulture);
            speedMBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("newmedium").InnerText, CultureInfo.InvariantCulture);
            speedHBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("newhard").InnerText, CultureInfo.InvariantCulture);
            speedXBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("newexpert").InnerText, CultureInfo.InvariantCulture);
            if (((XmlElement)highway).HasAttribute("highwayOpacityMultiplier"))
            {
                opacityBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("highwayOpacityMultiplier").InnerText, CultureInfo.InvariantCulture);
            } else
            {
                opacityBox.Enabled = false;
            }
            if (((XmlElement)highway).HasAttribute("highwayTransparency"))
            {
                transparencyBox.Value = Convert.ToDecimal(((XmlElement)highway).GetAttributeNode("highwayTransparency").InnerText, CultureInfo.InvariantCulture);
            } else
            {
                transparencyBox.Enabled = false;
            }
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
            if (MainWindow.defaultTracks.Contains(id))
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
            LoadXml();

            // Track generic details
            XmlElement trackconfig = document.DocumentElement;
            trackconfig.SetAttribute("artist", artistBox.Text);
            trackconfig.SetAttribute("trackname", tracknameBox.Text);
            trackconfig.SetAttribute("unlockedInGHLiveByDefault", boolToXml(unlockedInGHLBox.Checked));
            trackconfig.SetAttribute("intensity", intensityBox.Value.ToString());

            // Highway shit
            XmlNode highway = document.SelectSingleNode("Track/Highway");
            ((XmlElement)highway).SetAttribute("newbeginner", speedBBox.Value.ToString(CultureInfo.InvariantCulture));
            ((XmlElement)highway).SetAttribute("neweasy", speedEBox.Value.ToString(CultureInfo.InvariantCulture));
            ((XmlElement)highway).SetAttribute("newmedium", speedMBox.Value.ToString(CultureInfo.InvariantCulture));
            ((XmlElement)highway).SetAttribute("newhard", speedHBox.Value.ToString(CultureInfo.InvariantCulture));
            ((XmlElement)highway).SetAttribute("newexpert", speedXBox.Value.ToString(CultureInfo.InvariantCulture));
            if (opacityBox.Enabled)
            {
                ((XmlElement)highway).SetAttribute("highwayOpacityMultiplier", opacityBox.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (transparencyBox.Enabled)
            {
                ((XmlElement)highway).SetAttribute("highwayTransparency", transparencyBox.Value.ToString(CultureInfo.InvariantCulture));
            }

            // Video shit
            XmlNode video = document.SelectSingleNode("Track/Video");
            if (video == null)
            {
                if (videoEnabledCheck.Checked)
                {
                    XmlElement videoelement = document.CreateElement("Video");
                    videoelement.SetAttribute("hasVideo", boolToXml(videoEnabledCheck.Checked));
                    videoelement.SetAttribute("musicStartTime", videoStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    trackconfig.AppendChild(videoelement);
                }
            } else
            {
                ((XmlElement)video).SetAttribute("hasVideo", boolToXml(videoEnabledCheck.Checked));
                ((XmlElement)video).SetAttribute("musicStartTime", videoStartBox.Value.ToString(CultureInfo.InvariantCulture));
            }

            // Stagefright shit
            XmlNode stagefright = document.SelectSingleNode("Track/Stagefright");
            if (stagefright == null && enableStagefright.Checked)
            {
                XmlElement stageelement = document.CreateElement("Stagefright");
                stageelement.SetAttribute("parentSetlist", parentSetlistBox.Text);
                stageelement.SetAttribute("trackStartTime", careerStartBox.Value.ToString(CultureInfo.InvariantCulture));
                stageelement.SetAttribute("trackEndTime", careerEndBox.Value.ToString(CultureInfo.InvariantCulture));
                stageelement.SetAttribute("quickplayStartTime", quickStartBox.Value.ToString(CultureInfo.InvariantCulture));
                stageelement.SetAttribute("quickplayEndTime", quickEndBox.Value.ToString(CultureInfo.InvariantCulture));
                document.DocumentElement.AppendChild(stageelement);
            } else
            {
                ((XmlElement)stagefright).SetAttribute("trackStartTime", careerStartBox.Value.ToString(CultureInfo.InvariantCulture));
                ((XmlElement)stagefright).SetAttribute("trackEndTime", careerEndBox.Value.ToString(CultureInfo.InvariantCulture));
                ((XmlElement)stagefright).SetAttribute("quickplayStartTime", quickStartBox.Value.ToString(CultureInfo.InvariantCulture));
                ((XmlElement)stagefright).SetAttribute("quickplayEndTime", quickEndBox.Value.ToString(CultureInfo.InvariantCulture));
            }

            EnableParentSetlist(enableStagefright.Checked, parentSetlistBox.Text);

            SaveXml();

            DialogResult = DialogResult.Yes;
            Close();
        }

        /// <summary>Load trackconfig.xml</summary>
        public void LoadXml()
        {
            document = new XmlDocument();
            document.Load(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml");
        }

        /// <summary>Enable or disable the parent setlist</summary>
        /// <param name="enable">Enable parent setlist if true, disable if false</param>
        /// <param name="parentSetlist">Name of the new parentSetlist</param>
        public void EnableParentSetlist(bool enable, string parentSetlist)
        {
            if (!String.IsNullOrEmpty(parentSetlist))
            {
                XmlNode stagefright = document.SelectSingleNode("Track/Stagefright");

                // Video files paths
                string source = ((XmlElement)stagefright).HasAttribute("parentSetlistDisabled") ? "Video/" + ((XmlElement)stagefright).GetAttribute("parentSetlistDisabled") + "/positive/" : "setlists/" + ((XmlElement)stagefright).GetAttribute("parentSetlist") + "/video/positive/";

                string dest;
                if (enable)
                {
                    ((XmlElement)stagefright).RemoveAttribute("parentSetlistDisabled");
                    ((XmlElement)stagefright).SetAttribute("parentSetlist", parentSetlist);
                    dest = "setlists/" + parentSetlist + "/video/positive/";
                } else
                {
                    ((XmlElement)stagefright).RemoveAttribute("parentSetlist");
                    ((XmlElement)stagefright).SetAttribute("parentSetlistDisabled", parentSetlist);
                    dest = "Video/" + parentSetlist + "/positive/";
                }

                if (mainWindow.platform == "PlayStation 3")
                {
                    source = source.ToUpper();
                    dest = dest.ToUpper();
                }

                if (!source.Equals(dest, StringComparison.OrdinalIgnoreCase) && File.Exists(mainWindow.gamedir + "/" + source + "video.xml"))
                {
                    if (File.Exists(mainWindow.gamedir + "/" + dest + "video.xml"))
                    {
                        if (!Visible || MessageBox.Show("This parent setlist already has a video. Do you wish to overwrite it?", "Guitar Hero Live Control Panel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (string file in Directory.GetFiles(mainWindow.gamedir + "/" + dest))
                            {
                                File.Delete(file);
                            }

                            MoveVideo(source, dest);
                        }
                    } else
                    {
                        Directory.CreateDirectory(mainWindow.gamedir + "/" + dest);
                        MoveVideo(source, dest);
                    }
                }
            }
        }

        /// <summary>Save trackconfig.xml</summary>
        public void SaveXml()
        {
            if (!File.Exists(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml.bak"))
            {
                File.Copy(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml", mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml.bak", true);
            }
            File.WriteAllText(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/trackconfig.xml", document.OuterXml);
        }

        /// <summary>Moves the video files and updates the manifest.</summary>
        /// <param name="source">Path of the video to move.</param>
        /// <param name="dest">New path of the video.</param>
        private void MoveVideo(string source, string dest)
        {
            HashSet<string> manifest = new HashSet<string>(File.ReadAllLines(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/manifest.txt"));

            foreach (string file in Directory.GetFiles(mainWindow.gamedir + "/" + source))
            {
                manifest.Remove(source + Path.GetFileName(file));
                File.Move(file, mainWindow.gamedir + "/" + dest + Path.GetFileName(file));
                manifest.Add(dest + Path.GetFileName(file));
            }

            File.WriteAllLines(mainWindow.gamedir + "/Audio/AudioTracks/" + id + "/manifest.txt", manifest.ToArray());
        }
    }
}
