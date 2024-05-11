using Skillup.XMLReadSearch.Utility;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// Class for Decrypt the password string.
    /// </summary>
    public class Decryption
    {
        const string strKey = "ActySkillup-2024";
        const string strPlaintextPassword = "Acty@123";

        #region Encrypt String
        /// <summary>
        /// Method which is encrypt the password.
        /// </summary>
        /// <returns></returns>
        public static string EncryptString()
        {
            // Array to store intialization vector.
            byte[] btarrIV = new byte[Constant.ARRAY_SIZE_FOR_DECRYPTION];
            byte[] btarrArray;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(strKey);
                aes.IV = btarrIV;

                // It will Encrypt the password with key and initialization vector.
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swStreamWriter = new StreamWriter(cryptoStream))
                        {
                            swStreamWriter.Write(strPlaintextPassword);
                        }

                        btarrArray = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(btarrArray);
        }
        #endregion

        #region Decrypt String
        /// <summary>
        /// Method which is decrypt the password.
        /// </summary>
        /// <param name="strCipherText"></param>
        /// <returns></returns>
        public static string DecryptString(string strCipherText)
        {
            try
            {
                byte[] btarrIV = new byte[Constant.ARRAY_SIZE_FOR_DECRYPTION];
                byte[] buffer = Convert.FromBase64String(strCipherText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(strKey);
                    aes.IV = btarrIV;

                    // It will Decrypt the password with key and initialization vector.
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srStreamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return srStreamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CustomException(Constant.ERROR_MSG_ENCRYPTED_STRING);
            }
        }
        #endregion
    }
}