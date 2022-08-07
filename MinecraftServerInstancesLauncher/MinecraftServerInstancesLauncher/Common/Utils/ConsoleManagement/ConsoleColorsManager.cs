using MinecraftServerInstancesLauncher.Common.Utils.Const;

namespace MinecraftServerInstancesLauncher.Common.Utils.ConsoleManagement
{
    public static class ConsoleColorsManager
    {
        public static ConsoleColor BackgroundColor => Console.BackgroundColor;
        public static ConsoleColor ForegroundColor => Console.ForegroundColor;

        #region CONSOLE COLORS SETTING
        public static void SetConsoleColors(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            SetConsoleBackgroundColor(backgroundColor);
            SetConsoleForegroundColor(foregroundColor);
        }

        public static void SetConsoleBackgroundColor(ConsoleColor backgroundColor) => Console.BackgroundColor = backgroundColor;

        public static void SetConsoleForegroundColor(ConsoleColor foregroundColor) => Console.ForegroundColor = foregroundColor;
        #endregion CONSOLE COLORS SETTING

        #region DEFAULT CONSOLE COLORS SETTING
        public static void SetDefaultConsoleColors()
        {
            SetDefaultConsoleForegroundColor();
        }

        private static void SetDefaultConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsImplementation.Instance.CONSOLE_DEFAULT_FOREGROUND_COLOR);
        #endregion DEFAULT CONSOLE COLORS SETTING

        #region WARNING CONSOLE COLORS SETTING
        public static void SetWarningConsoleColors()
        {
            SetWarningConsoleForegroundColor();
        }


        private static void SetWarningConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsImplementation.Instance.CONSOLE_WARNING_FOREGROUND_COLOR);
        #endregion WARNING CONSOLE COLORS SETTING

        #region INFO CONSOLE COLORS SETTING
        public static void SetInfoConsoleColors()
        {
            SetInfoConsoleForegroundColor();
        }

        private static void SetInfoConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsImplementation.Instance.CONSOLE_INFO_FOREGROUND_COLOR);
        #endregion INFO CONSOLE COLORS SETTING
        
        #region ERROR CONSOLE COLORS SETTING
        public static void SetErrorConsoleColors()
        {
            SetErrorConsoleForegroundColor();
        }

        private static void SetErrorConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsImplementation.Instance.CONSOLE_ERROR_FOREGROUND_COLOR);
        #endregion ERROR CONSOLE COLORS SETTING
    }
}
