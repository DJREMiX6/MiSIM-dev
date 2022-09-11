namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation
{
    /// <summary>
    /// <c>MinecraftServerOutputInterpretedDataReceived</c> event listener abstraction.
    /// </summary>
    public interface IMinecraftServerOutputInterpretedDataReceiver
    {
        /// <summary>
        /// <c>MinecraftServerOutputInterpretedDataReceived</c> event listener.
        /// </summary>
        public void MinecraftServerOutputInterpretedDataReceived(object sender, MinecraftServerInterpretedOutputData data);
    }
}
