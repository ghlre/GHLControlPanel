using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GHLCP
{
    [XmlRoot("Video")]
    public class TrackconfigVideo : IXmlSerializable
    {
        private bool hasVideo;
        private double musicStartTime;

        public TrackconfigVideo() { }

        public TrackconfigVideo(bool hasVideo, double musicStartTime)
        {
            this.hasVideo = hasVideo;
            this.musicStartTime = musicStartTime;
        }

        [XmlAttribute("hasVideo")]
        public bool HasVideo { get => hasVideo; set => hasVideo = value; }

        [XmlAttribute("musicStartTime")]
        public double MusicStartTime { get => musicStartTime; set => musicStartTime = value; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            hasVideo = Trackconfig.XmlToBool(reader.GetAttribute("hasVideo"));
            musicStartTime = double.Parse(reader.GetAttribute("musicStartTime"), CultureInfo.InvariantCulture);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Video");
            writer.WriteAttributeString("hasVideo", hasVideo.ToString());
            writer.WriteAttributeString("musicStartTime", musicStartTime.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }
    }
}