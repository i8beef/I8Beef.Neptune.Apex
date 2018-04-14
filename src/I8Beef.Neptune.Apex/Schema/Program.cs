using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Program.
    /// </summary>
    [Serializable]
    [XmlRoot("proglist")]
    public class Program
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
        /// Hostname.
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
        /// Profiles.
        /// </summary>
        [XmlArray("profiles")]
        [XmlArrayItem("profile", typeof(Profile))]
        public Profile[] Profiles { get; set; }

        /// <summary>
        /// Outlets.
        /// </summary>
        [XmlArray("outlets")]
        [XmlArrayItem("outlet", typeof(Outlet))]
        public Outlet[] Outlets { get; set; }
    }
}
