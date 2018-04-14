using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Record.
    /// </summary>
    [Serializable]
    [XmlRoot("record")]
    public class Record
    {
        /// <summary>
        /// Date.
        /// </summary>
        [XmlElement("date")]
        public string Date { get; set; }

        /// <summary>
        /// Probes.
        /// </summary>
        [XmlElement("probe")]
        public Probe[] Probes { get; set; }
    }
}
