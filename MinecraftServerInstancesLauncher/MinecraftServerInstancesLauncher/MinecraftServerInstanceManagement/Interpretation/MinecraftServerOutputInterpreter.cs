using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.Common.Utils;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    public class MinecraftServerOutputInterpreter : IProcessDataReceiver
    {

        public event MinecraftServerOutputDataInterpreted? MinecraftServerOutputDataInterpreted;
        
        public void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                OnDataReceived(e.Data, MinecraftServerOutputType.ERROR);
            }
        }

        public void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(e.Data != null)
            {
                OnDataReceived(e.Data, GetOutputType(e.Data));
            }
        }

        private void OnDataReceived(string data, MinecraftServerOutputType type)
        {
            MinecraftServerOutputDataInterpreted?.Invoke(this, new MinecraftServerInterpretedOutputData(data, type));
        }

        private MinecraftServerOutputType GetOutputType(string data)
        {
            if (data.ToUpper().Contains(Constants.MINECRAFT_SERVER_OUTPUT_ERROR))
            {
                return MinecraftServerOutputType.ERROR;
            }
            if (data.ToUpper().Contains(Constants.MINECRAFT_SERVER_OUTPUT_WARNING))
            {
                return MinecraftServerOutputType.WARNING;
            }
            if (data.ToUpper().Contains(Constants.MINECRAFT_SERVER_OUTPUT_INFO))
            {
                return MinecraftServerOutputType.INFO;
            }

            return MinecraftServerOutputType.DEFAULT;
        }
    }
}
