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
        public string idToGet = "";
        string gamedire = "";
        bool dontAlertChanges = false;
        string[] defaultTracks = { "GHL1003", "GHL1004", "GHL1005", "GHL1006", "GHL1007", "GHL1008", "GHL1009", "GHL1010", "GHL1011", "GHL1012", "GHL1013", "GHL1014", "GHL1015", "GHL1016", "GHL1017", "GHL1018", "GHL1019", "GHL1020", "GHL1021", "GHL1022", "GHL1023", "GHL1024", "GHL1025", "GHL1026", "GHL1027", "GHL1028", "GHL1029", "GHL1030", "GHL1031", "GHL1032", "GHL1033", "GHL1034", "GHL1035", "GHL1036", "GHL1037", "GHL1038", "GHL1039", "GHL1040", "GHL1041", "GHL1042", "GHL1043", "GHL1044", "GHL1045", "TST1798", "GHTVFree" };

        public EditSong()
        {
            InitializeComponent();
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

        }

        public void Populate(string id, string gamedir)
        {
            dontAlertChanges = true;
            idToGet = id;
            gamedire = gamedir;
            XmlDocument document = new XmlDocument();
            document.Load(gamedir + "\\Audio\\AudioTracks\\" + id + "\\trackconfig.xml");

            // Track generic details
            XmlElement trackconfig = document.DocumentElement;
            idBox.Text = trackconfig.GetAttributeNode("id").InnerText;
            artistBox.Text = trackconfig.GetAttributeNode("artist").InnerText;
            tracknameBox.Text = trackconfig.GetAttributeNode("trackname").InnerText;
            Text = $"Editing Song: {trackconfig.GetAttributeNode("artist").InnerText} - {trackconfig.GetAttributeNode("trackname").InnerText} [{id}]";
            if (trackconfig.HasAttribute("unlockedInGHLiveByDefault"))
            {
                unlockedInGHLBox.Checked = (trackconfig.GetAttributeNode("unlockedInGHLiveByDefault").InnerText == "true");
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
                    videoEnabledCheck.Checked = (((XmlElement)video).GetAttributeNode("hasVideo").InnerText == "true");
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
            }
            else
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
            if (defaultTracks.Contains(idToGet))
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
            XmlDocument document = new XmlDocument();
            document.Load(gamedire + "\\Audio\\AudioTracks\\" + idToGet + "\\trackconfig.xml");

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
                if (videoEnabledCheck.Checked) {
                    XmlElement videoelement = document.CreateElement("Video");
                    videoelement.SetAttribute("hasVideo", boolToXml(videoEnabledCheck.Checked));
                    videoelement.SetAttribute("musicStartTime", videoStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    trackconfig.AppendChild(videoelement);
                }
            }
            else
            {
                ((XmlElement)video).SetAttribute("hasVideo", boolToXml(videoEnabledCheck.Checked));
                ((XmlElement)video).SetAttribute("musicStartTime", videoStartBox.Value.ToString(CultureInfo.InvariantCulture));
            }

            // Stagefright shit
            XmlNode stagefright = document.SelectSingleNode("Track/Stagefright");
            if (stagefright == null)
            {
                if (enableStagefright.Checked)
                {
                    XmlElement stageelement = document.CreateElement("Stagefright");
                    stageelement.SetAttribute("parentSetlist", parentSetlistBox.Text);
                    stageelement.SetAttribute("trackStartTime", careerStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    stageelement.SetAttribute("trackEndTime", careerEndBox.Value.ToString(CultureInfo.InvariantCulture));
                    stageelement.SetAttribute("quickplayStartTime", quickStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    stageelement.SetAttribute("quickplayEndTime", quickEndBox.Value.ToString(CultureInfo.InvariantCulture));
                    trackconfig.AppendChild(stageelement);
                }
            }
            else
            {
                if (parentSetlistBox.Text != "")
                {
                    if (enableStagefright.Checked)
                    {
                        ((XmlElement)stagefright).RemoveAttribute("parentSetlistDisabled");
                        ((XmlElement)stagefright).SetAttribute("parentSetlist", parentSetlistBox.Text);
                    }
                    else
                    {
                        ((XmlElement)stagefright).RemoveAttribute("parentSetlist");
                        ((XmlElement)stagefright).SetAttribute("parentSetlistDisabled", parentSetlistBox.Text);
                    }
                    ((XmlElement)stagefright).SetAttribute("trackStartTime", careerStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    ((XmlElement)stagefright).SetAttribute("trackEndTime", careerEndBox.Value.ToString(CultureInfo.InvariantCulture));
                    ((XmlElement)stagefright).SetAttribute("quickplayStartTime", quickStartBox.Value.ToString(CultureInfo.InvariantCulture));
                    ((XmlElement)stagefright).SetAttribute("quickplayEndTime", quickEndBox.Value.ToString(CultureInfo.InvariantCulture));
                }
            }
            
            if (!File.Exists(gamedire + "\\Audio\\AudioTracks\\" + idToGet + "\\trackconfig.xml.bak"))
            {
                File.Copy(gamedire + "\\Audio\\AudioTracks\\" + idToGet + "\\trackconfig.xml", gamedire + "\\Audio\\AudioTracks\\" + idToGet + "\\trackconfig.xml.bak", true);
            }
            File.WriteAllText(gamedire + "\\Audio\\AudioTracks\\" + idToGet + "\\trackconfig.xml", document.OuterXml);

            Close();
        }
    }
}
