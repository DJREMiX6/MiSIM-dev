using MinecraftServerInstancesLauncher.IO.DataAccessLayer;
using MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions;
using MinecraftServerInstancesLauncher.IO.Logging.LogFileManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using System.ComponentModel;
using System.Diagnostics;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    /// <summary>
    /// Holds all the methods to log messages into a Log file.
    /// </summary>
    public class FileLogger : IMinecraftServerLogger
    {

        #region PRIVATE FIELDS

        private IFileGate _logFileGate;

        #endregion PRIVATE FIELDS

        #region PRIVATE PROPS

        private IFileGate logFileGate => _logFileGate ??= new LogFileGate();

        #endregion PRIVATE PROPS

        #region ILogger IMPLEMENTATION

        public void Log(string message)
        {
            WriteToLogFileGate(LogFileFormatter.FormatDefaultLog(message));
        }

        public void LogError(string message)
        {
            WriteToLogFileGate(LogFileFormatter.FormatErrorLog(message));
        }

        public void LogInfo(string message)
        {
            WriteToLogFileGate(LogFileFormatter.FormatInfoLog(message));
        }

        public void LogWaring(string message)
        {
            WriteToLogFileGate(LogFileFormatter.FormatWarningLog(message));
        }

        #endregion ILogger IMPLEMENTATION

        #region IMinecraftServerInterpretedDataReceiver IMPLEMENTATION

        public void MinecraftServerOutputInterpretedDataReceived(object sender, MinecraftServerInterpretedOutputData data)
        {
            switch (data.Type)
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

        #region PRIVATE METHODS

        /// <summary>
        /// Writes a log message into a Log file accessing it by the <c>LogFIleGate</c>.
        /// </summary>
        private void WriteToLogFileGate(string log)
        {
            logFileGate.WriteAsync(log, true);
        }

        #endregion PRIVATE METHODS

    }
}
