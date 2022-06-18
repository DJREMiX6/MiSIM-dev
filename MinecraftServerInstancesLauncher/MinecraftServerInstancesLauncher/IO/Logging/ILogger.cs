using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    public interface ILogger : IProcessDataReceiver, IMinecraftServerOutputInterpretedDataReceiver
    {
        public void LogWaring(string message);
        public void LogError(string message);
        public void LogInfo(string message);
        public void Log(string message);
    }
}
