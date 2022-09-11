namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    /// <summary>
    /// Data structure to hold Minecraft server intepreted output and its type.
    /// </summary>
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
