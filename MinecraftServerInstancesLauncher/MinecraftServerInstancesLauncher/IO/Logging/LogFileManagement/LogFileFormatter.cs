using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using System.ComponentModel;

namespace MinecraftServerInstancesLauncher.IO.Logging.LogFileManagement
{
    /// <summary>
    /// Holds all the methods for Log file formatting.
    /// </summary>
    public static class LogFileFormatter
    {
        /// <summary>
        /// Formats a log string based on the <c>MinecraftServerOutputType</c>.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static string FormatLog(string log, MinecraftServerOutputType logType)
        {
            switch(logType)
            {
                case MinecraftServerOutputType.DEFAULT:
                    return FormatDefaultLog(log);
                case MinecraftServerOutputType.WARNING:
                    return FormatWarningLog(log);
                case MinecraftServerOutputType.INFO:
                    return FormatInfoLog(log);
                case MinecraftServerOutputType.ERROR:
                    return FormatErrorLog(log);
                default:
                    throw new InvalidEnumArgumentException($"{logType} is not a valid {nameof(MinecraftServerOutputType)}.");
            }
        }

        /// <summary>
        /// Formats a log string as DEFAULT.
        /// </summary>
        public static string FormatDefaultLog(string log)
        {
            return ConstantsAbstraction.Instance.LOG_FILE_DEFAULT_COLOR_TAGS[0] + log + ConstantsAbstraction.Instance.LOG_FILE_DEFAULT_COLOR_TAGS[1];
        }

        /// <summary>
        /// Formats a log string as WARNING.
        /// </summary>
        public static string FormatWarningLog(string log)
        {
            return ConstantsAbstraction.Instance.LOG_FILE_WARNING_COLOR_TAGS[0] + log + ConstantsAbstraction.Instance.LOG_FILE_WARNING_COLOR_TAGS[1];
        }

        /// <summary>
        /// Formats a log string as INFO.
        /// </summary>
        public static string FormatInfoLog(string log)
        {
            return ConstantsAbstraction.Instance.LOG_FILE_INFO_COLOR_TAGS[0] + log + ConstantsAbstraction.Instance.LOG_FILE_INFO_COLOR_TAGS[1];
        }

        /// <summary>
        /// Formats a log string as ERROR.
        /// </summary>
        public static string FormatErrorLog(string log)
        {
            return ConstantsAbstraction.Instance.LOG_FILE_ERROR_COLOR_TAGS[0] + log + ConstantsAbstraction.Instance.LOG_FILE_ERROR_COLOR_TAGS[1];
        }
    }
}
