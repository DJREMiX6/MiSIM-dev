using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    internal class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWaring(string message)
        {
            throw new NotImplementedException();
        }

        public void MinecraftServerOutputInterpretedDataReceived(object sender, MinecraftServerInterpretedOutputData data)
        {
            throw new NotImplementedException();
        }

        public void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
