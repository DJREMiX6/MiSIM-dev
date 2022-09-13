namespace MinecraftServerInstancesLauncher.IO.Config
{
    /// <summary>
    /// Holds all the properties needed to start a Minecraft server process.
    /// </summary>
    public class ServerInstanceLauncherConfiguration
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public string JavaVersion { get; set; }
        public string ServerVersion { get; set; }
        public string ServerType { get; set; }
        public string MinRam { get; set; }
        public string MaxRam { get; set; }
        
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
