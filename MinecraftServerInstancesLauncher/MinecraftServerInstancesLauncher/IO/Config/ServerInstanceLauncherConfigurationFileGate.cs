using MinecraftServerInstancesLauncher.IO.DataAccessLayer;

namespace MinecraftServerInstancesLauncher.IO.Config
{
    public class ServerInstanceLauncherConfigurationFileGate : FileGate
    {
        public ServerInstanceLauncherConfigurationFileGate() : base(ConstantsAbstraction.Instance.CONFIG_FILE_FULL_PATH)
        {
        }
    }
}
