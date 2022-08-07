using MinecraftServerInstancesLauncher.IO.Config;
using MinecraftServerInstancesLauncher.Common.Utils.Const;

namespace MinecraftServerInstancesLauncher.Common.Utils
{
    public static class MinecraftServerStringBuilder
    {
        public static string BuildArgs(ServerInstanceLauncherConfiguration config)
        {
            return $@"{ConstantsImplementation.Instance.SERVER_MAX_RAM_ARG}{config.MaxRam} {ConstantsImplementation.Instance.SERVER_MIN_RAM_ARG}{config.MinRam} {ConstantsImplementation.Instance.SERVER_JAR_ARG} ""{ConstantsImplementation.Instance.SERVERS_VERSIONS_FULL_PATH}\{config.ServerVersion}.jar"" {ConstantsImplementation.Instance.SERVER_NOGUI_ARG}";
        }

        public static string BuildJavaPath(ServerInstanceLauncherConfiguration config)
        {
            return $@"""{ConstantsImplementation.Instance.JAVA_INSTANCES_FULL_PATH}\{config.JavaVersion}\{ConstantsImplementation.Instance.JAVA_EXE_PATH}""";
        }
    }
}
