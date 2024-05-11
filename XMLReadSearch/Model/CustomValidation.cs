using Skillup.XMLReadSearch.Utility;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// To check custom perticulers errors from XML file.
    /// </summary>
    public class CustomValidation
    {
        #region Node Exist or Not
        /// <summary>
        /// check that node is present or not in xml file.
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckNodeExist(XmlNode Node, string strMsgAttributeName, List<string> lstErrorList, ref bool bHasErrors)
        {
            string strMessage = Node == null && (bHasErrors = true) ? string.Format(strMsgAttributeName, Constant.ERROR_MSG_NOT_PRESENT) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Value Empty or Not
        /// <summary>
        /// check that nodes value is empty or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValueEmpty(string strValue, string strMsgAttributeName, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = string.IsNullOrWhiteSpace(strValue) && !bHasErrors;
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, Constant.ERROR_MSG_EMPTY) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Duplicate Value or Not
        /// <summary>
        /// check that cuurent node value is duplicate or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="lstDuplicateValueList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckDuplicateValue(string strValue, string strMsgAttributeName, List<string> lstErrorList, List<string> lstDuplicateValueList, ref bool bHasErrors)
        {
            switch (!bHasErrors && lstDuplicateValueList.Contains(strValue))
            {
                case true:
                    // validate for duplicate values.
                    lstErrorList.Add(string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_DUPLICATE));
                    bHasErrors = true;
                    break;
                default:
                    // Add current SrNo value to the set of encountered values
                    lstDuplicateValueList.Add(strValue);
                    break;
            }
        }
        #endregion

        #region Valid Format or Not
        /// <summary>
        /// check that value has valid format or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="strPattern"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidFormat(string strValue, string strMsgAttributeName, string strPattern, List<string> lstErrorList, ref bool bHasErrors)
        {
            string strMessage = !Regex.IsMatch(strValue, strPattern) && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_FORMAT) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Type Node Valid Format or Not
        /// <summary>
        /// check that <Type> node has valid format or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidFormatForType(string strValue, string strMsgAttributeName, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = !bHasErrors && !Enum.TryParse(strValue, out DeviceType _);
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_FORMAT) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region UseSSL Node Valid Format or Not
        /// <summary>
        /// check that UseSSL has valid format or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidFormatForUseSSl(string strValue, string strMsgAttributeName, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = !bHasErrors && !string.Equals(strValue, Constant.USE_SSL_TRUE) && !string.Equals(strValue, Constant.USE_SSL_FALSE);
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_FORMAT) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Valid Length or Not
        /// <summary>
        /// check that value has valid length or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="nMaximumLength"></param>
        /// <param name="nMinimumLength"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidLength(string strValue, string strMsgAttributeName, int nMaximumLength, int nMinimumLength, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = !bHasErrors && (strValue.Length > nMaximumLength ||
                                                   (!string.IsNullOrWhiteSpace(strValue) && strValue.Length < nMinimumLength));
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_INVALID_LENGTH) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region PortNo Valid Length or Not
        /// <summary>
        /// check that Portno value has valid length or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="nMaximumLength"></param>
        /// <param name="nMinimumLength"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        public static void CheckValidLengthForPortNo(string strValue, string strMsgAttributeName, int nMaximumLength, int nMinimumLength, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = int.TryParse(strValue, out int nValue) && (nValue > nMaximumLength || nValue < nMinimumLength);
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_INVALID_LENGTH) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Valid Character and Format both
        /// <summary>
        /// check that value has valid characters or format both.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="strCharacterPattern"></param>
        /// <param name="strFormatPattern"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidCharactersOrFormat(string strValue, string strMsgAttributeName, string strCharacterPattern, string strFormatPattern, List<string> lstErrorList, ref bool bHasErrors)
        {
            switch (Regex.IsMatch(strValue, strCharacterPattern) && Regex.IsMatch(strValue, strFormatPattern))
            {
                // Validate Address value against supported character in IP Address.
                case false when !Regex.IsMatch(strValue, strCharacterPattern):
                    lstErrorList.Add(string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_CHAR));
                    bHasErrors = true;
                    break;
                // Validate Address value against supported format of IPV4.
                case false when !Regex.IsMatch(strValue, strFormatPattern):
                    lstErrorList.Add(string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_FORMAT));
                    bHasErrors = true;
                    break;
            }
        }
        #endregion

        #region Valid Characters or Not
        /// <summary>
        /// check that value has valid supported characters or not.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="strPattern"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <returns></returns>
        public static void CheckValidCharacters(string strValue, string strMsgAttributeName, string strPattern, List<string> lstErrorList, ref bool bHasErrors)
        {
            bool bIsValidCondition = !Regex.IsMatch(strValue, strPattern);
            string strMessage = bIsValidCondition && (bHasErrors = true) ? string.Format(strMsgAttributeName, strValue + Constant.ERROR_MSG_NOT_SUPPORTED_CHAR) : string.Empty;
            lstErrorList.Add(strMessage);
        }
        #endregion

        #region Add Original Value of Node.
        /// <summary>
        /// check that if node value has error free then add its original value into list.
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="strMsgAttributeName"></param>
        /// <param name="lstErrorList"></param>
        /// <param name="bHasErrors"></param>
        /// <param name="nNonErrorCount"></param>
        public static void AddOriginalValue(string strValue, string strMsgAttributeName, List<string> lstErrorList, bool bHasErrors, ref int nNonErrorCount)
        {
            bool IsValidCondition = !bHasErrors;
            string strMessage = IsValidCondition ? string.Format(strMsgAttributeName, strValue) : string.Empty;
            lstErrorList.Add(strMessage);
            nNonErrorCount += IsValidCondition ? 1 : 0;
        }
        #endregion
    }
}