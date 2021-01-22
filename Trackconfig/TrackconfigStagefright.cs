using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GHLCP
{
    [XmlRoot("Stagefright")]
    public class TrackconfigStagefright : IXmlSerializable
    {
        private bool enabled;
        private string parentSetlist;
        private double trackStartTime, quickplayStartTime, trackEndTime, quickplayEndTime;

        public TrackconfigStagefright() { }

        public TrackconfigStagefright(bool enabled, string parentSetlist)
        {
            this.enabled = enabled;
            this.parentSetlist = parentSetlist;
        }

        public TrackconfigStagefright(bool enabled, string parentSetlist, double startTime, double endTime) : this(enabled, parentSetlist)
        {
            trackStartTime = quickplayStartTime = startTime;
            trackEndTime = quickplayEndTime = endTime;
        }

        public bool Enabled { get => enabled; set => enabled = value; }

        [XmlAttribute("parentSetlist")]
        public string ParentSetlist { get => parentSetlist; set => parentSetlist = value; }

        [XmlAttribute("trackStartTime")]
        public double TrackStartTime { get => trackStartTime; set => trackStartTime = value; }

        [XmlAttribute("quickplayStartTime")]
        public double QuickplayStartTime { get => quickplayStartTime; set => quickplayStartTime = value; }

        [XmlAttribute("trackEndTime")]
        public double TrackEndTime { get => trackEndTime; set => trackEndTime = value; }

        [XmlAttribute("quickplayEndTime")]
        public double QuickplayEndTime { get => quickplayEndTime; set => quickplayEndTime = value; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            parentSetlist = reader.GetAttribute("parentSetlistDisabled");
            enabled = parentSetlist == null;
            if (enabled)
                parentSetlist = reader.GetAttribute("parentSetlist");

            trackStartTime = double.Parse(reader.GetAttribute("trackStartTime"), CultureInfo.InvariantCulture);
            quickplayStartTime = double.Parse(reader.GetAttribute("quickplayStartTime"), CultureInfo.InvariantCulture);
            trackEndTime = double.Parse(reader.GetAttribute("trackEndTime"), CultureInfo.InvariantCulture);
            quickplayEndTime = double.Parse(reader.GetAttribute("quickplayEndTime"), CultureInfo.InvariantCulture);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Stagefright");
            writer.WriteAttributeString(enabled ? "parentSetlist" : "parentSetlistDisabled", parentSetlist);
            writer.WriteAttributeString("trackStartTime", trackStartTime.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("quickplayStartTime", quickplayStartTime.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("trackEndTime", trackEndTime.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("quickplayEndTime", quickplayEndTime.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }
    }
}