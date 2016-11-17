using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Devices
{
    internal class DeviceManager : IDeviceManager
    {
        List<IDevice> _devices = new List<IDevice>();

        public DeviceManager()
        {
        }

        public void LoadDevice(IDevice device)
        {
            _devices.Add(device);           
        }

        public void LogToDevices(string message, MessageType type)
        {
            foreach(var device in _devices)
            {
                device.Log(message, type);
            }
        }

        public void ValidateLogDevices()
        {
            if (!_devices.Any())
            {
                throw new Exception("Invalid configuration, no devices loaded.");
            }
        }
    }
}
