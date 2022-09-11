using System.Text.Json;

namespace MinecraftServerInstancesLauncher.IO.Config
{
    //TODO EXTRACT THE CONFIG FILE OPENING/WRITING/READING IN ANOTHER CLASS

    /// <summary>
    /// Reads, writes and holds <c>ServerInstanceLauncherConfiguration</c> from a Config file.
    /// </summary>
    public class ServerInstanceLauncherConfigurationLoader
    {

        #region BACKING FIELDS

        private ServerInstanceLauncherConfiguration serverInstanceLauncherConfiguration;

        #endregion BACKING FIELDS

        #region PRIVATE VARS

        private FileStream configFileStream;
        private static ServerInstanceLauncherConfigurationLoader instance;
        private bool isConfigLoaded;

        #endregion PRIVATE VARS

        #region PUBLIC PROPERTIES

        public static ServerInstanceLauncherConfigurationLoader Instance => instance ?? (instance = new ServerInstanceLauncherConfigurationLoader());

        public ServerInstanceLauncherConfiguration ServerInstanceLauncherConfiguration
        {
            get => serverInstanceLauncherConfiguration;
            private set => serverInstanceLauncherConfiguration = value;
        }

        #endregion PUBLIC PROPERTIES

        #region CTORS

        private ServerInstanceLauncherConfigurationLoader()
        {
            LoadConfig();
        }

        #endregion CTORS

        #region PUBLIC METHODS

        /// <summary>
        /// Reads configuration from Config file, if it doesn't exists then creates one with default values.
        /// </summary>
        public void LoadConfig()
        {
            if (!File.Exists(ConstantsAbstraction.Instance.CONFIG_FILE_FULL_PATH))
            {
                CreateDefaultConfigFile();
            }
            OpenConfigFileAndLoadConfig();
        }

        #endregion PUBLIC METHODS

        #region PRIVATE METHODS

        /// <summary>
        /// Opens the Config file, reads it and loads the configurations.
        /// </summary>
        private void OpenConfigFileAndLoadConfig()
        {
            OpenConfigFileStream();
            ServerInstanceLauncherConfiguration config = JsonSerializer.Deserialize<ServerInstanceLauncherConfiguration>(configFileStream);
            this.ServerInstanceLauncherConfiguration = config;
            CloseConfigFileStream();
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
            configFileStream = File.Create(ConstantsAbstraction.Instance.CONFIG_FILE_FULL_PATH);
            CloseConfigFileStream();
        }

        /// <summary>
        /// Writes default values into the Config file.
        /// </summary>
        private void WriteDefaultValuesInConfigFile()
        {
            OpenConfigFileStream();
            string configDefaultJsonString = JsonSerializer.Serialize(ConstantsAbstraction.Instance.DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION);
            foreach (char c in configDefaultJsonString)
            {
                byte characterInByte = (byte)c;
                configFileStream.WriteByte(characterInByte);
            }
            CloseConfigFileStream();
        }

        /// <summary>
        /// Opens the Config file stream.
        /// </summary>
        private void OpenConfigFileStream()
        {
            configFileStream = File.Open(ConstantsAbstraction.Instance.CONFIG_FILE_FULL_PATH, FileMode.Open);
        }

        /// <summary>
        /// Closes the Config file stream.
        /// </summary>
        private void CloseConfigFileStream()
        {
            configFileStream?.Dispose();
            configFileStream?.Close();
        }

        #endregion PRIVATE METHODS

    }
}
