// <copyright file="LogHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    using System;

    /// <summary>
    ///   Provides an abstraction representation of an <see cref="ILogHandler"/> that provides the ability to assure correct formatting of messages.
    /// </summary>
    /// <seealso cref="ILogHandler"/>
    public abstract class LogHandler : ILogHandler
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LogHandler"/> class.
        /// </summary>
        /// <param name="formatter">
        ///   Specifies a <see cref="ILogFormatter"/> that represents the formatter that will format a message before it is logged.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="formatter"/> parameter is null.
        /// </exception>
        protected LogHandler(ILogFormatter formatter)
        {
            this.Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter), $"The specified {nameof(formatter)} parameter is null.");
        }

        /// <summary>
        ///   Gets a <see cref="ILogFormatter"/> that represents the formatter of this <see cref="LogHandler"/>.
        /// </summary>
        /// <value>
        ///   The formatter of this <see cref="LogHandler"/>.
        /// </value>
        protected ILogFormatter Formatter { get; }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies a <see cref="LogType"/> that represents the type of message to be logged.
        /// </param>
        /// <param name="message">
        ///   Specifies a <see cref="string"/> that represents the message to be logged.
        /// </param>
        /// <remarks>
        ///   When implementing this method in a derived class, you should always remember to call the <see cref="ILogFormatter.GetFormattedLog(LogType, string)"/> method of the <see cref="Formatter"/> property to allow the message to be formatted before it is logged.
        /// </remarks>
        public abstract void Log(LogType type, string message);
    }
}