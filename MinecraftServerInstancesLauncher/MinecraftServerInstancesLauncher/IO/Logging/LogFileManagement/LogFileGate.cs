using static System.Net.Mime.MediaTypeNames;

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

        public async void Write(string log)
        {
            lock (logQueue)
            {
                logQueue.Enqueue(log);
                OnEnqueued();
            }
        }

        public async void WriteLine(string log)
        {
            Write(log + Environment.NewLine);
        }

        #endregion PUBLIC METHODS

        #region PRIVATE METHODS

        private void OnEnqueued()
        {
            if(!_isWriting)
            {
                WriteLogIntoLogFile();
            }
        }

        private bool IsLogQueueEmpty()
        {
            return logQueue.Count == 0;
        }

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

        private void StartedWriting()
        {
            _isWriting = true;
        }

        private void StoppedWriting()
        {
            _isWriting = false;
        }

        #endregion PRIVATE METHODS

    }
}
