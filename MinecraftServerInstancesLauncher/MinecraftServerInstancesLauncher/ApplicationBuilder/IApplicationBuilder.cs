namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    /// <summary>
    /// Holds the necessary methods to build the application.
    /// </summary>
    public interface IApplicationBuilder
    {

        /// <summary>
        /// Initializes the necessary classes and configurations at root level.
        /// </summary>
        /// <param name="args">Application arguments</param>
        /// <returns>Returns itself to chain the methods.</returns>
        public IApplicationBuilder Build(string[] args);
        /// <summary>
        /// Starts the application at root level.
        /// </summary>
        /// <returns>Returns itself to chain the methods.</returns>
        public IApplicationBuilder Start();

    }
}
