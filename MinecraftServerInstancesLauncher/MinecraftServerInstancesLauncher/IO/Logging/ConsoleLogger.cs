using System.ComponentModel;
using System.Diagnostics;
using MinecraftServerInstancesLauncher.Common.Utils.ConsoleManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;

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
            ConsoleColorsManager.SetDefaultConsoleColors();
        }

        public void LogError(string message)
        {
            ConsoleColorsManager.SetErrorConsoleColors();
            Console.WriteLine(message);
            ConsoleColorsManager.SetDefaultConsoleColors();
        }

        public void LogInfo(string message)
        {
            ConsoleColorsManager.SetInfoConsoleColors();
            Console.WriteLine(message);
            ConsoleColorsManager.SetDefaultConsoleColors();
        }
        #endregion ILogger IMPLEMENTATION

        #region IProcessDataReceiver IMPLEMENTATION
        public void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is not null)
            {
                LogError(e.Data);
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

        #region IMinecraftServerInterpretedDataReceiver IMPLEMENTATION
        public void MinecraftServerOutputInterpretedDataReceived(object sender, MinecraftServerInterpretedOutputData data)
        {
            switch(data.Type)
            {
                case MinecraftServerOutputType.INFO:
                    LogInfo(data.Data);
                    break;
                case MinecraftServerOutputType.WARNING:
                    LogWaring(data.Data);
                    break;
                case MinecraftServerOutputType.ERROR:
                    LogError(data.Data);
                    break;
                case MinecraftServerOutputType.DEFAULT:
                    Log(data.Data);
                    break;
                default:
                    throw new InvalidEnumArgumentException($"{data.Type} is not a valid {nameof(MinecraftServerOutputType)}.");
            }
        }
        #endregion IMinecraftServerInterpretedDataReceiver IMPLEMENTATION
    }
}
