namespace FinalEngine.Logging
{
    /// <summary>
    ///   Defines an interface that represents a log handler.
    /// </summary>
    /// <remarks>
    ///   <para>An <see cref="ILogHandler"/> provides a way for users to extend the API and allow information to be logged to other destinations (such as a database or the console). An <see cref="ILogHandler"/> provides a single method; <see cref="Log(LogType, string)"/> that user must implement.</para>
    ///   <para>If a user wants to implement the <see cref="ILogHandler"/> interface for the sole purpose of creating a log handler (and not to log to multiple log handlers) he should instead inherit from <see cref="LogHandler"/></para>
    /// </remarks>
    public interface ILogHandler
    {
        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies the type of message to be logged.
        /// </param>
        /// <param name="message">
        ///   Specifies the message to be logged.
        /// </param>
        void Log(LogType type, string message);
    }
}