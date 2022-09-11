namespace MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions
{
    /// <summary>
    /// Functional interface to log info messages.
    /// </summary>
    public interface ILogInfo
    {
        /// <summary>
        /// Logs an info message.
        /// </summary>
        public void LogInfo(string message);
    }
}
