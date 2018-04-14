using System;
using System.Xml.Serialization;

namespace I8Beef.Neptune.Apex.Schema
{
    /// <summary>
    /// Profile.
    /// </summary>
    [Serializable]
    [XmlRoot("profile")]
    public class Profile
    {
        /// <summary>
        /// Name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        #region Ramp type

        /// <summary>
        /// Ramp time.
        /// </summary>
        [XmlElement("rampTime")]
        public int RampTime { get; set; }

        /// <summary>
        /// Start intensity.
        /// </summary>
        [XmlElement("startIntensity")]
        public int StartIntensity { get; set; }

        /// <summary>
        /// End intensity.
        /// </summary>
        [XmlElement("endIntensity")]
        public int EndIntensity { get; set; }

        #endregion

        #region Pump and Weather type

        /// <summary>
        /// Minimum intensity.
        /// </summary>
        [XmlElement("minIntensity")]
        public int MinIntensity { get; set; }

        /// <summary>
        /// Maximum intensity.
        /// </summary>
        [XmlElement("maxIntensity")]
        public int MaxIntensity { get; set; }

        #endregion

        #region Pump type

        /// <summary>
        /// Sync.
        /// </summary>
        [XmlElement("sync")]
        public string Sync { get; set; }

        /// <summary>
        /// Div 10.
        /// </summary>
        [XmlElement("div10")]
        public string Div10 { get; set; }

        /// <summary>
        /// Intensity off time.
        /// </summary>
        [XmlElement("intOffTime")]
        public int IntOffTime { get; set; }

        /// <summary>
        /// On time.
        /// </summary>
        [XmlElement("OnTime")]
        public int OnTime { get; set; }

        /// <summary>
        /// Off time.
        /// </summary>
        [XmlElement("OffTime")]
        public int OffTime { get; set; }

        #endregion

        #region Weather type

        /// <summary>
        /// Cloud duration.
        /// </summary>
        [XmlElement("cloudDuration")]
        public int CloudDuration { get; set; }

        /// <summary>
        /// Cloud percentage.
        /// </summary>
        [XmlElement("cloudyPercent")]
        public int CloudyPercent { get; set; }

        /// <summary>
        /// Lighting amount.
        /// </summary>
        [XmlElement("lightningAmount")]
        public int LightningAmount { get; set; }

        /// <summary>
        /// Lighting intensity.
        /// </summary>
        [XmlElement("lightningInt")]
        public int LightningInt { get; set; }

        #endregion
    }
}
