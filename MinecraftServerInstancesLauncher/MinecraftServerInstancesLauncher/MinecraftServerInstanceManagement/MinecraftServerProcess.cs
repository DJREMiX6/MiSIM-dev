using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MinecraftServerInstancesLauncher.Common.Utils;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    public class MinecraftServerProcess : Process
    {

        private ServerInstanceLauncherConfiguration config;

        public MinecraftServerProcess(ServerInstanceLauncherConfiguration config) : base()
        {
            this.config = config;
            InitializeServerStartInfo();
        }

        private void InitializeServerStartInfo()
        {
            StartInfo.FileName = MinecraftServerStringBuilder.BuildJavaPath(config);
            StartInfo.Arguments = MinecraftServerStringBuilder.BuildArgs(config);
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
        }
        
        public new void Start()
        {
            base.Start();
            base.BeginErrorReadLine();
            base.BeginOutputReadLine();
            base.WaitForExit();
        }
    }
}
