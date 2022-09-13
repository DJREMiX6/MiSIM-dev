using MinecraftServerInstancesLauncher.IO.DataAccessLayer;
using System.Text.Json;

namespace MinecraftServerInstancesLauncher.IO.Config
{
    /// <summary>
    /// Reads, writes and holds <c>ServerInstanceLauncherConfiguration</c> from a Config file.
    /// </summary>
    public class ServerInstanceLauncherConfigurationLoader
    {

        #region BACKING FIELDS

        private ServerInstanceLauncherConfiguration _serverInstanceLauncherConfiguration;
        private IFileGate _configFileGate;
        private static ServerInstanceLauncherConfigurationLoader _instance;

        #endregion BACKING FIELDS

        #region PRIVATE VARS

        private bool _isConfigLoaded;

        #endregion PRIVATE VARS

        #region PRIVATE PROPS

        private IFileGate configFileGate => _configFileGate ??= new ServerInstanceLauncherConfigurationFileGate();

        #endregion PRIVATE PROPS

        #region PUBLIC PROPERTIES

        public static ServerInstanceLauncherConfigurationLoader Instance => _instance ?? (_instance = new ServerInstanceLauncherConfigurationLoader());

        public ServerInstanceLauncherConfiguration ServerInstanceLauncherConfiguration
        {
            get => _serverInstanceLauncherConfiguration;
            private set => _serverInstanceLauncherConfiguration = value;
        }

        #endregion PUBLIC PROPERTIES

        #region CTORS

        private ServerInstanceLauncherConfigurationLoader()
        { }

        #endregion CTORS

        #region PUBLIC METHODS

        /// <summary>
        /// Reads configuration from Config file, if it doesn't exists then creates one with default values.
        /// </summary>
        public void LoadConfig()
        {
            if (!_isConfigLoaded)
            {
                if (!File.Exists(ConstantsAbstraction.Instance.CONFIG_FILE_FULL_PATH))
                {
                    CreateDefaultConfigFile();
                }
                OpenConfigFileAndLoadConfig();
            }
        }

        public void OverrideConfig(ServerInstanceLauncherConfiguration newConfig)
        {
            configFileGate.ClearFile();
            string configDefaultJsonString = JsonSerializer.Serialize(ServerInstanceLauncherConfiguration.GetConfigCompared(ServerInstanceLauncherConfiguration, newConfig));
            configFileGate.Write(configDefaultJsonString);
            _isConfigLoaded = false;
            LoadConfig();
        }

        #endregion PUBLIC METHODS

        #region PRIVATE METHODS

        /// <summary>
        /// Opens the Config file, reads it and loads the configurations.
        /// </summary>
        private void OpenConfigFileAndLoadConfig()
        {
            this.ServerInstanceLauncherConfiguration = JsonSerializer.Deserialize<ServerInstanceLauncherConfiguration>(configFileGate.ReadToEnd());
            _isConfigLoaded = true;
        }

        /// <summary>
        /// Creates a Config file with default values.
        /// </summary>
        private void CreateDefaultConfigFile()
        {
            CreateConfigFile();
            WriteDefaultValuesInConfigFile();
        }

        /// <summary>
        /// Creates a new Config file.
        /// </summary>
        private void CreateConfigFile()
        {
            configFileGate.CreateFile();
        }

        /// <summary>
        /// Writes default values into the Config file.
        /// </summary>
        private void WriteDefaultValuesInConfigFile()
        {
            string configDefaultJsonString = JsonSerializer.Serialize(ConstantsAbstraction.Instance.DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION);
            configFileGate.Write(configDefaultJsonString);
        }

        #endregion PRIVATE METHODS

    }
}
