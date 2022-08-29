using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using MinecraftServerInstancesLauncher.IO.Logging;
using MinecraftServerInstancesLauncher.Common.Utils.Const;

namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    public class DebugApplicationBuilder : IApplicationBuilder
    {

        private List<ILogger> _loggers;
        
        protected ArgsResolverBase _argsResolver;
        protected MinecraftServerProcessManager _minecraftServerProcessManager;
        protected MinecraftServerOutputInterpreter _minecraftServerOutputInterpreter;
        protected List<ILogger> loggers => _loggers ?? (_loggers = new List<ILogger>());
        
        public IApplicationBuilder Build(string[] args)
        {
            SetConstantImplementationInstance();
            InitArgsResolver(args);
            CreateServerVersionsDirectory();
            CreateJavaInstancesDirectory();
            InitMinecraftServerProcessManager();
            InitLoggers();
            InitMinecraftServerOutputInterpreter();
            SubscribeMinecraftServerOutputInterpreterToProcessEvents();
            SubscribeLoggersToServerOutputInterpretedDataReceivedEvent();
            return this;
        }

        public IApplicationBuilder Start()
        {
            StartServerInstance();
            PauseApplicationIfRequired();
            return this;
        }

        private void SetConstantImplementationInstance()
        {
            ConstantsImplementation.Instance = new DebugConstants();
        }

        private void CreateServerVersionsDirectory()
        {
            if (!Directory.Exists(ConstantsImplementation.Instance.SERVERS_VERSIONS_FULL_PATH))
            {
                Directory.CreateDirectory(ConstantsImplementation.Instance.SERVERS_VERSIONS_FULL_PATH);
            }
        }

        private void CreateJavaInstancesDirectory()
        {
            if (!Directory.Exists(ConstantsImplementation.Instance.JAVA_INSTANCES_FULL_PATH))
            {
                Directory.CreateDirectory(ConstantsImplementation.Instance.JAVA_INSTANCES_FULL_PATH);
            }
        }

        private void InitArgsResolver(string[] args)
        {
            _argsResolver = new ArgsResolver(ConstantsImplementation.Instance.APPLICATION_NAME, args)
                .AddOptionChain(ConstantsImplementation.Instance.APPLICATION_PAUSE_PARAM_OPTION)
                .AddOptionChain(ConstantsImplementation.Instance.APPLICATION_CONSOLE_LOG_PARAM_OPTION)
                .AddOptionChain(ConstantsImplementation.Instance.APPLICATION_FILE_LOG_PARAM_OPTION)
                .Resolve();
        }

        private void InitMinecraftServerProcessManager()
        {
            _minecraftServerProcessManager = new();
        }

        private void InitLoggers()
        { 
            if (_argsResolver.GetResult<bool>(ConstantsImplementation.Instance.APPLICATION_CONSOLE_LOG_PARAM_OPTION.Name))
            {
                loggers.Add(new ConsoleLogger());
            }
            if (_argsResolver.GetResult<bool>(ConstantsImplementation.Instance.APPLICATION_FILE_LOG_PARAM_OPTION.Name))
            {
                loggers.Add(new FileLogger());
            }
        }

        private void InitMinecraftServerOutputInterpreter()
        {
            _minecraftServerOutputInterpreter = new();
        }

        private void SubscribeMinecraftServerOutputInterpreterToProcessEvents()
        {
            _minecraftServerProcessManager.SubscribeToProcessEvents(_minecraftServerOutputInterpreter);
        }

        private void SubscribeLoggersToServerOutputInterpretedDataReceivedEvent()
        {
            foreach (ILogger logger in loggers)
            {
                _minecraftServerOutputInterpreter.MinecraftServerOutputDataInterpreted += logger.MinecraftServerOutputInterpretedDataReceived;
            }
        }

        private void StartServerInstance()
        {
            _minecraftServerProcessManager.StartServerInstance();
        }

        private void PauseApplicationIfRequired()
        {
            if (_argsResolver.GetResult<bool>(ConstantsImplementation.Instance.APPLICATION_PAUSE_PARAM_OPTION.Name))
            {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }
    }
}
