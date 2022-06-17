using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftServerInstancesLauncher.IO.Config;
using MinecraftServerInstancesLauncher.Common.Utils;

namespace MinecraftServerInstancesLauncher.Common.Utils
{
    public static class MinecraftServerStringBuilder
    {
        public static string BuildArgs(ServerInstanceLauncherConfiguration config)
        {
            return $@"{Constants.SERVER_MAX_RAM_ARG}{config.MaxRam} {Constants.SERVER_MIN_RAM_ARG}{config.MinRam} {Constants.SERVER_JAR_ARG} ""{Constants.SERVERS_VERSIONS_FULL_PATH}\{config.ServerVersion}.jar"" {Constants.SERVER_NOGUI_ARG}";
        }

        public static string BuildJavaPath(ServerInstanceLauncherConfiguration config)
        {
            return $@"""{Constants.JAVA_INSTANCES_FULL_PATH}\{config.JavaVersion}\{Constants.JAVA_EXE_PATH}""";
        }
    }
}
