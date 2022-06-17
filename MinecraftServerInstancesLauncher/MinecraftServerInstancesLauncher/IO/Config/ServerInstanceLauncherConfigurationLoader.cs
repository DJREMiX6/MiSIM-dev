using System;
using System.Collections.Generic;
using System.Text.Json;
using MinecraftServerInstancesLauncher.Common.Utils;

namespace MinecraftServerInstancesLauncher.IO.Config
{
    //TODO EXTRACT THE CONFIG FILE OPENING/WRITING/READING IN ANOTHER CLASS
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

        public bool IsConfigLoaded
        {
            get => isConfigLoaded;
            private set => isConfigLoaded = value;
        }

        #endregion PUBLIC PROPERTIES

        #region CTORS

        private ServerInstanceLauncherConfigurationLoader()
        {

        }

        #endregion CTORS

        #region PUBLIC METHODS

        public void LoadConfig()
        {
            if (!File.Exists(Constants.CONFIG_FULL_FILE_PATH))
            {
                CreateDefaultConfigFile();
            }
            OpenConfigFileAndLoadConfig();
        }

        #endregion PUBLIC METHODS

        #region PRIVATE METHODS

        private void OpenConfigFileAndLoadConfig()
        {
            OpenConfigFileStream();
            ServerInstanceLauncherConfiguration config = JsonSerializer.Deserialize<ServerInstanceLauncherConfiguration>(configFileStream);
            this.ServerInstanceLauncherConfiguration = config;
            CloseConfigFileStream();
            IsConfigLoaded = true;
        }

        private void CreateDefaultConfigFile()
        {
            CreateConfigFile();
            WriteDefaultValuesInConfigFile();
        }

        private void CreateConfigFile()
        {
            configFileStream = File.Create(Constants.CONFIG_FULL_FILE_PATH);
            CloseConfigFileStream();
        }

        private void WriteDefaultValuesInConfigFile()
        {
            OpenConfigFileStream();
            string configDefaultJsonString = JsonSerializer.Serialize(Constants.DEFAULT_SERVER_INSTANCE_LAUNCHER_CONFIGURATION);
            foreach (char c in configDefaultJsonString)
            {
                byte characterInByte = (byte)c;
                configFileStream.WriteByte(characterInByte);
            }
            CloseConfigFileStream();
        }

        private void OpenConfigFileStream()
        {
            configFileStream = File.Open(Constants.CONFIG_FULL_FILE_PATH, FileMode.Open);
        }

        private void CloseConfigFileStream()
        {
            configFileStream?.Dispose();
            configFileStream?.Close();
        }

        #endregion PRIVATE METHODS

    }
}
