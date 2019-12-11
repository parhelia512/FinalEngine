namespace FinalEngine.Logging
{
    /// <summary>
    ///   Defines an interface that provides a method for formatting log messages.
    /// </summary>
    public interface ILogFormatter
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
        ///   Returns the formatted log message.
        /// </returns>
        string GetFormattedLog(LogType type, string message);
    }
}