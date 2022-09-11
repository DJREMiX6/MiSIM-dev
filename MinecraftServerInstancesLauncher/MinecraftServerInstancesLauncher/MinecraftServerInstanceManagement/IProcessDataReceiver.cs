namespace MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement
{
    /// <summary>
    /// Interface for <c>Process</c> output events.
    /// </summary>
    public interface IProcessDataReceiver
    {
        /// <summary>
        /// Handler for <c>Process</c> output data event.
        /// </summary>
        void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e);
        /// <summary>
        /// Handler for <c>Process</c> error data event.
        /// </summary>
        void Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e);
    }
}
