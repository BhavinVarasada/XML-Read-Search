using Skillup.XMLReadSearch.Utility;

namespace Skillup.XMLReadSearch
{
    /// <summary>
    /// This is the main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method and it will call the start method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Validate the command line argument count is one or not.
            if (args.Length != Constant.TOTAL_NUMBER_OF_ARGUMENTS)
            {
                Output.WriteLine(string.Format(Constant.ERROR_MSG_COMMANDLINE_ARGUMENT, System.AppDomain.CurrentDomain.FriendlyName));
                return;
            }

            string strFilePath = args[0].Trim();
            Execution objExecution = new Execution();
            objExecution.Start(strFilePath);
        }
    }
}