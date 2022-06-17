using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    public class MinecraftServerInterpretedOutputData
    {
        public MinecraftServerInterpretedOutputData(string data, MinecraftServerOutputType type) {
            Data = data;
            Type = type;
        }
        
        public string Data { get; set; }
        
        public MinecraftServerOutputType Type { get; set; }
    }
}
