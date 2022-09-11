using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.Common.Utils
{
    /// <summary>
    /// Holds all the methods to build the vanilla Minecraft server launch strings.
    /// </summary>
    public class VanillaMinecraftServerStringBuilder : IMinecraftServerStringBuilder
    {
        public string BuildArgs(ServerInstanceLauncherConfiguration config)
        {
            return $@"{ConstantsAbstraction.Instance.SERVER_MAX_RAM_ARG}{config.MaxRam} {ConstantsAbstraction.Instance.SERVER_MIN_RAM_ARG}{config.MinRam} {ConstantsAbstraction.Instance.SERVER_JAR_ARG} ""{ConstantsAbstraction.Instance.SERVERS_VERSIONS_FULL_PATH}\{config.ServerVersion}.jar"" {ConstantsAbstraction.Instance.SERVER_NOGUI_ARG}";
        }

        public string BuildJavaPath(ServerInstanceLauncherConfiguration config)
        {
            return $@"""{ConstantsAbstraction.Instance.JAVA_INSTANCES_FULL_PATH}\{config.JavaVersion}\{ConstantsAbstraction.Instance.JAVA_EXE_PATH}""";
        }

        public string BuildLaunchString(ServerInstanceLauncherConfiguration config)
        {
            return $"{BuildJavaPath(config)} {BuildArgs(config)}";
        }
    }
}
