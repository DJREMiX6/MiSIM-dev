using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    public interface ILogger : IProcessDataReceiver
    {
        public void LogWaring(string message);
        public void LogError(string message);
        public void LogInfo(string message);
        public void Log(string message);
    }
}
