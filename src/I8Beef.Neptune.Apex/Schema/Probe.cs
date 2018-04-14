using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Probe.
    /// </summary>
    [Serializable]
    [XmlRoot("probe")]
    public class Probe
    {
        /// <summary>
        /// Name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}
