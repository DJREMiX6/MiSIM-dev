using System.Diagnostics;
using MinecraftServerInstancesLauncher.Common.Utils.ConsoleManagement;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    public class ConsoleLogger : ILogger
    {
        #region ILogger IMPLEMENTATION
        public void Log(string message)
        {
            ConsoleColorsManager.SetDefaultConsoleColors();
            Console.WriteLine(message);
        }
        public void LogWaring(string message)
        {
            ConsoleColorsManager.SetWarningConsoleColors();
            Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            ConsoleColorsManager.SetErrorConsoleColors();
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            ConsoleColorsManager.SetInfoConsoleColors();
            Console.WriteLine(message);
        }
        #endregion ILogger IMPLEMENTATION

        #region IProcessDataReceiver IMPLEMENTATION
        public void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is not null)
            {
                Log(e.Data);
            }
        }

        public void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is not null)
            {
                Log(e.Data);
            }
        }
        #endregion IProcessDataReceiver IMPLEMENTATION
    }
}
