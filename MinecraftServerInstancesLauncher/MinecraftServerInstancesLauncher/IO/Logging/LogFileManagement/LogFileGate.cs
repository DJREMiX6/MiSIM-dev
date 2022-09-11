namespace MinecraftServerInstancesLauncher.IO.Logging.LogFileManagement
{
    /// <summary>
    /// Log file Data Access Layer.
    /// </summary>
    public class LogFileGate
    {

        #region SINGLETON VARS

        private static LogFileGate _instance;
        public static LogFileGate Instance => _instance ??= new LogFileGate();

        #endregion SINGLETON VARS

        #region PRIVATE FIELDS

        private FileInfo _logFileInfo;
        private Queue<string> _logQueue;
        private bool _isWriting = false;

        #endregion PRIVATE FIELDS

        #region PRIVATE PROPS

        private FileInfo logFileInfo => _logFileInfo ??= new FileInfo(ConstantsAbstraction.Instance.LOG_FILE_FULL_PATH);
        private Queue<string> logQueue => _logQueue ??= new Queue<string>();

        #endregion PRIVATE PROPS

        #region CTORS

        private LogFileGate()
        { }

        #endregion CTORS

        #region PUBLIC METHODS

        /// <summary>
        /// Asynchronously enqueues a log message to write it into the Log file.
        /// </summary>
        public async void Write(string log)
        {
            lock (logQueue)
            {
                logQueue.Enqueue(log);
                OnEnqueued();
            }
        }

        /// <summary>
        /// Asynchronously enqueues a log message to write it into the Log file adding a <c>NewLine</c> character at the end.
        /// </summary>
        public async void WriteLine(string log)
        {
            Write(log + Environment.NewLine);
        }

        #endregion PUBLIC METHODS

        #region PRIVATE METHODS

        /// <summary>
        /// Log message enqueued event invoker.
        /// </summary>
        private void OnEnqueued()
        {
            if(!_isWriting)
            {
                WriteLogIntoLogFile();
            }
        }

        /// <summary>
        /// Checks if the <c>logQueue</c> is empty by checking its <c>Count</c> property.
        /// </summary>
        private bool IsLogQueueEmpty()
        {
            return logQueue.Count == 0;
        }

        /// <summary>
        /// Asynchronously writes the log messages from the <c>logQueue</c> into the Log file.
        /// </summary>
        private async void WriteLogIntoLogFile()
        {
            using (var writer = new StreamWriter(_logFileInfo.FullName, true))
            {
                while (!IsLogQueueEmpty())
                {
                    StartedWriting();
                    string log = logQueue.Dequeue();
                    await writer.WriteAsync(log);
                }
            }
            StoppedWriting();
        }

        /// <summary>
        /// Sets all the conditions that needs to change after the <c>LogFileGate</c> started writing into the Log file.
        /// </summary>
        private void StartedWriting()
        {
            _isWriting = true;
        }

        /// <summary>
        /// Sets all the conditions that needs to change after the <c>LogFileGate</c> stopped writing into the Log file.
        /// </summary>
        private void StoppedWriting()
        {
            _isWriting = false;
        }

        #endregion PRIVATE METHODS

    }
}
