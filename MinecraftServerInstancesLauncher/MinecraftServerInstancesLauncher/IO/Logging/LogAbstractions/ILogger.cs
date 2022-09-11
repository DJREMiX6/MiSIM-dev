using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;

namespace MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions
{
    /// <summary>
    /// Interface to log messages.
    /// </summary>
    public interface ILogger : ILogWarning, ILogError, ILogInfo
    {
        /// <summary>
        /// Logs a message.
        /// </summary>
        public void Log(string message);
    }
}
