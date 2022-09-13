using MinecraftServerInstancesLauncher.IO.DataAccessLayer;

namespace MinecraftServerInstancesLauncher.IO.Logging.LogFileManagement
{
    /// <summary>
    /// Log file Data Access Layer.
    /// </summary>
    public class LogFileGate : FileGate
    {

        #region CTORS

        public LogFileGate() : base(ConstantsAbstraction.Instance.LOG_FILE_FULL_PATH)
        {}

        #endregion CTORS

    }
}
