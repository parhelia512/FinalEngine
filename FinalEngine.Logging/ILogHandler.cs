namespace FinalEngine.Logging
{
    public interface ILogHandler
    {
        void Log(LogType type, string message);

        void PopIndent();

        void PushIndent();
    }
}