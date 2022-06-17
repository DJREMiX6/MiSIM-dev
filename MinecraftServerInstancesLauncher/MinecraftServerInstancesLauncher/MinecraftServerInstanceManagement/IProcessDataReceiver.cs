using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    public interface IProcessDataReceiver
    {
        void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e);
        void Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e);
    }
}
