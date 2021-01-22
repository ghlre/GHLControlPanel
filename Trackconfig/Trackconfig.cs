using System;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GHLCP
{
    [XmlRoot("Track")]
    public class Trackconfig : IXmlSerializable, IComparable
    {
        private string id, artist, trackname, quickplayLeaderboardIndex;
        private int countInDurationBars, intensity;
        private bool unlockedInGHLiveByDefault;

        private TrackconfigVideo video;
        private TrackconfigStagefright stagefright;
        private TrackconfigHighway highway;

        private static readonly TrackconfigLight[] lights = {
            new TrackconfigLight(0, 120.0, 70.0, 280.0, 0.635, 0.925, 0.925),
            new TrackconfigLight(1, 50.0, 90.0, -50.0, 0.635, 0.925, 0.925),
            new TrackconfigLight(2, 0.0, 70.0, -30.0, 0.757, 0.682, 0.588),
            new TrackconfigLight(3, 500.0, 500.0, 500.0, 0.0, 0.0, 0.0)
        };

        private static readonly string[] defaultTracks = { "GHL1003", "GHL1004", "GHL1005", "GHL1006", "GHL1007", "GHL1008", "GHL1009", "GHL1010", "GHL1011", "GHL1012", "GHL1013", "GHL1014", "GHL1015", "GHL1016", "GHL1017", "GHL1018", "GHL1019", "GHL1020", "GHL1021", "GHL1022", "GHL1023", "GHL1024", "GHL1025", "GHL1026", "GHL1027", "GHL1028", "GHL1029", "GHL1030", "GHL1031", "GHL1032", "GHL1033", "GHL1034", "GHL1035", "GHL1036", "GHL1037", "GHL1038", "GHL1039", "GHL1040", "GHL1041", "GHL1042", "GHL1043", "GHL1044", "GHL1045", "TST1798", "GHTVFree" };

        public Trackconfig()
        {
            video = new TrackconfigVideo();
            stagefright = new TrackconfigStagefright();
            highway = new TrackconfigHighway();
        }

        [XmlAttribute("id")]
        public string Id { get => id; set => id = value; }

        [XmlAttribute("artist")]
        public string Artist { get => artist; set => artist = value; }

        [XmlAttribute("trackname")]
        public string Trackname { get => trackname; set => trackname = value; }

        [XmlAttribute("quickplayLeaderboardIndex")]
        public string QuickplayLeaderboardIndex { get => quickplayLeaderboardIndex; set => quickplayLeaderboardIndex = value; }

        [XmlAttribute("countInDurationBars")]
        public int CountInDurationBars { get => countInDurationBars; set => countInDurationBars = value; }

        [XmlAttribute("intensity")]
        public int Intensity { get => intensity; set => intensity = value; }

        [XmlAttribute("unlockedInGHLiveByDefault")]
        public bool UnlockedInGHLiveByDefault { get => unlockedInGHLiveByDefault; set => unlockedInGHLiveByDefault = value; }

        [XmlElement("Video")]
        public TrackconfigVideo Video { get => video; set => video = value; }

        [XmlElement("Stagefright")]
        public TrackconfigStagefright Stagefright { get => stagefright; set => stagefright = value; }

        [XmlElement("Highway")]
        public TrackconfigHighway Highway { get => highway; set => highway = value; }

        public bool IsDefault { get => defaultTracks.Contains(id); }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Track":
                            ReadAttributes(reader);
                            break;
                        case "Video":
                            video.ReadXml(reader);
                            break;
                        case "Stagefright":
                            stagefright.ReadXml(reader);
                            break;
                        case "Highway":
                            highway.ReadXml(reader);
                            break;
                    }
                }
            } while (reader.Read());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("id", id);
            writer.WriteAttributeString("artist", artist);
            writer.WriteAttributeString("trackname", trackname);
            writer.WriteAttributeString("countInDurationBars", countInDurationBars.ToString());
            writer.WriteAttributeString("intensity", intensity.ToString());
            writer.WriteAttributeString("unlockedInGHLiveByDefault", unlockedInGHLiveByDefault.ToString());
            writer.WriteAttributeString("quickplayLeaderboardIndex", quickplayLeaderboardIndex);

            video.WriteXml(writer);
            stagefright.WriteXml(writer);
            highway.WriteXml(writer);
            WriteDefaultXml(writer);
        }

        public static bool XmlToBool(string value)
        {
            return value != null && value.ToLower() == "true";
        }

        private static void WriteDefaultXml(XmlWriter writer)
        {
            writer.WriteStartElement("CustomModel");
            writer.WriteAttributeString("ArrayModel", "Models/highway_3ln_led_zep.xmf");
            writer.WriteAttributeString("TraditionalModel", "Models/highway_5ln_ledzep.xmf");
            writer.WriteEndElement();

            foreach (TrackconfigLight light in lights)
            {
                light.WriteXml(writer);
            }
        }

        private void ReadAttributes(XmlReader reader)
        {
            id = reader.GetAttribute("id");
            artist = reader.GetAttribute("artist");
            trackname = reader.GetAttribute("trackname");

            string countInAtt = reader.GetAttribute("countInDurationBars");
            countInDurationBars = countInAtt == null ? 0 : int.Parse(countInAtt);

            string intensityAtt = reader.GetAttribute("intensity");
            intensity = intensityAtt == null ? 0 : int.Parse(intensityAtt);

            unlockedInGHLiveByDefault = XmlToBool(reader.GetAttribute("unlockedInGHLiveByDefault"));
            quickplayLeaderboardIndex = reader.GetAttribute("quickplayLeaderboardIndex");
        }

        public int CompareTo(object obj)
        {
            if (obj is Trackconfig trackconfig)
                return id.CompareTo(trackconfig.id);
            throw new ArgumentException("The object received as a parameter is not a trackconfig");
        }
    }
}