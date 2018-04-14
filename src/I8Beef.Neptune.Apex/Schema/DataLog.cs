using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Data log.
    /// </summary>
    [Serializable]
    [XmlRoot("datalog")]
    public class DataLog
    {
        /// <summary>
        /// Software.
        /// </summary>
        [XmlAttribute("software")]
        public string Software { get; set; }

        /// <summary>
        /// Hardware.
        /// </summary>
        [XmlAttribute("hardware")]
        public string Hardware { get; set; }

        /// <summary>
        /// Hostnname.
        /// </summary>
        [XmlElement("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Serial.
        /// </summary>
        [XmlElement("serial")]
        public string Serial { get; set; }

        /// <summary>
        /// Timezone.
        /// </summary>
        [XmlElement("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// Records.
        /// </summary>
        [XmlElement("record")]
        public Record[] Records { get; set; }
    }
}
