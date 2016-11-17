namespace SimpleLogger.Devices
{
    public interface IDeviceManager
    {
        void LogToDevices(string message, MessageType type);
        void ValidateLogDevices();
        void LoadDevice(IDevice device);
    }
}