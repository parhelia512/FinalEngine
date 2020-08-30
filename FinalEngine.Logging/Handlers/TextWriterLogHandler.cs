// <copyright file="TextWriterLogHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Handlers
{
    using System;
    using System.IO;

    /// <summary>
    ///   Provides an implementation of a <see cref="LogHandler"/> that logs to a <see cref="TextWriter"/>.
    /// </summary>
    /// <seealso cref="LogHandler"/>
    public sealed class TextWriterLogHandler : LogHandler
    {
        /// <summary>
        ///   The text writer.
        /// </summary>
        private readonly TextWriter writer;

        /// <summary>
        ///   Initializes a new instance of the <see cref="TextWriterLogHandler"/> class.
        /// </summary>
        /// <param name="formatter">
        ///   Specifies a <see cref="ILogFormatter"/> that represents the formatter that will format a message before it is logged.
        /// </param>
        /// <param name="writer">
        ///   Specifies a <see cref="TextWriter"/> that represents the text writer that will be used to log messages.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="writer"/> parameter is null.
        /// </exception>
        public TextWriterLogHandler(ILogFormatter formatter, TextWriter writer)
            : base(formatter)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer), $"The specified {nameof(writer)} parameter is null.");
        }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies a <see cref="LogType"/> that represents the type of message to be logged.
        /// </param>
        /// <param name="message">
        ///   Specifies a <see cref="string"/> that represents the message to be logged.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="message"/> parameter is null or empty.
        /// </exception>
        public override void Log(LogType type, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message), $"The specified {nameof(message)} parameter is null.");
            }

            this.writer.WriteLine(this.Formatter.GetFormattedLog(type, message));
        }
    }
}