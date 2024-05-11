using System;

namespace Skillup.XMLReadSearch.Utility
{
    /// <summary>
    /// used for to get all input from user.
    /// </summary>
    public class UserInput
    {
        #region Get Option from the user
        /// <summary>
        /// to get options for showdevices or search device or exit.
        /// </summary>
        /// <returns></returns>
        public static UserOptions GetSelectedOption()
        {
            //print message to diplay the options to the user.
            Output.PrintMsgForInputOption();

            while (true)
            {
                string strGetOption = GetString();

                //to return the options from enum class else display appropriate error message.
                if (Enum.TryParse(strGetOption, out UserOptions GetOption) && Enum.IsDefined(typeof(UserOptions), GetOption))
                {
                    return GetOption;
                }
                else
                {
                    Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_WRONG_OPTION));
                }
            }
        }
        #endregion

        #region Get Serial number from user.
        /// <summary>
        /// To get Serial number from the user to search device.
        /// </summary>
        /// <returns></returns>
        public static string GetSerialNumber()
        {
            Output.WriteLine("\n" + Constant.MSG_SELECTION_SEARCH_DEVICE);
            Output.WriteLine(Constant.MSG_ENTER_SERIAL_NUMBER);
            string strSerialNumber = GetString();
            return strSerialNumber;
        }
        #endregion

        /// <summary>
        /// to get string as an input from user.
        /// </summary>
        /// <returns></returns>
        private static string GetString()
        {
            return Console.ReadLine();
        }
    }
}