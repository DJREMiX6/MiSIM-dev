namespace MinecraftServerInstancesLauncher.IO.Logging.LogFileManagement
{
    public class LogFileGate
    {

        #region SINGLETON VARS

        private static LogFileGate _instance;
        public static LogFileGate Instance => _instance ??= new LogFileGate();

        #endregion SINGLETON VARS

        #region PRIVATE FIELDS

        private FileInfo _logFileInfo;
        private List<LogFileGateActionWrapper> _logFileGateActions;

        #endregion PRIVATE FIELDS

        #region CTORS

        private LogFileGate()
        {
            _logFileInfo = new(ConstantsImplementation.Instance.LOG_FILE_FULL_PATH);
            _logFileGateActions = new();
            //TODO EVENTS SUBSCRIPTION
        }

        #endregion CTORS

        public async void Write(string text)
        {
            using (var writer = new StreamWriter(_logFileInfo.FullName, true))
            {
                await writer.WriteAsync(text);
            }
        }

        public async void WriteLine(string text)
        {
            using (var writer = new StreamWriter(_logFileInfo.FullName, true))
            {
                await writer.WriteLineAsync(text);
            }
        }

    }
}
