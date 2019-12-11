namespace FinalEngine.Logging.Formatters
{
    /// <summary>
    ///   Provides a standard log formatter ([LogType] Message).
    /// </summary>
    /// <seealso cref="FinalEngine.Logging.ILogFormatter"/>
    public sealed class StandardLogFormatter : ILogFormatter
    {
        /// <summary>
        ///   Gets a formatted log message from the specified <paramref name="type"/> and <paramref name="message"/> parameters.
        /// </summary>
        /// <param name="type">
        ///   Specifies the log type.
        /// </param>
        /// <param name="message">
        ///   Specifies the message.
        /// </param>
        /// <returns>
        ///   Returns the formatted log message, formatted to [ <paramref name="type"/>] <paramref name="message"/> (with the specified <paramref name="type"/> parameter converted to capital casing).
        /// </returns>
        public string GetFormattedLog(LogType type, string message)
        {
            return $"[{ type.ToString().ToUpper() }] { message }";
        }
    }
}