using MinecraftServerInstancesLauncher.Common.Utils;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    /// <summary>
    /// Manages <c>MinecraftServerProcess</c> and listeners for <c>Process</c> output end error events.
    /// </summary>
    public class MinecraftServerProcessManager
    {
        private MinecraftServerProcess serverProcess;
        private ServerInstanceLauncherConfigurationLoader configurationLoader;

        public MinecraftServerProcessManager()
        {
            InitializeManager();
        }

        /// <summary>
        /// Initializes the <c>MinecraftServerProcessManager</c> and all its components by using configurations.
        /// </summary>
        private void InitializeManager()
        {
            configurationLoader = ServerInstanceLauncherConfigurationLoader.Instance;
            configurationLoader.LoadConfig();
            serverProcess = new MinecraftServerProcess(configurationLoader.ServerInstanceLauncherConfiguration, GetMinecraftServerStringBuilder());
        }

        /// <summary>
        /// Initialize the right instance of <c>IMinecraftServerStringBuilder</c> based on configuration file.
        /// </summary>
        /// <returns>The instance of <c>IMinecraftServerStringBuilder</c>.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private IMinecraftServerStringBuilder GetMinecraftServerStringBuilder()
        {
            string serverType = configurationLoader.ServerInstanceLauncherConfiguration.ServerType;
            if(serverType.Equals(ConstantsAbstraction.MINECRAFT_SERVER_TYPE_VANILLA))
            {
                return new VanillaMinecraftServerStringBuilder();
            }
            throw new InvalidOperationException($"{serverType} is not a valid {nameof(configurationLoader.ServerInstanceLauncherConfiguration.ServerType)}.");
        }

        /// <summary>
        /// Subscribes an <c>IProcessDataReceiver</c> listener to <c>MinecraftServerProcess</c> events.
        /// </summary>
        public void SubscribeToProcessEvents(IProcessDataReceiver listener)
        {
            serverProcess.OutputDataReceived += listener.Process_OutputDataReceived;
            serverProcess.ErrorDataReceived += listener.Process_ErrorDataReceived;
        }

        /// <summary>
        /// Unsubscribes an <c>IProcessDataReceiver</c> listener from <c>MinecraftServerProcess</c> events.
        /// </summary>
        public void UnsubscribeToProcessEvents(IProcessDataReceiver listener)
        {
            serverProcess.OutputDataReceived -= listener.Process_OutputDataReceived;
            serverProcess.ErrorDataReceived -= listener.Process_ErrorDataReceived;
        }

        /// <summary>
        /// Starts <c>MinecraftServerProcess</c> process.
        /// </summary>
        public void StartServerInstance()
        {
            serverProcess.Start();
        }
        
    }
}
