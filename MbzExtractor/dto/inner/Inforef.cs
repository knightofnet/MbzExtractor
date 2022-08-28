using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MbzExtractor.dto.inner
{

    [XmlRoot(ElementName = "user")]
    public class User
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "userref")]
    public class Userref
    {
        [XmlElement(ElementName = "user")]
        public List<User> User { get; set; }
    }

    [XmlRoot(ElementName = "file")]
    public class FileInfoRef
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "fileref")]
    public class Fileref
    {
        [XmlElement(ElementName = "file")]
        public List<FileInfoRef> File { get; set; }
    }

    [XmlRoot(ElementName = "inforef")]
    public class Inforef
    {
        [XmlElement(ElementName = "userref")]
        public Userref Userref { get; set; }
        [XmlElement(ElementName = "fileref")]
        public Fileref Fileref { get; set; }

    }


}
