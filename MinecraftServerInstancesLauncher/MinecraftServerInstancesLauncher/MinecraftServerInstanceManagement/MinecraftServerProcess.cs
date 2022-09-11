using System.Diagnostics;
using MinecraftServerInstancesLauncher.Common.Utils;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    /// <summary>
    /// Holds all the methods to initialize and start the Minecraft server process.
    /// </summary>
    public class MinecraftServerProcess : Process
    {

        private ServerInstanceLauncherConfiguration config;

        public MinecraftServerProcess(ServerInstanceLauncherConfiguration config) : base()
        {
            this.config = config;
            InitializeServerStartInfo();
        }

        /// <summary>
        /// Builds files paths and Minecraft server arguments to start the process and sets up all the <c>StartInfo</c> necessary properties.
        /// </summary>
        private void InitializeServerStartInfo()
        {
            StartInfo.FileName = MinecraftServerStringBuilder.BuildJavaPath(config);
            StartInfo.Arguments = MinecraftServerStringBuilder.BuildArgs(config);
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
        }

        /// <summary>
        /// Starts the Minecraft server process as child process and begins to read from its <c>std_out</c> and <c>std_err</c>.
        /// </summary>
        public new void Start()
        {
            base.Start();
            base.BeginErrorReadLine();
            base.BeginOutputReadLine();
            base.WaitForExit();
        }
    }
}
