namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// Class for defining child nodes of Communication Setings.
    /// </summary>
    public class CommunicationSetting
    {
        /// <summary>
        /// Property for Device PortNo.
        /// </summary>
        public int PortNo { get; set; }

        /// <summary>
        /// Property for Device use SSL or not.
        /// </summary>
        public bool UseSSL { get; set; }

        /// <summary>
        /// Property for Device Password.
        /// </summary>
        public string Password { get; set; }
    }
}