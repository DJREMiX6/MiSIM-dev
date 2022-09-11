using System.ComponentModel;

namespace MinecraftServerInstancesLauncher.Common.Utils.ConsoleColorsManagement
{
    /// <summary>
    /// Static class that holds all the methods for <c>Console</c> background and foreground colors setting.
    /// </summary>
    public static class ConsoleColorsManager
    {
        /// <summary>
        /// Returns the current <c>Console</c> background color.
        /// </summary>
        public static ConsoleColor BackgroundColor => Console.BackgroundColor;

        /// <summary>
        /// Returns the current <c>Console</c> foreground color.
        /// </summary>
        public static ConsoleColor ForegroundColor => Console.ForegroundColor;

        /// <summary>
        /// Sets the <c>Console</c> colors based on <c>ConsoleColorType</c>.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static void SetConsoleColors(ConsoleColorType consoleColorType)
        {
            switch(consoleColorType)
            {
                case ConsoleColorType.DEFAULT:
                    SetDefaultConsoleColors();
                    break;
                case ConsoleColorType.WARNING:
                    SetWarningConsoleColors();
                    break;
                case ConsoleColorType.INFO:
                    SetInfoConsoleColors();
                    break;
                case ConsoleColorType.ERROR:
                    SetErrorConsoleColors();
                    break;
                default:
                    throw new InvalidEnumArgumentException($"{consoleColorType} is not a valid {nameof(ConsoleColorType)}.");
            }
        }

        #region CONSOLE COLORS SETTING

        /// <summary>
        /// Sets both <c>Console</c> background and foreground colors.
        /// </summary>
        public static void SetConsoleColors(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            SetConsoleBackgroundColor(backgroundColor);
            SetConsoleForegroundColor(foregroundColor);
        }

        /// <summary>
        /// Sets the <c>Console</c> background color.
        /// </summary>
        public static void SetConsoleBackgroundColor(ConsoleColor backgroundColor) => Console.BackgroundColor = backgroundColor;

        /// <summary>
        /// Sets the <c>Console</c> foreground color.
        /// </summary>
        public static void SetConsoleForegroundColor(ConsoleColor foregroundColor) => Console.ForegroundColor = foregroundColor;

        #endregion CONSOLE COLORS SETTING

        #region DEFAULT CONSOLE COLORS SETTING

        /// <summary>
        /// Sets the default <c>Console</c> colors.
        /// </summary>
        public static void SetDefaultConsoleColors()
        {
            SetDefaultConsoleForegroundColor();
        }

        /// <summary>
        /// Sets the default <c>Console</c> foreground color.
        /// </summary>
        private static void SetDefaultConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsAbstraction.Instance.CONSOLE_DEFAULT_FOREGROUND_COLOR);
        #endregion DEFAULT CONSOLE COLORS SETTING

        #region WARNING CONSOLE COLORS SETTING

        /// <summary>
        /// Sets the warning <c>Console</c> colors.
        /// </summary>
        public static void SetWarningConsoleColors()
        {
            SetWarningConsoleForegroundColor();
        }

        /// <summary>
        /// Sets the warning <c>Console</c> foreground color.
        /// </summary>
        private static void SetWarningConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsAbstraction.Instance.CONSOLE_WARNING_FOREGROUND_COLOR);

        #endregion WARNING CONSOLE COLORS SETTING

        #region INFO CONSOLE COLORS SETTING

        /// <summary>
        /// Sets the info <c>Console</c> colors.
        /// </summary>
        public static void SetInfoConsoleColors()
        {
            SetInfoConsoleForegroundColor();
        }

        /// <summary>
        /// Sets the info <c>Console</c> foreground color.
        /// </summary>
        private static void SetInfoConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsAbstraction.Instance.CONSOLE_INFO_FOREGROUND_COLOR);

        #endregion INFO CONSOLE COLORS SETTING
        
        #region ERROR CONSOLE COLORS SETTING

        /// <summary>
        /// Sets the error <c>Console</c> colors.
        /// </summary>
        public static void SetErrorConsoleColors()
        {
            SetErrorConsoleForegroundColor();
        }

        /// <summary>
        /// Sets the error <c>Console</c> foreground colors.
        /// </summary>
        private static void SetErrorConsoleForegroundColor() => SetConsoleForegroundColor(ConstantsAbstraction.Instance.CONSOLE_ERROR_FOREGROUND_COLOR);
        #endregion ERROR CONSOLE COLORS SETTING
    }
}
