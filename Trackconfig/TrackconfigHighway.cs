using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GHLCP
{
    [XmlRoot("Highway")]
    public class TrackconfigHighway : IXmlSerializable, ICloneable
    {
        private double beginner, easy, medium, hard, expert;
        private double opacity, transparency;

        public TrackconfigHighway()
        {
            opacity = 1.0;
            transparency = 0.5;
        }

        [XmlAttribute("newbeginner")]
        public double Beginner { get => beginner; set => beginner = value; }

        [XmlAttribute("neweasy")]
        public double Easy { get => easy; set => easy = value; }

        [XmlAttribute("newmedium")]
        public double Medium { get => medium; set => medium = value; }

        [XmlAttribute("newhard")]
        public double Hard { get => hard; set => hard = value; }

        [XmlAttribute("newexpert")]
        public double Expert { get => expert; set => expert = value; }

        [XmlAttribute("highwayOpacityMultiplier")]
        public double Opacity { get => opacity; set => opacity = value; }

        [XmlAttribute("highwayTransparency")]
        public double Transparency { get => transparency; set => transparency = value; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            beginner = double.Parse(reader.GetAttribute("newbeginner"), CultureInfo.InvariantCulture);
            easy = double.Parse(reader.GetAttribute("neweasy"), CultureInfo.InvariantCulture);
            medium = double.Parse(reader.GetAttribute("newmedium"), CultureInfo.InvariantCulture);
            hard = double.Parse(reader.GetAttribute("newhard"), CultureInfo.InvariantCulture);
            expert = double.Parse(reader.GetAttribute("newexpert"), CultureInfo.InvariantCulture);

            string opacityAtt = reader.GetAttribute("highwayOpacityMultiplier");
            if (opacityAtt != null)
                opacity = double.Parse(opacityAtt, CultureInfo.InvariantCulture);

            string transparencyAtt = reader.GetAttribute("highwayTransparency");
            if (transparencyAtt != null)
                transparency = double.Parse(transparencyAtt, CultureInfo.InvariantCulture);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Highway");
            writer.WriteAttributeString("newbeginner", beginner.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("neweasy", easy.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("newmedium", medium.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("newhard", hard.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("newexpert", expert.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("highwayOpacityMultiplier", opacity.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("highwayTransparency", transparency.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }
    }
}