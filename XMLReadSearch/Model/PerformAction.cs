using Skillup.XMLReadSearch.Utility;
using System.Collections.Generic;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// Class for perform actions for show all devices and search perticular device.
    /// </summary>
    public class PerformAction
    {
        #region Show All Devices
        /// <summary>
        /// It will show the all device information.
        /// </summary>
        /// <param name="dicDevicesInfo"></param>
        public void ShowAllDevices(Dictionary<string, Device> dicDevicesInfo)
        {
            Output.PrintTitleShowDevices();

            int nDeviceNo = 1;
            // it will print all devices information in formated way.
            foreach (KeyValuePair<string, Device> objdevice in dicDevicesInfo)
            {
                Device device = objdevice.Value;
                string strDecryptedPassword = Decryption.DecryptString(device.CommSetting.Password);
                Output.Write(string.Format(Constant.SHOW_DEVICES_TAG_NAMES, nDeviceNo, device.SrNo, device.Address,
                                           device.DevName, device.ModelName, device.Type, device.CommSetting.PortNo,
                                           device.CommSetting.UseSSL, strDecryptedPassword));
                Output.WriteLine();
                nDeviceNo++;
            }
        }
        #endregion

        #region Search Device
        /// <summary>
        /// It will search the perticular device if it is available.
        /// </summary>
        /// <param name="strSerialNumber"></param>
        /// <param name="dicDevicesInfo"></param>
        public void SearchDevice(string strSerialNumber, Dictionary<string, Device> dicDevicesInfo)
        {
            //if device is present in file then it will print it's information in formated way.
            if (dicDevicesInfo.TryGetValue(strSerialNumber, out Device objDevice))
            {
                string strDecryptedPassword = Decryption.DecryptString(objDevice.CommSetting.Password);
                Output.PrintTitleSearchDevices();
                Output.Write(string.Format(Constant.SEARCHED_DEVICES_TAG_NAMES, objDevice.SrNo, objDevice.Address,
                                           objDevice.DevName, objDevice.ModelName, objDevice.Type, objDevice.CommSetting.PortNo,
                                           objDevice.CommSetting.UseSSL, strDecryptedPassword));
                Output.WriteLine();
            }
            else
            {
                Output.WriteLine(Constant.ERROR_MSG_DEVICE_NOT_FOUND);
            }
        }
        #endregion
    }
}