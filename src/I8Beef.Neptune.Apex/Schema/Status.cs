using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Status.
    /// </summary>
    [Serializable]
    [XmlRoot("status")]
    public class Status
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
        /// Power.
        /// </summary>
        [XmlElement("power", typeof(Power))]
        public Power Power { get; set; }

        /// <summary>
        /// Probes.
        /// </summary>
        [XmlArray("probes")]
        [XmlArrayItem("probe", typeof(Probe))]
        public Probe[] Probes { get; set; }

        /// <summary>
        /// Outlets.
        /// </summary>
        [XmlArray("outlets")]
        [XmlArrayItem("outlet", typeof(Outlet))]
        public Outlet[] Outlets { get; set; }
    }
}
