namespace FinalEngine.Logging
{
    /// <summary>
    /// Defines an interface that provides a method for formatting log messages.
    /// </summary>
    /// <remarks>
    /// An <see cref="ILogFormatter"/> provides a single method; <see cref="GetFormattedLog(LogType, string)"/> that users can implement to format a message before it is logged by an <see cref="ILogHandler"/>.
    /// </remarks>
    /// <example>
    /// The following example shows how to format a message to be logged like so: "This is a log message of type LogType"
    /// <code title="LogFormattingExample.cs">namespace LogFormattingExampleProject
    /// {
    ///     using System;
    ///     using FinalEngine.Logging;
    ///     using FinalEngine.Logging.Handlers;
    ///
    ///     public sealed class SomeLogFormatter : ILogFormatter
    ///     {
    ///         public string GetFormattedLog(LogType type, string message)
    ///         {
    ///             // Obviously this is just an example and you should incorperate formatting the message to be logged as well.
    ///             return $"This is a log message of type { type }";
    ///         }
    ///     }
    ///
    ///     internal static class Program
    ///     {
    ///         internal static void Main(string[] args)
    ///         {
    ///             // Create the formatter.
    ///             var formatter = new SomeLogFormatter();
    ///
    ///             // Create a log handler that logs to the console.
    ///             var logHandler = new TextWriterLogHandler(formatter, Console.Out);
    ///
    ///             // Usually we would attach it to the an ILogger, however we can just log like this:
    ///             logHandler.Log(LogType.Information, string.Empty);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
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