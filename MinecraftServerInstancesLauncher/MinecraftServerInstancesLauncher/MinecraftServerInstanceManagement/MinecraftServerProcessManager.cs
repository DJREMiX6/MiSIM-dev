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
            serverProcess = new MinecraftServerProcess(configurationLoader.ServerInstanceLauncherConfiguration);
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
