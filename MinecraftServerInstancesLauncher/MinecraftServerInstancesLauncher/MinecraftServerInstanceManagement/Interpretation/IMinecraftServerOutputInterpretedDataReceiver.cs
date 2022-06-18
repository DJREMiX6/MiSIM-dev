using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    public interface IMinecraftServerOutputInterpretedDataReceiver
    {
        public void MinecraftServerOutputInterpretedDataReceived(object sender, MinecraftServerInterpretedOutputData data);
    }
}
