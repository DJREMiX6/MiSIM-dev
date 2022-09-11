using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;

namespace MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions
{
    /// <summary>
    /// Interface to log Minecraft server data.
    /// </summary>
    public interface IMinecraftServerLogger : ILogger, IProcessDataReceiver, IMinecraftServerOutputInterpretedDataReceiver
    {
    }
}
