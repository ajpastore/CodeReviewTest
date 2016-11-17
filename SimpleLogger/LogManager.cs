using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using SimpleLogger.Devices;

namespace SimpleLogger
{
    public static class LogManager
    {
        private static IJobLogger _instance;

        public static IJobLogger GetLogger()
        {
            if (_instance == null)
            {
                _instance = CreateNewLogger();
            }

            return _instance;
        }

        private static IJobLogger CreateNewLogger()
        {
            try
            {
                return new JobLogger2(CreateNewDeviceManager(), GetAllowedMessageConfig());
            }
            catch
            {
                throw new Exception("Invalid settings in the configuration file.");
            }
        }

        private static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        private static IDeviceManager CreateNewDeviceManager()
        {
            bool logToFile = Convert.ToBoolean(GetConfig("LogToFile"));
            bool logToConsole = Convert.ToBoolean(GetConfig("LogToConsole"));
            bool logToDatabase = Convert.ToBoolean(GetConfig("LogToDatabase"));

            var deviceManager = new DeviceManager();

            if (logToFile) deviceManager.LoadDevice(new FileDevice());
            if (logToConsole) deviceManager.LoadDevice(new ConsoleDevice());
            if (logToDatabase) deviceManager.LoadDevice(new DatabaseDevice());
            return deviceManager;
        }

        private static AllowedMessageType GetAllowedMessageConfig()
        {
            int allowed = 0;
            AllowedMessageType messageTypeAllowed = AllowedMessageType.None;
            if (int.TryParse(GetConfig("AllowedMessagesToLog"), out allowed))
            {
                messageTypeAllowed = (AllowedMessageType)allowed;
            }
            return messageTypeAllowed;
        }

    }
}
