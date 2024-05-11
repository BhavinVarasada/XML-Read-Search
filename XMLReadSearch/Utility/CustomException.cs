using System;

namespace Skillup.XMLReadSearch.Model
{
    /// <summary>
    /// To handle user defind exception
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomException()
        {
        }

        /// <summary>
        /// parameterized constructor for user defind message
        /// </summary>
        /// <param name="strMessage"></param>
        public CustomException(string strMessage) : base(strMessage)
        {
        }

        /// <summary>
        /// parameterized constructor for add any inner exceptipn message
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="Innerexception"></param>
        public CustomException(string strMessage, Exception InnerexceptionMessage) : base(strMessage, InnerexceptionMessage)
        {
        }

        /// <summary>
        /// parameterized constructor for add any data to the exception message.
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="data"></param>
        public CustomException(string strMessage, object data) : base(strMessage)
        {
        }
    }
}
