// <copyright file="Logger.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    /// <summary>
    ///   Provides a standard, central logger.
    /// </summary>
    /// <remarks>
    ///   An <see cref="ILogger"/> provides a place for users to add, remove and access <see cref="ILogHandler"/>'s. An <see cref="ILogger"/> also implements the <see cref="ILogHandler"/> interface to allow users to create separate loggers and join them together.
    /// </remarks>
    /// <seealso cref="ILogger"/>
    public sealed class Logger : ILogger
    {
        /// <summary>
        ///   The instance.
        /// </summary>
        private static ILogger instance;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        public Logger()
        {
            this.Handlers = new List<ILogHandler>();
        }

        /// <summary>
        ///   Gets a <see cref="ILogger"/> that represents the global instance of this <see cref="Logger"/>.
        /// </summary>
        /// <value>
        ///   The global instance of this <see cref="Logger"/>.
        /// </value>
        public static ILogger Instance
        {
            get
            {
                return instance ?? (instance = new Logger());
            }
        }

        /// <summary>
        ///   Gets a <see cref="ICollection{ILogHandler}"/> that represents the handlers of this <see cref="Logger"/>.
        /// </summary>
        /// <value>
        ///   The handlers of this <see cref="Logger"/>.
        /// </value>
        public ICollection<ILogHandler> Handlers { get; }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/> to the entire collection of <see cref="Handlers"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies a <see cref="LogType"/> that represents the type of message to be logged.
        /// </param>
        /// <param name="message">
        ///   Specifies a <see cref="String"/> that represents the message to be logged.
        /// </param>
        public void Log(LogType type, string message)
        {
            foreach (ILogHandler handler in this.Handlers)
            {
                handler.Log(type, message);
            }
        }
    }
}