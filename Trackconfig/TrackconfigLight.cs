using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GHLCP
{
    [XmlRoot("Light")]
    public class TrackconfigLight : IXmlSerializable
    {
        private readonly byte index;
        private readonly double x, y, z;
        private readonly double r, g, b;

        public TrackconfigLight(byte index, double x, double y, double z, double r, double g, double b)
        {
            this.index = index;

            this.x = x;
            this.y = y;
            this.z = z;

            this.r = r;
            this.g = g;
            this.b = b;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Light");
            writer.WriteAttributeString("index", index.ToString());
            writer.WriteAttributeString("PosX", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", x));
            writer.WriteAttributeString("PosY", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", y));
            writer.WriteAttributeString("PosZ", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", z));
            writer.WriteAttributeString("ColR", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", r));
            writer.WriteAttributeString("ColG", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", g));
            writer.WriteAttributeString("ColB", String.Format(CultureInfo.InvariantCulture, "{0:0.0##}f", b));
            writer.WriteEndElement();
        }
    }
}