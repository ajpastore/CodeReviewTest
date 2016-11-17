using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogger.Devices;

namespace SimpleLogger
{
    public class JobLogger2 : IJobLogger
    {

        private AllowedMessageType _allowedMessageType;
        private IDeviceManager _deviceManager;

        public JobLogger2(IDeviceManager deviceManager,
            AllowedMessageType allowedMessageType)
        {
            _deviceManager = deviceManager;
            _allowedMessageType = allowedMessageType;
        }

        public void LogMessage(string message)
        {
            this.Log(message, MessageType.Message);
        }

        public void LogError(string message)
        {
            this.Log(message, MessageType.Error);
        }

        public void LogWarning(string message)
        {
            this.Log(message, MessageType.Warning);
        }

        public void Log(string message, MessageType type)
        {
            _deviceManager.ValidateLogDevices();
            ValidateAllowedMessageTypes();
            
            if (!IsMessageValid(message) || !IsMessageTypeAllowedToLog(type))
            {
                return;
            }

            _deviceManager.LogToDevices(message, type);

        }

        private bool IsMessageTypeAllowedToLog(MessageType type)
        {
            var isValid = false;
            switch (_allowedMessageType)
            {
                case AllowedMessageType.All:
                    isValid = true;
                    break;
                case AllowedMessageType.Error:
                    isValid = type == MessageType.Error ? true : false;
                    break;
                case AllowedMessageType.Message:
                    isValid = type == MessageType.Message ? true : false;
                    break;
                case AllowedMessageType.Warning:
                    isValid = type == MessageType.Warning ? true : false;
                    break;
                case AllowedMessageType.MessageAndError:
                    isValid = (type == MessageType.Message || type == MessageType.Error) ? true : false;
                    break;
                case AllowedMessageType.MessageAndWarning:
                    isValid = (type == MessageType.Message || type == MessageType.Warning) ? true : false;
                    break;
                case AllowedMessageType.ErrorAndWarning:
                    isValid = (type == MessageType.Error || type == MessageType.Warning) ? true : false;
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }

        private void ValidateAllowedMessageTypes()
        {
            if (_allowedMessageType == AllowedMessageType.None)
            {
                throw new Exception("Invalid configuration, no message allowed to log.");
            }
        }

        private bool IsMessageValid(string message)
        {
            message.Trim();
            if (message == null || message.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}
