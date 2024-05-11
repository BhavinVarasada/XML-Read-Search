using Skillup.XMLReadSearch.Utility;
using System.Xml.Serialization;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// class for all device information nodes.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Define XMLAttribute SrNo.
        /// </summary>       
        [XmlAttribute("SrNo")]
        public string SrNo { get; set; }

        /// <summary>
        /// Property for device IP Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Property for Device Name.
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// Property for Device model name.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Property for Device Type (Enum class Device typr).
        /// </summary>
        public DeviceType Type { get; set; }

        /// <summary>
        /// Property for Communication Settings.
        /// </summary>
        public CommunicationSetting CommSetting { get; set; }
    }
}
