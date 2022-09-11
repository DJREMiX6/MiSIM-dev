using System.Diagnostics;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    /// <summary>
    /// Interpreter class for Minecraft server output.
    /// </summary>
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

        /// <summary>
        /// <c>MinecraftServerOutputDataInterpreted</c> event invoker.
        /// </summary>
        private void OnDataReceived(string data, MinecraftServerOutputType type)
        {
            MinecraftServerOutputDataInterpreted?.Invoke(this, new MinecraftServerInterpretedOutputData(data, type));
        }

        /// <summary>
        /// Gets the <c>MinecraftServerOutputType</c> of a Minecraft server output based on ints content.
        /// </summary>
        private MinecraftServerOutputType GetOutputType(string data)
        {
            if (data.ToUpper().Contains(ConstantsAbstraction.Instance.MINECRAFT_SERVER_OUTPUT_ERROR))
            {
                return MinecraftServerOutputType.ERROR;
            }
            if (data.ToUpper().Contains(ConstantsAbstraction.Instance.MINECRAFT_SERVER_OUTPUT_WARNING))
            {
                return MinecraftServerOutputType.WARNING;
            }
            if (data.ToUpper().Contains(ConstantsAbstraction.Instance.MINECRAFT_SERVER_OUTPUT_INFO))
            {
                return MinecraftServerOutputType.INFO;
            }

            return MinecraftServerOutputType.DEFAULT;
        }
    }
}
