namespace MinecraftServerInstancesLauncher.IO.Config
{
    /// <summary>
    /// Holds all the properties needed to start a Minecraft server process.
    /// </summary>
    public class ServerInstanceLauncherConfiguration
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string? JavaVersion { get; set; }
        public string? ServerVersion { get; set; }
        public string? ServerType { get; set; }
        public string? MinRam { get; set; }
        public string? MaxRam { get; set; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Creates a new instance of <c>ServerInstanceLauncherConfiguration</c> based on two others, comparing them.
        /// All the <c>null</c> properties of <c>newConfig</c> will be replaced by the same <c>oldConfig</c> property.
        /// </summary>
        public static ServerInstanceLauncherConfiguration GetConfigCompared(ServerInstanceLauncherConfiguration oldConfig, ServerInstanceLauncherConfiguration newConfig)
        {
            return new ServerInstanceLauncherConfiguration()
            {
                JavaVersion = newConfig.JavaVersion == null ? oldConfig.JavaVersion : newConfig.JavaVersion,
                ServerVersion = newConfig.ServerVersion == null ? oldConfig.ServerVersion : newConfig.ServerVersion,
                ServerType = newConfig.ServerType == null ? oldConfig.ServerType : newConfig.ServerType,
                MinRam = newConfig.MinRam == null ? oldConfig.MinRam : newConfig.MinRam,
                MaxRam = newConfig.MaxRam == null ? oldConfig.MaxRam : newConfig.MaxRam,
            };
        }

    }
}
