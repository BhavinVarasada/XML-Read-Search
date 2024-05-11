using Skillup.XMLReadSearch.Model;
using Skillup.XMLReadSearch.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml;
using System.Xml.Schema;

namespace Skillup.XMLReadSearch
{
    /// <summary>
    /// Class for all validation regarding XML file.
    /// </summary>
    public class XMLValidation
    {
        private bool m_bHasErrors = false;

        #region XML File Validation
        /// <summary>
        /// method will check only XML file validation
        /// </summary>
        /// <param name="strFilePath"></param>
        public bool XMLFileValidation(string strFilePath)
        {
            try
            {
                // to check file is exist or not.
                if (!File.Exists(strFilePath))
                {
                    throw new CustomException(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_FILE_NOT_EXIST));
                }

                string strFileExtention = Path.GetExtension(strFilePath).Trim();
                //to check file extention is valid or not.
                if (!strFileExtention.Equals(Constant.FILE_EXTENTION, StringComparison.OrdinalIgnoreCase))
                {
                    throw new CustomException(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_FILE_EXTENTION));
                }

                //to check file is empty or not
                if (new FileInfo(strFilePath).Length == Constant.FILE_LENGTH_FOR_EMPTY)
                {
                    throw new CustomException(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_EMPTY_XML_FILE));
                }
                else
                {
                    XmlDocument objXmlDocument = new XmlDocument();
                    try
                    {
                        objXmlDocument.Load(strFilePath);
                    }
                    catch (Exception ex)
                    {
                        throw new CustomException(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_FILE_FORMAT));
                    }

                    //select Device nodes from xml file.
                    XmlNodeList DevNodes = objXmlDocument.SelectNodes(Constant.XML_ELEMENT_NAME);

                    //to check that format is valid but devices is not available in file.
                    if (DevNodes.Count == 0)
                    {
                        throw new CustomException(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_NO_DEVICE_IN_FILE));
                    }

                    //if file releated validation is ok then method call to check valodation of XML file with XSD file.
                    bool bValidationFailed = XMLValidationWithXSD(objXmlDocument);
                    if (bValidationFailed)
                    {
                        return false;
                    }
                }
            }
            // Handle all file related exceptions.
            catch (IOException ex)
            {
                // catch all general exception from I/O Operation.               
                throw new CustomException(Constant.ERROR_MSG_IO_EXCEPTION, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                // When operating system denies access to the file.                
                throw new CustomException(Constant.ERROR_MSG_UNAUTHORIZED_EXCEPTION, ex);
            }
            catch (SecurityException ex)
            {
                // catch when any security violation occures.               
                throw new CustomException(Constant.ERROR_MSG_SECURITY_EXCEPTION, ex);
            }
            return true;
        }
        #endregion

        #region XML File Validation With XSD.
        /// <summary>
        /// It will check all XML file validation with XSD file.
        /// </summary>
        /// <param name="objXmlDocument"></param>
        /// <returns></returns>
        private bool XMLValidationWithXSD(XmlDocument objXmlDocument)
        {
            //this will get the current mode path.
            string strEXEFilePath = AppDomain.CurrentDomain.BaseDirectory;

            //it will combine the current mode path with the xsd file name.
            string strXSDFilePath = Path.Combine(strEXEFilePath, Constant.XSD_FILE_NAME);

            // Create XmlReaderSettings and XmlSchemaSet
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, strXSDFilePath);
            settings.Schemas = schemas;

            // Validate the XML document
            objXmlDocument.Schemas = schemas;
            objXmlDocument.Validate(ValidationEventHandler);

            // If xsd generate error then only Validate custom validations for xml file.          
            if (m_bHasErrors)
            {
                // Validate custom validations for xml file.
                bool bIsError = XMLDataValidation(objXmlDocument);
                if (bIsError)
                {
                    return true;
                }
                return true;
            }
            return false;
        }

        // Validation Event handler to validate with xsd file.
        void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            m_bHasErrors = true;
            return;
        }
        #endregion

        #region XML File Data Validation.
        /// <summary>
        /// Method to validate XML file data.
        /// </summary>
        /// <param name="objXmlDocument"></param>
        private bool XMLDataValidation(XmlDocument objXmlDocument)
        {
            bool bIsError = false;

            // Select 'Dev' node from root node Devices.
            XmlNodeList devNodes = objXmlDocument.SelectNodes("/Devices/Dev");

            //List to encountered duplicate values for Srno and Address.
            List<string> lstDuplicateValueList = new List<string>();

            //Define List to store the errors or actual value.
            List<string> lstErrorList = new List<string>();

            int nDeviceIndex = 1;
            //To get Each <Dev> node line by line.
            foreach (XmlNode devNode in devNodes)
            {
                bool bHasErrors = false;
                int nNonErrorCount = 0;

                #region Validate All Nodes of Each Device
                foreach (XMLNodes objXMLNodes in Enum.GetValues(typeof(XMLNodes)))
                {
                    switch (objXMLNodes)
                    {
                        case XMLNodes.SrNo:
                            XmlAttribute SrNoAttribute = devNode.Attributes[XMLNodes.SrNo.ToString()];
                            string strValue = SrNoAttribute != null ? SrNoAttribute.Value.Trim() : string.Empty;
                            // Validate node is present or not.                          
                            CustomValidation.CheckNodeExist(SrNoAttribute, Constant.MSG_XML_SRNO_ATTRIBUTE, lstErrorList, ref bHasErrors);
                            // Validate value is empty or not.
                            CustomValidation.CheckValueEmpty(strValue, Constant.MSG_XML_SRNO_ATTRIBUTE, lstErrorList, ref bHasErrors);
                            // Validate value is duplicate or not.
                            CustomValidation.CheckDuplicateValue(strValue, Constant.MSG_XML_SRNO_ATTRIBUTE, lstErrorList, lstDuplicateValueList, ref bHasErrors);
                            // Validate value has valid characteres or not.
                            CustomValidation.CheckValidCharacters(strValue, Constant.MSG_XML_SRNO_ATTRIBUTE, Constant.SR_NO_PATTERN, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLength(strValue, Constant.MSG_XML_SRNO_ATTRIBUTE, Constant.MAXIMUM_SR_NO_LENGTH, Constant.MINIMUM_SR_NO_LENGTH, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_SRNO_ATTRIBUTE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.Address:
                            bHasErrors = false;
                            XmlNode AddressNode = devNode.SelectSingleNode(XMLNodes.Address.ToString());
                            strValue = AddressNode != null ? AddressNode.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(AddressNode, Constant.MSG_XML_ADDRESS_NODE, lstErrorList, ref bHasErrors);
                            // Validate value is empty or not.
                            CustomValidation.CheckValueEmpty(strValue, Constant.MSG_XML_ADDRESS_NODE, lstErrorList, ref bHasErrors);
                            // Validate value is duplicate or not.
                            CustomValidation.CheckDuplicateValue(strValue, Constant.MSG_XML_ADDRESS_NODE, lstErrorList, lstDuplicateValueList, ref bHasErrors);
                            // Validate value has valid characters and format or not.
                            CustomValidation.CheckValidCharactersOrFormat(strValue, Constant.MSG_XML_ADDRESS_NODE, Constant.ADDRESS_CHARACTER_PATTERN, Constant.ADDRESS_FORMAT_PATTERN, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLength(strValue, Constant.MSG_XML_ADDRESS_NODE, Constant.MAXIMUM_ADDRESS_LENGTH, Constant.MINIMUM_ADDRESS_LENGTH, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_ADDRESS_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.DevName:
                            bHasErrors = false;
                            XmlNode DevName = devNode.SelectSingleNode(XMLNodes.DevName.ToString());
                            strValue = DevName != null ? DevName.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(DevName, Constant.MSG_XML_DEVNAME_NODE, lstErrorList, ref bHasErrors);
                            // Validate value has valid characteres or not.
                            CustomValidation.CheckValidCharacters(strValue, Constant.MSG_XML_DEVNAME_NODE, Constant.DEV_NAME_PATTERN, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLength(strValue, Constant.MSG_XML_DEVNAME_NODE, Constant.MAXIMUM_DEVNAME_LENGTH, Constant.MINIMUM_DEVNAME_LENGTH, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_DEVNAME_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.ModelName:
                            bHasErrors = false;
                            XmlNode ModelName = devNode.SelectSingleNode(XMLNodes.ModelName.ToString());
                            strValue = ModelName != null ? ModelName.InnerText.Trim() : string.Empty;
                            // Validate value has valid characteres or not.
                            CustomValidation.CheckValidCharacters(strValue, Constant.MSG_XML_MODELNAME_NODE, Constant.MODEL_NAME_PATTERN, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLength(strValue, Constant.MSG_XML_MODELNAME_NODE, Constant.MAXIMUM_MODELNAME_LENGTH, Constant.MINIMUM_MODELNAME_LENGTH, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_MODELNAME_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.Type:
                            bHasErrors = false;
                            XmlNode TypeNode = devNode.SelectSingleNode(XMLNodes.Type.ToString());
                            strValue = TypeNode != null ? TypeNode.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(TypeNode, Constant.MSG_XML_TYPE_NODE, lstErrorList, ref bHasErrors);
                            // Validate value is empty or not.
                            CustomValidation.CheckValueEmpty(strValue, Constant.MSG_XML_TYPE_NODE, lstErrorList, ref bHasErrors);
                            // Validate value has valid format or not.
                            CustomValidation.CheckValidFormatForType(strValue, Constant.MSG_XML_TYPE_NODE, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_TYPE_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.PortNo:
                            bHasErrors = false;
                            XmlNode PortNoNode = devNode.SelectSingleNode(Constant.PORT_NO_NODE);
                            strValue = PortNoNode != null ? PortNoNode.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(PortNoNode, Constant.MSG_XML_PORTNO_NODE, lstErrorList, ref bHasErrors);
                            // Validate value is empty or not.
                            CustomValidation.CheckValueEmpty(strValue, Constant.MSG_XML_PORTNO_NODE, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLengthForPortNo(strValue, Constant.MSG_XML_PORTNO_NODE, Constant.MAXIMUM_PORTNO_LENGTH, Constant.MINIMUM_PORTNO_LENGTH, lstErrorList, ref bHasErrors);
                            // Validate value has valid format or not.
                            CustomValidation.CheckValidFormat(strValue, Constant.MSG_XML_PORTNO_NODE, Constant.PORT_NO_PATTERN, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_PORTNO_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.UseSSL:
                            bHasErrors = false;
                            XmlNode UseSSLNode = devNode.SelectSingleNode(Constant.USE_SSL_NODE);
                            strValue = UseSSLNode != null ? UseSSLNode.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(UseSSLNode, Constant.MSG_XML_USESSL_NODE, lstErrorList, ref bHasErrors);
                            // Validate value is empty or not.
                            CustomValidation.CheckValueEmpty(strValue, Constant.MSG_XML_USESSL_NODE, lstErrorList, ref bHasErrors);
                            // Validate value has valid format or not.
                            CustomValidation.CheckValidFormatForUseSSl(strValue, Constant.MSG_XML_USESSL_NODE, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_USESSL_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        case XMLNodes.Password:
                            bHasErrors = false;
                            XmlNode PasswordNode = devNode.SelectSingleNode(Constant.PASSWORD_NODE);
                            strValue = PasswordNode != null ? PasswordNode.InnerText.Trim() : string.Empty;
                            // Validate node is present or not.
                            CustomValidation.CheckNodeExist(PasswordNode, Constant.MSG_XML_PASSWORD_NODE, lstErrorList, ref bHasErrors);
                            // Validate value has valid characteres or not.
                            CustomValidation.CheckValidCharacters(strValue, Constant.MSG_XML_PASSWORD_NODE, Constant.PASSWORD_PATTERN, lstErrorList, ref bHasErrors);
                            // Validate value has valid length or not.
                            CustomValidation.CheckValidLength(strValue, Constant.MSG_XML_PASSWORD_NODE, Constant.MAXIMUM_PASSWORD_LENGTH, Constant.MINIMUM_PASSWORD_LENGTH, lstErrorList, ref bHasErrors);
                            // If error is not generated then add original value into list.
                            CustomValidation.AddOriginalValue(strValue, Constant.MSG_XML_PASSWORD_NODE, lstErrorList, bHasErrors, ref nNonErrorCount);
                            break;

                        default:
                            Output.WriteLine(Constant.NODE_ERROR_MSG);
                            break;
                    }
                }
                #endregion

                #region Print Errors and Information
                //If Errors is generated then print all errors and value for it each <Dev> node.               
                if (nNonErrorCount < Constant.TOTAL_XML_NODES)
                {
                    Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMON, Constant.ERROR_MSG_DEVICE_DATA_VALIDATION));
                    Output.WriteLine(string.Format(Constant.MSG_DEVICE_INDEX, nDeviceIndex));                    
                    lstErrorList.RemoveAll(string.IsNullOrEmpty);
                    foreach (string strError in lstErrorList)
                    {
                        Output.WriteLine(strError);
                    }
                    bIsError = true;
                    break;
                }
                nDeviceIndex++;

                //if error is not genereted for each dev node then clear the list for next dev node.
                lstErrorList.Clear();
                #endregion
            }
            return bIsError;
        }
        #endregion
    }
}