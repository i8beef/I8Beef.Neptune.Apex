using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Outlet.
    /// </summary>
    [Serializable]
    [XmlRoot("outlet")]
    public class Outlet
    {
        /// <summary>
        /// Name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Output ID.
        /// </summary>
        [XmlElement("outputID")]
        public string OutputId { get; set; }

        /// <summary>
        /// Output type.
        /// </summary>
        [XmlElement("outputType")]
        public string OutputType { get; set; }

        /// <summary>
        /// Output log.
        /// </summary>
        [XmlElement("outputLog")]
        public string OutputLog { get; set; }

        /// <summary>
        /// State.
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// Device ID.
        /// </summary>
        [XmlElement("deviceID")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Icon.
        /// </summary>
        [XmlElement("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Program.
        /// </summary>
        [XmlElement("program")]
        public string Program { get; set; }
    }
}
