using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.IO.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.Common.Utils.Const
{
    public class DebugConstants : ConstantsImplementation
    {

        #region PATHS

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public override string MiSIM_FULL_PATH => Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.*/
        public override string JAVA_INSTANCES_FOLDER_NAME => "JavaInstances";
        public override string JAVA_INSTANCES_FULL_PATH => $@"{MiSIM_FULL_PATH}\{JAVA_INSTANCES_FOLDER_NAME}";
        public override string JAVA_EXE_PATH => @"bin\java.exe";
        public override string SERVER_INSTANCE_FULL_PATH => Directory.GetCurrentDirectory();
        public override string SERVERS_VERSIONS_FOLDER_NAME => "MinecraftServersVersions";
        public override string SERVERS_VERSIONS_FULL_PATH => $@"{MiSIM_FULL_PATH}\{SERVERS_VERSIONS_FOLDER_NAME}";
        public override string CONFIG_FILE_NAME => "launcher.config.json";
        public override string CONFIG_FILE_FULL_PATH => $@"{SERVER_INSTANCE_FULL_PATH}\{CONFIG_FILE_NAME}";
        public override string LOG_FILE_NAME => "launcher.log";
        public override string LOG_FILE_FULL_PATH => $@"{SERVER_INSTANCE_FULL_PATH}\{LOG_FILE_NAME}";
        public override string SERVER_DEFAULT_JAR_NAME => "server.jar";

        #endregion PATHS

        #region MINECRAFT SERVER CONFIGURATIONS

        public override string SERVER_JAR_ARG => "-jar";
        public override string SERVER_NOGUI_ARG => "nogui";
        public override string SERVER_MIN_RAM_ARG => "-Xms";
        public override string SERVER_MAX_RAM_ARG => "-Xmx";
        public override string SERVER_DEFAULT_MIN_RAM_VALUE => "1G";
        public override string SERVER_DEFAULT_MAX_RAM_VALUE => "4G";
        public override string SERVER_DEFAULT_MIN_RAM_FULL_ARG => $"{SERVER_MIN_RAM_ARG}{SERVER_DEFAULT_MIN_RAM_VALUE}";
        public override string SERVER_DEFAULT_MAX_RAM_FULL_ARG => $"{SERVER_MAX_RAM_ARG}{SERVER_DEFAULT_MAX_RAM_VALUE}";
        public override string SERVER_DEFAULT_JAVA_VERSION => "jdk-17.0.3.1";
        public override string SERVER_DEFAULT_VERSION => "1.19";
        public override bool SERVER_DEFAULT_VANILLA => true;
        public override ServerInstanceLauncherConfiguration DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION => new()
        {
            JavaVersion = SERVER_DEFAULT_JAVA_VERSION,
            ServerVersion = SERVER_DEFAULT_VERSION,
            Vanilla = SERVER_DEFAULT_VANILLA,
            MinRam = SERVER_DEFAULT_MIN_RAM_VALUE,
            MaxRam = SERVER_DEFAULT_MAX_RAM_VALUE
        };

        #endregion MINECRAFT SERVER CONFIGURATIONS

        #region MINECRAFT SERVER OUTPUT

        public override string MINECRAFT_SERVER_OUTPUT_ERROR => "ERROR";
        public override string MINECRAFT_SERVER_OUTPUT_WARNING => "WARN";
        public override string MINECRAFT_SERVER_OUTPUT_INFO => "INFO";

        #endregion MINECRAFT SERVER OUTPUT

        #region CONSOLE COLORS

        public override ConsoleColor CONSOLE_DEFAULT_FOREGROUND_COLOR => ConsoleColor.White;
        public override ConsoleColor CONSOLE_INFO_FOREGROUND_COLOR => ConsoleColor.DarkGreen;
        public override ConsoleColor CONSOLE_WARNING_FOREGROUND_COLOR => ConsoleColor.DarkYellow;
        public override ConsoleColor CONSOLE_ERROR_FOREGROUND_COLOR => ConsoleColor.DarkRed;

        #endregion CONSOLE COLORS

        #region APPLICATION ARGS

        public override string[] APPLICATION_PAUSE_PARAM_NAMES => new string[] { "--pause", "-p" };
        public override string APPLICATION_PAUSE_PARAM_DESCRIPTION => "Pause the program before exit";
        public override OptionWrapper<bool> APPLICATION_PAUSE_PARAM_OPTION => new OptionWrapper<bool>(APPLICATION_PAUSE_PARAM_NAMES, APPLICATION_PAUSE_PARAM_DESCRIPTION);
        public override string[] APPLICATION_CONSOLE_LOG_PARAM_NAMES => new string[] { "--console-log", "-c" };
        public override string APPLICATION_CONSOLE_LOG_PARAM_DESCRIPTION => "Log everything to the console";
        public override OptionWrapper<bool> APPLICATION_CONSOLE_LOG_PARAM_OPTION => new OptionWrapper<bool>(APPLICATION_CONSOLE_LOG_PARAM_NAMES, APPLICATION_CONSOLE_LOG_PARAM_DESCRIPTION);
        public override string[] APPLICATION_FILE_LOG_PARAM_NAMES => new string[] { "--file-log", "-f" };
        public override string APPLICATION_FILE_LOG_PARAM_DESCRIPTION => "Log everything to a log file";
        public override OptionWrapper<bool> APPLICATION_FILE_LOG_PARAM_OPTION => new OptionWrapper<bool>(APPLICATION_FILE_LOG_PARAM_NAMES, APPLICATION_FILE_LOG_PARAM_DESCRIPTION);

        #endregion APPLICATION ARGS

    }
}
