using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.Common.Utils
{
    /// <summary>
    /// Interface to build Minecraft Launch strings.
    /// </summary>
    public interface IMinecraftServerStringBuilder
    {
        /// <summary>
        /// Builds the Minecraft server arguments string based on ServerInstanceLauncherConfiguration.
        /// </summary>
        public string BuildArgs(ServerInstanceLauncherConfiguration config);
        /// <summary>
        /// Builds the Minecraft server Java path based on ServerInstanceLauncherConfiguration.
        /// </summary>
        public string BuildJavaPath(ServerInstanceLauncherConfiguration config);
        /// <summary>
        /// Builds the Minecraft server launch string (Java path + arguments).
        /// </summary>
        public string BuildLaunchString(ServerInstanceLauncherConfiguration config);
    }
}
