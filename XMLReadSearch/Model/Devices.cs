using Skillup.XMLReadSearch.Model;
using System.Xml.Serialization;

namespace Skillup.XMLReadSearch
{
    /// <summary>
    /// class for defining xml elements and it's property.
    /// </summary>
    [XmlRoot("Devices")]
    public class Devices
    {
        /// <summary>
        /// property for main Dev node.
        /// </summary>
        [XmlElement("Dev")]
        public Device[] Dev { get; set; }
    }
}
