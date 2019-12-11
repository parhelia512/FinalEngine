namespace FinalEngine.Logging
{
    /// <summary>
    ///   Defines an interface that represents a log handler.
    /// </summary>
    public interface ILogHandler
    {
        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies the log type.
        /// </param>
        /// <param name="message">
        ///   Specifies the message.
        /// </param>
        void Log(LogType type, string message);
    }
}