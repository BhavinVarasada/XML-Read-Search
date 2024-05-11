using System;

namespace Skillup.XMLReadSearch.Utility
{
    /// <summary>
    /// for all methods which is used for print.
    /// </summary>
    public class Output
    {
        /// <summary>
        /// to print the message with arguments and on another line.
        /// </summary>
        /// <param name="Message"></param>
        public static void WriteLine(object Message = null)
        {
            Console.WriteLine(Message);
        }

        /// <summary>
        /// for print the message but on same line.
        /// </summary>
        /// <param name="Message"></param>
        public static void Write(object Message = null)
        {
            Console.Write(Message);
        }

        #region Print Messages For Input Options

        /// <summary>
        /// for print options to the user to get input.
        /// </summary>
        public static void PrintMsgForInputOption()
        {
            WriteLine();
            WriteLine(Constant.MSG_SELECT_OPTION);
            WriteLine(Constant.MSG_SELECTION_SHOW_DEVICES);
            WriteLine(Constant.MSG_SELECTION_SEARCH_DEVICE);
            WriteLine(Constant.MSG_SELECTION_EXIT);
        }
        #endregion

        #region Print Title For Show Devices

        /// <summary>
        /// To print user input msg for show all devices and search device.
        /// </summary>
        public static void PrintTitleShowDevices()
        {
            WriteLine("\n" + Constant.MSG_SELECTION_SHOW_DEVICES);
            WriteLine(string.Format(Constant.DASH_LINE_FORMAT, Constant.DASH_LINE));

            string strShowDeviceTagName = string.Format(Constant.SHOW_DEVICES_TAG_NAMES, Constant.MSG_DEVICE_NO, Constant.MSG_DEVICE_SERIALNO, Constant.MSG_DEVICE_IP_ADDRESS,
                                                        Constant.MSG_DEVICE_NAME, Constant.MSG_DEVICE_MODEL_NAME, Constant.MSG_DEVICE_TYPE, Constant.MSG_DEVICE_PORT,
                                                        Constant.MSG_DEVICE_SSL, Constant.MSG_DEVICE_PASSWORD);
            WriteLine(strShowDeviceTagName);
            WriteLine(Constant.DASH_LINE);
        }
        #endregion

        #region Print Title For Searched Device

        /// <summary>
        /// To print title and device information for searched items.
        /// </summary>
        public static void PrintTitleSearchDevices()
        {
            WriteLine("\n" + Constant.MSG_SEARCHED_DEVICE_INFO);
            WriteLine(string.Format(Constant.DASH_LINE_FORMAT, Constant.DASH_LINE));

            string strSearchedDeviceTagName = string.Format(Constant.SEARCHED_DEVICES_TAG_NAMES, Constant.MSG_DEVICE_SERIALNO, Constant.MSG_DEVICE_IP_ADDRESS,
                                                            Constant.MSG_DEVICE_NAME, Constant.MSG_DEVICE_MODEL_NAME, Constant.MSG_DEVICE_TYPE, Constant.MSG_DEVICE_PORT,
                                                            Constant.MSG_DEVICE_SSL, Constant.MSG_DEVICE_PASSWORD);
            WriteLine(strSearchedDeviceTagName);
            WriteLine(Constant.DASH_LINE);
        }
        #endregion
    }
}