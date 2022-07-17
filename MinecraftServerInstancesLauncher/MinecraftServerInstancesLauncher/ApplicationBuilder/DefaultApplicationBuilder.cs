using MinecraftServerInstancesLauncher.Common.Utils;
using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using MinecraftServerInstancesLauncher.IO.Logging;

namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    public class DefaultApplicationBuilder : IApplicationBuilder
    {

        private ArgsResolverBase _argsResolver;
        private MinecraftServerProcessManager _minecraftServerProcessManager;
        private MinecraftServerOutputInterpreter _minecraftServerOutputInterpreter;
        private ILogger _logger;

        public IApplicationBuilder Build(string[] args)
        {
            _argsResolver = new ArgsResolver("MiSIL - Minecraft Server Instances Launcher", args)
                .AddOptionChain(Constants.APPLICATION_PAUSE_PARAM_OPTION)
                .Resolve();

            _minecraftServerProcessManager = new();
            _logger = new ConsoleLogger();
            _minecraftServerOutputInterpreter = new();

            _minecraftServerProcessManager.SubscribeToProcessEvents(_minecraftServerOutputInterpreter);
            _minecraftServerOutputInterpreter.MinecraftServerOutputDataInterpreted += _logger.MinecraftServerOutputInterpretedDataReceived;

            return this;
        }

        public IApplicationBuilder Start()
        {
            _minecraftServerProcessManager.StartServerInstance();

            if (_argsResolver.GetResult<bool>(Constants.APPLICATION_PAUSE_PARAM_OPTION.Name)) {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
            return this;
        }
    }
}
