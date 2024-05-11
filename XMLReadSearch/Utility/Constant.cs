namespace Skillup.XMLReadSearch.Utility
{
    /// <summary>
    /// Define all constants here.
    /// </summary>
    public class Constant
    {
        public const string DASH_LINE                           = "--------------------------------------------------------------------------------"+
                                                                  "--------------------------------------------------------";
        public const string ERROR_MSG_COMMON                    = "Error : {0}";
        public const string ERROR_MSG_COMMANDLINE_ARGUMENT      = "Invalid Input. Program usage is as below. [{0}][XML file path]";
        public const string ERROR_FILE_NOT_EXIST                = "File not Exist. please provide a valid file path.";
        public const string ERROR_MSG_FILE_EXTENTION            = "Given file is not XML File. The File Extention is Wrong.";      
        public const string ERROR_MSG_EMPTY_XML_FILE            = "The XML File is Empty. Device data is not present in the file.";
        public const string ERROR_MSG_FILE_FORMAT               = "File Format Error. Given file is not an XML file.";
        public const string ERROR_MSG_NO_DEVICE_IN_FILE         = "The XML File is Empty. Device data is not present in the file";
        public const string ERROR_MSG_DEVICE_DATA_VALIDATION    = "Invalid Device information. Please refer below details.";
        public const string ERROR_MSG_WRONG_OPTION              = "Invalid input. Please choose from above options.";
        public const string ERROR_MSG_NOT_PRESENT               = "(Not Present)";
        public const string ERROR_MSG_EMPTY                     = "(Empty)";
        public const string ERROR_MSG_DUPLICATE                 = "(Duplicate)";
        public const string ERROR_MSG_NOT_SUPPORTED_CHAR        = "(Not Supported Character)";
        public const string ERROR_MSG_INVALID_LENGTH            = "(Invalid Length)";
        public const string ERROR_MSG_NOT_SUPPORTED_FORMAT      = "(Not Supported Format)";
        public const string ERROR_MSG_DEVICE_NOT_FOUND          = "Device Not Found";
        public const string ERROR_MSG_IO_EXCEPTION              = "An I/O Error Ocurred : ";
        public const string ERROR_MSG_UNAUTHORIZED_EXCEPTION    = "Access to the file is not Authorized: ";
        public const string ERROR_MSG_SECURITY_EXCEPTION        = "Security Error occured : ";
        public const string ERROR_MSG_UNEXPECTED_ERROR          = "An Unexpected Error occurred: ";
        public const string ERROR_MSG_INVALID_INPUT             = "Invalid Input";
        public const string ERROR_MSG_ENCRYPTED_STRING          = "Encrypted string is not match.";
        public const string NODE_ERROR_MSG                      = "UnExpected Node Error";

        public const string XSD_FILE_NAME                       = "Files\\DeviceInfo.xsd";
        public const string FILE_EXTENTION                      = ".xml";      
        public const string XML_ELEMENT_NAME                    = "//Dev";
        public const string MSG_SELECT_OPTION                   = "Please select option :";
        public const string MSG_SELECTION_SHOW_DEVICES          = "[1] Show all devices";       
        public const string MSG_SELECTION_SEARCH_DEVICE         = "[2] Search devices by serial number";
        public const string MSG_SELECTION_EXIT                  = "[3] Exit";
        public const string MSG_EXIT_PROGRAM                    = "Program Terminated";
        public const string DASH_LINE_FORMAT                    = "{0,-117}";
        public const string SHOW_DEVICES_TAG_NAMES              = "{0,-4} {1,-22} {2,-22} {3,-24} {4,-24} {5,-7} {6,-7} {7,-7} {8}";
        public const string SEARCHED_DEVICES_TAG_NAMES          = "{0,-22} {1,-22} {2,-24} {3,-24} {4,-7} {5,-7} {6,-7} {7}";
        public const string MSG_DEVICE_NO                       = "No";
        public const string MSG_DEVICE_SERIALNO                 = "Serial Number";
        public const string MSG_DEVICE_IP_ADDRESS               = "IP Address";
        public const string MSG_DEVICE_NAME                     = "Device Name";
        public const string MSG_DEVICE_MODEL_NAME               = "Model Name";
        public const string MSG_DEVICE_TYPE                     = "Type";
        public const string MSG_DEVICE_PORT                     = "Port";
        public const string MSG_DEVICE_SSL                      = "SSL";
        public const string MSG_DEVICE_PASSWORD                 = "Password";
        public const string MSG_ENTER_SERIAL_NUMBER             = "Enter serial number of the device : ";
        public const string MSG_SEARCHED_DEVICE_INFO            = "Device Information is as below";
        public const string USE_SSL_TRUE                        = "true";
        public const string USE_SSL_FALSE                       = "false";

        public const string MSG_DEVICE_INDEX                    = "Device Index       : {0}";
        public const string MSG_XML_SRNO_ATTRIBUTE              = "Serial No          : {0}";
        public const string MSG_XML_ADDRESS_NODE                = "Address            : {0}";
        public const string MSG_XML_DEVNAME_NODE                = "Dev Name           : {0}";
        public const string MSG_XML_MODELNAME_NODE              = "Model Name         : {0}";
        public const string MSG_XML_TYPE_NODE                   = "Type               : {0}";
        public const string MSG_XML_PORTNO_NODE                 = "Port No            : {0}";
        public const string MSG_XML_USESSL_NODE                 = "Use SSL            : {0}";
        public const string MSG_XML_PASSWORD_NODE               = "Password           : {0}";

        public const string SR_NO_PATTERN                       = @"^[A-Z0-9]*$";
        public const string ADDRESS_FORMAT_PATTERN              = @"^(((25[0-5]|2[0-4][0-9]|[1]?[0-9]{1,2})\.){3}(25[0-5]|2[0-4][0-9]|[1]?[0-9]{1,2}))?$"; 
        public const string ADDRESS_CHARACTER_PATTERN           = @"^[0-9.]*$";       
        public const string DEV_NAME_PATTERN                    = @"^[a-zA-Z0-9 ]*$";
        public const string MODEL_NAME_PATTERN                  = @"^[a-zA-Z0-9 ]*$";
        public const string PORT_NO_PATTERN                     = @"^[0-9]*$";
        public const string PASSWORD_PATTERN                    = @"^[ -~]*$";

        public const string PORT_NO_NODE                        = "CommSetting/PortNo";
        public const string USE_SSL_NODE                        = "CommSetting/UseSSL";
        public const string PASSWORD_NODE                       = "CommSetting/Password";

        public const int TOTAL_NUMBER_OF_ARGUMENTS              = 1;
        public const int FILE_LENGTH_FOR_EMPTY                  = 0;       
        public const int MAXIMUM_SR_NO_LENGTH                   = 16;
        public const int MINIMUM_SR_NO_LENGTH                   = 16;
        public const int MAXIMUM_ADDRESS_LENGTH                 = 15;
        public const int MINIMUM_ADDRESS_LENGTH                 = 1;
        public const int MAXIMUM_DEVNAME_LENGTH                 = 24;
        public const int MINIMUM_DEVNAME_LENGTH                 = 0;
        public const int MAXIMUM_MODELNAME_LENGTH               = 24;
        public const int MINIMUM_MODELNAME_LENGTH               = 0;
        public const int MINIMUM_PORTNO_LENGTH                  = 1;
        public const int MAXIMUM_PORTNO_LENGTH                  = 65535;
        public const int MAXIMUM_PASSWORD_LENGTH                = 64;
        public const int MINIMUM_PASSWORD_LENGTH                = 0;
        public const int ARRAY_SIZE_FOR_DECRYPTION              = 16;
        public const int TOTAL_XML_NODES                        = 8;
    }
}