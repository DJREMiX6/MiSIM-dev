using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.Common.Utils
{
    public static class Constants
    {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#if DEBUG
        //Project Root Directory
        public static string MiSIM_FULL_PATH => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
#else
        //MiSIM Root Directory
        public static string MiSIM_FULL_PATH => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
#endif
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        private static string JAVA_INSTANCES_FOLDER_NAME => "JavaInstances";
        public static string JAVA_INSTANCES_FULL_PATH => $@"{MiSIM_FULL_PATH}\{JAVA_INSTANCES_FOLDER_NAME}";
        public static string JAVA_EXE_PATH => @"bin\java.exe";
        public static string SERVER_INSTANCE_FULL_PATH => Directory.GetCurrentDirectory();
        private static string SERVERS_VERSIONS_FOLDER_NAME => "MinecraftServersVersions";
        public static string SERVERS_VERSIONS_FULL_PATH => $@"{MiSIM_FULL_PATH}\{SERVERS_VERSIONS_FOLDER_NAME}";
        public static string SERVER_JAR_ARG => "-jar";
        public static string SERVER_NOGUI_ARG => "nogui";
        public static string SERVER_MIN_RAM_ARG => "-Xms";
        public static string SERVER_MAX_RAM_ARG => "-Xmx";
        public static string SERVER_DEFAULT_MIN_RAM_VALUE => "1G";
        public static string SERVER_DEFAULT_MAX_RAM_VALUE => "4G";
        public static string SERVER_DEFAULT_MIN_RAM_FULL_ARG => $"{SERVER_MIN_RAM_ARG}{SERVER_DEFAULT_MIN_RAM_VALUE}";
        public static string SERVER_DEFAULT_MAX_RAM_FULL_ARG => $"{SERVER_MAX_RAM_ARG}{SERVER_DEFAULT_MAX_RAM_VALUE}";
        public static string SERVER_DEFAULT_JAR_NAME => "server.jar";
        public static string SERVER_DEFAULT_JAVA_VERSION => "jdk-17.0.2";
        public static string SERVER_DEFAULT_VERSION => "1.19";
        public static bool SERVER_DEFAULT_VANILLA => true;
        public static string CONFIG_FILE_NAME => "launcher.config.json";
        public static string CONFIG_FULL_FILE_PATH => $@"{SERVER_INSTANCE_FULL_PATH}\{CONFIG_FILE_NAME}";
        public static ServerInstanceLauncherConfiguration DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION => new() 
        { 
            JavaVersion = SERVER_DEFAULT_JAVA_VERSION, 
            ServerVersion = SERVER_DEFAULT_VERSION, 
            Vanilla = SERVER_DEFAULT_VANILLA, 
            MinRam = SERVER_DEFAULT_MIN_RAM_VALUE, 
            MaxRam = SERVER_DEFAULT_MAX_RAM_VALUE 
        };
        public static ConsoleColor CONSOLE_DEFAULT_BACKGROUND_COLOR => ConsoleColor.White;
        public static ConsoleColor CONSOLE_DEFAULT_FOREGROUND_COLOR => ConsoleColor.Black;
        public static ConsoleColor CONSOLE_INFO_BACKGROUND_COLOR => ConsoleColor.DarkGreen;
        public static ConsoleColor CONSOLE_INFO_FOREGROUND_COLOR => ConsoleColor.White;
        public static ConsoleColor CONSOLE_WARNING_BACKGROUND_COLOR => ConsoleColor.DarkYellow;
        public static ConsoleColor CONSOLE_WARNING_FOREGROUND_COLOR => ConsoleColor.Black;
        public static ConsoleColor CONSOLE_ERROR_BACKGROUND_COLOR => ConsoleColor.DarkRed;
        public static ConsoleColor CONSOLE_ERROR_FOREGROUND_COLOR => ConsoleColor.White;
        public static string MINECRAFT_SERVER_OUTPUT_ERROR => "ERROR";
        public static string MINECRAFT_SERVER_OUTPUT_WARNING => "WARNING";
        public static string MINECRAFT_SERVER_OUTPUT_INFO => "INFO";
    }
}

