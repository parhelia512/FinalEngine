// <copyright file="ILogFormatter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    /// <summary>
    ///   Defines an interface that provides a method for formatting the information given from a log entry to a <c>string</c>.
    /// </summary>
    public interface ILogFormatter
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
        /// <returns>
        ///   Returns the formatted result of the specified parameters.
        /// </returns>
        string GetFormattedLog(LogType type, string message);
    }
}