namespace SimpleLogger
{
    public interface IJobLogger
    {
        void LogMessage(string message);
        void LogWarning(string message);
        void LogError(string message);
        void Log(string message, MessageType type);
    }
}