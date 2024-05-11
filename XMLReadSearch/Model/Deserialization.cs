using System.IO;
using System.Xml.Serialization;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// to read the data with deserialization method.
    /// </summary>
    public class Deserialization
    {
        /// <summary>
        /// to Deserialize the data from xml file and it will return object.
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static Devices DeserializationData(string strFilePath)
        {
            //Use deserialization method to read the xml file.
            Devices objdevices;
            XmlSerializer objserializer = new XmlSerializer(typeof(Devices));
            using (StreamReader objstreamReader = new StreamReader(strFilePath))
            {
                objdevices = (Devices)objserializer.Deserialize(objstreamReader);
            }
            return objdevices;
        }
    }
}
