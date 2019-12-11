namespace FinalEngine.Logging
{
    public interface ILogFormatter
    {
        string GetFormattedLog(LogType type, int indentSize, string message);
    }
}