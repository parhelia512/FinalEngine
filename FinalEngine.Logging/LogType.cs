// <copyright file="LogType.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    /// <summary>
    ///   Enumerates the available types of messages that can be logged.
    /// </summary>
    public enum LogType
    {
        /// <summary>
        ///   Specifies the log message is meant to be treated as an error.
        /// </summary>
        Error,

        /// <summary>
        ///   Specifies the log message is meant to be treated as a warning.
        /// </summary>
        Warning,

        /// <summary>
        ///   Specifies the log message is meant to be treated as informative.
        /// </summary>
        Information,

        /// <summary>
        ///   Specifies the log message is meant to be treated as debug information.
        /// </summary>
        Debug,
    }
}