using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions;
using MinecraftServerInstancesLauncher.IO.Logging;
using MinecraftServerInstancesLauncher.IO.Config;

namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    /// <summary>
    /// Holds the methods to sets up and start the root level of the application with debug configurations.
    /// </summary>
    public class DebugApplicationBuilder : IApplicationBuilder
    {

        #region PRIVATE FIELDS

        private List<IMinecraftServerLogger> _minecraftServerLoggers;

        #endregion PRIVATE FIELDS

        #region PROTECTED FIELDS

        protected ArgsResolverBase _argsResolver;
        protected MinecraftServerProcessManager _minecraftServerProcessManager;
        protected MinecraftServerOutputInterpreter _minecraftServerOutputInterpreter;
        protected List<IMinecraftServerLogger> minecraftServerLoggers => _minecraftServerLoggers ?? (_minecraftServerLoggers = new List<IMinecraftServerLogger>());

        #endregion PROTECTED FIELDS

        #region IApplicationBuilder IMPLEMENTATION

        public IApplicationBuilder Build(string[] args)
        {
            SetConstantImplementationInstance();
            LoadLauncherConfiguration();
            InitArgsResolver(args);
            SetLauncherConfigurationBasedOnApplicationArguments();
            CreateServerVersionsDirectory();
            CreateJavaInstancesDirectory();
            InitMinecraftServerProcessManager();
            InitminecraftServerLoggers();
            InitMinecraftServerOutputInterpreter();
            SubscribeMinecraftServerOutputInterpreterToProcessEvents();
            SubscribeMinecraftServerLoggersToServerOutputInterpretedDataReceivedEvent();
            return this;
        }

        public IApplicationBuilder Start()
        {
            StartMinecraftServerProcess();
            PauseApplicationBeforeExitIfRequired();
            return this;
        }

        #endregion IApplicationBuilder IMPLEMENTATION

        #region PRIVATE METHODS

        /// <summary>
        /// Sets the <c>ConstantsAbstraction</c> instance as <c>DebugConstants</c>.
        /// </summary>
        private void SetConstantImplementationInstance()
        {
            ConstantsAbstraction.Instance = new DebugConstants();
        }

        /// <summary>
        /// Loads the <c>ServerInstanceLauncherConfiguration</c> from Configuration file.
        /// </summary>
        private void LoadLauncherConfiguration()
        {
            ServerInstanceLauncherConfigurationLoader.Instance.LoadConfig();
        }

        /// <summary>
        /// Initializes the <c>ArgsResolver</c> with the debug options.
        /// </summary>
        /// <param name="args">The application arguments</param>
        private void InitArgsResolver(string[] args)
        {
            _argsResolver = new ArgsResolver(ConstantsAbstraction.APPLICATION_NAME, args)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_PAUSE_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_CONSOLE_LOG_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_FILE_LOG_PARAM_OPTION)

                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_JAVA_VERSION_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_SERVER_VERSION_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_SERVER_TYPE_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_MIN_RAM_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_MAX_RAM_PARAM_OPTION)

                .Resolve();
        }

        /// <summary>
        /// Sets each launcher config passed as arguments to the config file
        /// </summary>
        private void SetLauncherConfigurationBasedOnApplicationArguments()
        {
            ServerInstanceLauncherConfigurationLoader.Instance.OverrideConfig(new ServerInstanceLauncherConfiguration()
            {
                JavaVersion = _argsResolver.GetResult<string?>(ConstantsAbstraction.Instance.APPLICATION_JAVA_VERSION_PARAM_OPTION.Name),
                ServerVersion = _argsResolver.GetResult<string?>(ConstantsAbstraction.Instance.APPLICATION_SERVER_VERSION_PARAM_OPTION.Name),
                ServerType = _argsResolver.GetResult<string?>(ConstantsAbstraction.Instance.APPLICATION_SERVER_TYPE_PARAM_OPTION.Name),
                MinRam = _argsResolver.GetResult<string?>(ConstantsAbstraction.Instance.APPLICATION_MIN_RAM_PARAM_OPTION.Name),
                MaxRam = _argsResolver.GetResult<string?>(ConstantsAbstraction.Instance.APPLICATION_MAX_RAM_PARAM_OPTION.Name),
            });
        }

        /// <summary>
        /// Creates a Minecraft server versions directory if it doesn't exists.
        /// </summary>
        private void CreateServerVersionsDirectory()
        {
            if (!Directory.Exists(ConstantsAbstraction.Instance.SERVERS_VERSIONS_FULL_PATH))
            {
                Directory.CreateDirectory(ConstantsAbstraction.Instance.SERVERS_VERSIONS_FULL_PATH);
            }
        }

        /// <summary>
        /// Creates a Java versions directory if it doesn't exists.
        /// </summary>
        private void CreateJavaInstancesDirectory()
        {
            if (!Directory.Exists(ConstantsAbstraction.Instance.JAVA_INSTANCES_FULL_PATH))
            {
                Directory.CreateDirectory(ConstantsAbstraction.Instance.JAVA_INSTANCES_FULL_PATH);
            }
        }

        /// <summary>
        /// Initializes the <c>MinecraftServerProcessManager</c>.
        /// </summary>
        private void InitMinecraftServerProcessManager()
        {
            _minecraftServerProcessManager = new();
        }

        /// <summary>
        /// Adds all the <c>IMinecraftServerLogger</c> needed.
        /// </summary>
        private void InitminecraftServerLoggers()
        { 
            if (_argsResolver.GetResult<bool>(ConstantsAbstraction.Instance.APPLICATION_CONSOLE_LOG_PARAM_OPTION.Name))
            {
                minecraftServerLoggers.Add(new ConsoleLogger());
            }
            if (_argsResolver.GetResult<bool>(ConstantsAbstraction.Instance.APPLICATION_FILE_LOG_PARAM_OPTION.Name))
            {
                minecraftServerLoggers.Add(new FileLogger());
            }
        }

        /// <summary>
        /// Initializes the <c>MinecraftServerOutputInterpreter</c>.
        /// </summary>
        private void InitMinecraftServerOutputInterpreter()
        {
            _minecraftServerOutputInterpreter = new();
        }

        /// <summary>
        /// Subscribes the <c>MinecraftServerOutputInterpreter</c> to the <c>MinecraftServerProcessManager Process</c> output events. 
        /// </summary>
        private void SubscribeMinecraftServerOutputInterpreterToProcessEvents()
        {
            _minecraftServerProcessManager.SubscribeToProcessEvents(_minecraftServerOutputInterpreter);
        }

        /// <summary>
        /// Subscribes all the <c>IMinecraftServerLogger</c> to the <c>MinecraftServerOutputInterpreter</c>'s <c>MinecraftServerOutputDataInterpreted</c> events.
        /// </summary>
        private void SubscribeMinecraftServerLoggersToServerOutputInterpretedDataReceivedEvent()
        {
            foreach (IMinecraftServerLogger logger in minecraftServerLoggers)
            {
                _minecraftServerOutputInterpreter.MinecraftServerOutputDataInterpreted += logger.MinecraftServerOutputInterpretedDataReceived;
            }
        }

        /// <summary>
        /// Starts the Minecraft server process.
        /// </summary>
        private void StartMinecraftServerProcess()
        {
            _minecraftServerProcessManager.StartServerInstance();
        }

        /// <summary>
        /// Pauses the application before exit if required by the application argument.
        /// </summary>
        private void PauseApplicationBeforeExitIfRequired()
        {
            if (_argsResolver.GetResult<bool>(ConstantsAbstraction.Instance.APPLICATION_PAUSE_PARAM_OPTION.Name))
            {
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

        #endregion PRIVATE METHODS

    }
}
