namespace MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions
{
    /// <summary>
    /// Functional interface to log error messages.
    /// </summary>
    public interface ILogError
    {
        /// <summary>
        /// Logs an error message.
        /// </summary>
        public void LogError(string message);
    }
}
