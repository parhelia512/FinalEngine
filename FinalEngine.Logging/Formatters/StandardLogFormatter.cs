namespace FinalEngine.Logging.Formatters
{
    public sealed class StandardLogFormatter : ILogFormatter
    {
        public string GetFormattedLog(LogType type, string message)
        {
            return $"[{ type.ToString().ToUpper() }] { message }";
        }
    }
}