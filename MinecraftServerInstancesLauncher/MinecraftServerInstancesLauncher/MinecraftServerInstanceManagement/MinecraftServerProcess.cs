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

        private ServerInstanceLauncherConfiguration _config;
        private IMinecraftServerStringBuilder _minecraftServerStringBuilder;

        public MinecraftServerProcess(ServerInstanceLauncherConfiguration config, IMinecraftServerStringBuilder minecraftServerStringBuilder) : base()
        {
            _config = config;
            _minecraftServerStringBuilder = minecraftServerStringBuilder;
            InitializeServerStartInfo();
        }

        /// <summary>
        /// Builds files paths and Minecraft server arguments to start the process and sets up all the <c>StartInfo</c> necessary properties.
        /// </summary>
        private void InitializeServerStartInfo()
        {
            StartInfo.FileName = _minecraftServerStringBuilder.BuildJavaPath(_config);
            StartInfo.Arguments = _minecraftServerStringBuilder.BuildArgs(_config);
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
