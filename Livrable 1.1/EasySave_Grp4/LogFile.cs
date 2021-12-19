using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace test
{
    [XmlRoot("LogFile"), XmlType("LogFile")]

    public class LogFile
    {
        

        public static string filepath = @"..\..\..\Config\Log.xml";
        public static string filepathj = @"..\..\..\Config\Log.json";

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "SourceFilePath")]
        public string SourceFilePath { get; set; }
        [XmlElement(ElementName = "TargetFilePath")]
        public string TargetFilePath { get; set; }
        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "Time")]
        public string Time { get; set; }
        [XmlElement(ElementName = "TransitionTime")]
        public string TransitionTime { get; set; }

    }
}