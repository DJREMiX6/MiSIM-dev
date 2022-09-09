using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.Common.Utils.Const
{
    /// <summary>
    /// Contains the abstraction of all the constants as a Singleton.
    /// </summary>
    public abstract class ConstantsAbstraction
    {

        #region PRIVATE STATIC FIELDS

        private static ConstantsAbstraction _instance;

        #endregion PRIVATE STATIC FIELDS

        #region PUBLIC STATIC PROPS

        /// <summary>
        /// Sets or gets the Singleton's instance.
        /// <exception cref="value"">Throws <c>NullReferenceException</c> if Instance is null.</exception>
        /// </summary>
        public static ConstantsAbstraction Instance { 
            get
            {
                if(_instance != null )
                {
                    return _instance;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            set
            {
                _instance = value;
            }
        }
        public static string APPLICATION_NAME => "MiSIL - Minecraft Server Instances Launcher";

#if DEBUG
        /// <summary>
        /// Returns <c>true</c>.
        /// </summary>
        public static bool DEBUG => true;
#else
        /// <summary>
        /// Returns <c>false</c>.
        /// </summary>
        public static bool DEBUG => false;
#endif

        #endregion PUBLIC STATIC PROPS

        #region PUBLIC ABSTRACT CONSTANT PROPS

        #region PATHS

        public abstract string MiSIM_FULL_PATH { get; }
        public abstract string JAVA_INSTANCES_FOLDER_NAME { get; }
        public abstract string JAVA_INSTANCES_FULL_PATH { get; }
        public abstract string JAVA_EXE_PATH { get; }
        public abstract string SERVER_INSTANCE_FULL_PATH { get; }
        public abstract string SERVERS_VERSIONS_FOLDER_NAME { get; }
        public abstract string SERVERS_VERSIONS_FULL_PATH { get; }
        public abstract string CONFIG_FILE_NAME { get; }
        public abstract string CONFIG_FILE_FULL_PATH { get; }
        public abstract string LOG_FILE_NAME { get; }
        public abstract string LOG_FILE_FULL_PATH { get; }
        public abstract string SERVER_DEFAULT_JAR_NAME { get; }

        #endregion PATHS

        #region MINECRAFT SERVER CONFIGURATIONS

        public abstract string SERVER_JAR_ARG { get; }
        public abstract string SERVER_NOGUI_ARG { get; }
        public abstract string SERVER_MIN_RAM_ARG { get; }
        public abstract string SERVER_MAX_RAM_ARG { get; }
        public abstract string SERVER_DEFAULT_MIN_RAM_VALUE { get; }
        public abstract string SERVER_DEFAULT_MAX_RAM_VALUE { get; }
        public abstract string SERVER_DEFAULT_MIN_RAM_FULL_ARG { get; }
        public abstract string SERVER_DEFAULT_MAX_RAM_FULL_ARG { get; }
        public abstract string SERVER_DEFAULT_JAVA_VERSION { get; }
        public abstract string SERVER_DEFAULT_VERSION { get; }
        public abstract bool SERVER_DEFAULT_VANILLA { get; }
        public abstract ServerInstanceLauncherConfiguration DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION { get; }

        #endregion MINECRAFT SERVER CONFIGURATIONS

        #region MINECRAFT SERVER OUTPUT

        public abstract string MINECRAFT_SERVER_OUTPUT_ERROR { get; }
        public abstract string MINECRAFT_SERVER_OUTPUT_WARNING { get; }
        public abstract string MINECRAFT_SERVER_OUTPUT_INFO { get; }

        #endregion MINECRAFT SERVER OUTPUT

        #region CONSOLE COLORS

        public abstract ConsoleColor CONSOLE_DEFAULT_FOREGROUND_COLOR { get; }
        public abstract ConsoleColor CONSOLE_INFO_FOREGROUND_COLOR { get; }
        public abstract ConsoleColor CONSOLE_WARNING_FOREGROUND_COLOR { get; }
        public abstract ConsoleColor CONSOLE_ERROR_FOREGROUND_COLOR { get; }

        #endregion CONSOLE COLORS

        #region LOG FILE FORMATTING

        public abstract string[] LOG_FILE_DEFAULT_COLOR_TAGS { get; }
        public abstract string[] LOG_FILE_INFO_COLOR_TAGS { get; }
        public abstract string[] LOG_FILE_WARNING_COLOR_TAGS { get; }
        public abstract string[] LOG_FILE_ERROR_COLOR_TAGS { get; }

        #endregion LOG FILE FORMATTING

        #region APPLICATION ARGS

        public abstract string[] APPLICATION_PAUSE_PARAM_NAMES { get; }
        public abstract string APPLICATION_PAUSE_PARAM_DESCRIPTION { get; }
        public abstract OptionWrapper<bool> APPLICATION_PAUSE_PARAM_OPTION { get; }
        public abstract string[] APPLICATION_CONSOLE_LOG_PARAM_NAMES { get; }
        public abstract string APPLICATION_CONSOLE_LOG_PARAM_DESCRIPTION { get; }
        public abstract OptionWrapper<bool> APPLICATION_CONSOLE_LOG_PARAM_OPTION { get; }
        public abstract string[] APPLICATION_FILE_LOG_PARAM_NAMES { get; }
        public abstract string APPLICATION_FILE_LOG_PARAM_DESCRIPTION { get; }
        public abstract OptionWrapper<bool> APPLICATION_FILE_LOG_PARAM_OPTION { get; }

        #endregion APPLICATION ARGS

        #endregion PUBLIC ABSTRACT CONSTANT PROPS

    }
}
