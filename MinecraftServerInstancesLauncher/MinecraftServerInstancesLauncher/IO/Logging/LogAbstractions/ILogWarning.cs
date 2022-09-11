namespace MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions
{
    /// <summary>
    /// Functional interface to log a Warning message.
    /// </summary>
    public interface ILogWarning
    {
        /// <summary>
        /// Logs a warning message.
        /// </summary>
        public void LogWaring(string message);
    }
}
