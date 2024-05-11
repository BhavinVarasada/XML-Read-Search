using Skillup.XMLReadSearch.Model;
using Skillup.XMLReadSearch.Utility;
using System.Collections.Generic;
using System.Linq;

namespace Skillup.XMLReadSearch
{
    /// <summary>
    /// Used for program execution logic.
    /// </summary>
    public class Execution
    {
        /// <summary>
        /// method calls to validate XML file and print appropriate error message.
        /// </summary>
        /// <param name="arg"></param>
        public void Start(string strFilePath)
        {
            try
            {
                XMLValidation objXMLValidation = new XMLValidation();

                //method call to validate XML file.
                bool bErrorStatus = objXMLValidation.XMLFileValidation(strFilePath);

                //if error will be generated then exit the program.
                if (!bErrorStatus)
                {
                    return;
                }

                //Method call for Deserialization.
                Devices objdevices = Deserialization.DeserializationData(strFilePath);

                // Create a dictionary and add devices to the dictionary using SrNo as the key and whole Device object as a value.
                Dictionary<string, Device> dicDevicesInfo = objdevices.Dev.ToDictionary(X => X.SrNo, X => X);

                PerformAction objPerformAction = new PerformAction();
                bool bExitProgram = false;

                // if xml file is valid then to get selected options from user and
                // to perform the perticular action according to user input.
                do
                {
                    UserOptions SelectedOption = UserInput.GetSelectedOption();
                    switch (SelectedOption)
                    {
                        case UserOptions.ShowDevice:
                            objPerformAction.ShowAllDevices(dicDevicesInfo);
                            break;
                        
                        case UserOptions.SearchDevice:
                            string strSerialNumber = UserInput.GetSerialNumber();
                            objPerformAction.SearchDevice(strSerialNumber, dicDevicesInfo);
                            break;

                        case UserOptions.Exit:
                            Output.WriteLine(Constant.MSG_EXIT_PROGRAM);
                            bExitProgram = true;
                            break;

                        default:
                            Output.WriteLine(Constant.ERROR_MSG_INVALID_INPUT);
                            break;
                    }
                } while (!bExitProgram);
            }
            catch (CustomException ex)
            {
                Output.WriteLine(ex.Message);
                Output.WriteLine(ex.InnerException);
            }
        }
    }
}