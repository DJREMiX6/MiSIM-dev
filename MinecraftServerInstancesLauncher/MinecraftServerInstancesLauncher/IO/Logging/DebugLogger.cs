﻿using MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using System.Diagnostics;

namespace MinecraftServerInstancesLauncher.IO.Logging
{
    internal class DebugLogger : IMinecraftServerLogger
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
