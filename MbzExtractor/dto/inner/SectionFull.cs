using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MbzExtractor.dto.inner
{

    [XmlRoot(ElementName = "section")]
    public class SectionFull
    {
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }
        [XmlElement(ElementName = "summaryformat")]
        public string Summaryformat { get; set; }
        [XmlElement(ElementName = "sequence")]
        public string Sequence { get; set; }
        [XmlElement(ElementName = "visible")]
        public string Visible { get; set; }
        [XmlElement(ElementName = "availabilityjson")]
        public string Availabilityjson { get; set; }
        [XmlElement(ElementName = "timemodified")]
        public string Timemodified { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlIgnore]
        public int Index { get; set; }
    }
}
