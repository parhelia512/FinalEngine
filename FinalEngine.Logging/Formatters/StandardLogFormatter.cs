// <copyright file="StandardLogFormatter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Formatters
{
    /// <summary>
    ///   Provides an implementation of an <see cref="ILogFormatter"/> that formats log entries to be easily read in a standard text format.
    /// </summary>
    /// <seealso cref="ILogFormatter"/>
    public sealed class StandardLogFormatter : ILogFormatter
    {
        /// <summary>
        ///   Formats the specified <paramref name="type"/> and <paramref name="message"/> parameters into a standardized log format.
        /// </summary>
        /// <param name="type">
        ///   Specifies a <see cref="LogType"/> that represents the type of log to format.
        /// </param>
        /// <param name="message">
        ///   Specifies a <see cref="String"/> that represents the message of a log to be formatted.
        /// </param>
        /// <remarks>
        ///   The <see cref="StandardLogFormatter"/> changes the specified <paramref name="type"/> parameter to all uppercase and leaves the <paramref name="message"/> parameter untouched.
        /// </remarks>
        /// <returns>
        ///   Returns a formatted result of the specified parameters that's formatted like this: [LOG TYPE] Message.
        /// </returns>
        public string GetFormattedLog(LogType type, string message)
        {
            return $"[{type.ToString().ToUpper()}] {message}";
        }
    }
}