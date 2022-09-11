using MinecraftServerInstancesLauncher.Common.Utils.ArgsResolving;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement;
using MinecraftServerInstancesLauncher.MinecraftServerInstanceManagement.Interpretation;
using MinecraftServerInstancesLauncher.IO.Logging;
using MinecraftServerInstancesLauncher.Common.Utils.Const;
using MinecraftServerInstancesLauncher.IO.Logging.LogAbstractions;

namespace MinecraftServerInstancesLauncher.ApplicationBuilder
{
    /// <summary>
    /// Holds the methods to sets up and start the root level of the application with default configurations.
    /// </summary>
    public class DefaultApplicationBuilder : IApplicationBuilder
    {

        #region PRIVATE FIELDS

        private List<IMinecraftServerLogger> _minecraftServerminecraftServerLoggers;

        #endregion PRIVATE FIELDS

        #region PROTECTED FIELDS

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected ArgsResolverBase _argsResolver;
        protected MinecraftServerProcessManager _minecraftServerProcessManager;
        protected MinecraftServerOutputInterpreter _minecraftServerOutputInterpreter;
        protected List<IMinecraftServerLogger> loggers => _minecraftServerminecraftServerLoggers ?? (_minecraftServerminecraftServerLoggers = new List<IMinecraftServerLogger>());
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #endregion PROTECTED FIELDS

        #region IApplicationBuilder IMPLEMENTATION

        public IApplicationBuilder Build(string[] args)
        {
            SetConstantsAbstractionInstance();
            InitArgsResolver(args);
            InitMinecraftServerProcessManager();
            InitminecraftServerLoggers();
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

        #endregion IApplicationBuilder IMPLEMENTATION

        #region PRIVATE METHODS

        /// <summary>
        /// Sets the <c>ConstantsAbstraction</c> instance as <c>DefaultConstants</c>.
        /// </summary>
        private void SetConstantsAbstractionInstance()
        {
            ConstantsAbstraction.Instance = new DefaultConstants();
        }

        /// <summary>
        /// Initializes the <c>ArgsResolver</c> with the default options.
        /// </summary>
        /// <param name="args">The application arguments</param>
        private void InitArgsResolver(string[] args)
        {
            _argsResolver = new ArgsResolver(ConstantsAbstraction.APPLICATION_NAME, args)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_PAUSE_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_CONSOLE_LOG_PARAM_OPTION)
                .AddOptionChain(ConstantsAbstraction.Instance.APPLICATION_FILE_LOG_PARAM_OPTION)
                .Resolve();
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
                loggers.Add(new ConsoleLogger());
            }
            if(_argsResolver.GetResult<bool>(ConstantsAbstraction.Instance.APPLICATION_FILE_LOG_PARAM_OPTION.Name))
            {
                loggers.Add(new FileLogger());
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
        private void SubscribeLoggersToServerOutputInterpretedDataReceivedEvent()
        {
            foreach(IMinecraftServerLogger logger in _minecraftServerminecraftServerLoggers)
            {
                _minecraftServerOutputInterpreter.MinecraftServerOutputDataInterpreted += logger.MinecraftServerOutputInterpretedDataReceived;
            }
        }

        /// <summary>
        /// Starts the Minecraft server process.
        /// </summary>
        private void StartServerInstance()
        {
            _minecraftServerProcessManager.StartServerInstance();
        }

        /// <summary>
        /// Pauses the application before exit if required by the application argument.
        /// </summary>
        private void PauseApplicationIfRequired()
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
