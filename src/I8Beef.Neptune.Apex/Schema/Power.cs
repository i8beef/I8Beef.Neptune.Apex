using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Power.
    /// </summary>
    [Serializable]
    [XmlRoot("power")]
    public class Power
    {
        /// <summary>
        /// Failed.
        /// </summary>
        [XmlElement("failed")]
        public string Failed { get; set; }

        /// <summary>
        /// Restored.
        /// </summary>
        [XmlElement("restored")]
        public string Restored { get; set; }
    }
}
