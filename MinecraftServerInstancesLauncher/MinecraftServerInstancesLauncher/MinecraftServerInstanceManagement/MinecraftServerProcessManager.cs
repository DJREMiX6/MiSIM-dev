using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    public class MinecraftServerProcessManager
    {
        private MinecraftServerProcess serverProcess;
        private ServerInstanceLauncherConfigurationLoader configurationLoader;

        public MinecraftServerProcessManager()
        {
            InitializeManager();
        }

        private void InitializeManager()
        {
            configurationLoader = ServerInstanceLauncherConfigurationLoader.Instance;
            if (!configurationLoader.IsConfigLoaded)
            {
                configurationLoader.LoadConfig();
            }
            serverProcess = new MinecraftServerProcess(configurationLoader.ServerInstanceLauncherConfiguration);
        }

        public void SubscribeToProcessEvents(IProcessDataReceiver listener)
        {
            serverProcess.OutputDataReceived += listener.Process_OutputDataReceived;
            serverProcess.ErrorDataReceived += listener.Process_ErrorDataReceived;
        }

        public void UnsubscribeToProcessEvents(IProcessDataReceiver listener)
        {
            serverProcess.OutputDataReceived -= listener.Process_OutputDataReceived;
            serverProcess.ErrorDataReceived -= listener.Process_ErrorDataReceived;
        }

        public void StartServerInstance()
        {
            serverProcess.Start();
        }
        
    }
}
