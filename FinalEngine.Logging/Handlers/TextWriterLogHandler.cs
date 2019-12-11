namespace FinalEngine.Logging.Handlers
{
    using System;
    using System.IO;

    /// <summary>
    ///   Provides a log handlers that can log to a <see cref="TextWriter"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Logging.LogHandler"/>
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
        ///   Specifies the formatter used to format a message before it is logged..
        /// </param>
        /// <param name="writer">
        ///   Specifies the text writer to log too.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="writer"/> parameter is null.
        /// </exception>
        public TextWriterLogHandler(ILogFormatter formatter, TextWriter writer)
            : base(formatter)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer), $"The specified { nameof(writer) } parameter is null.");
        }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies the log type.
        /// </param>
        /// <param name="message">
        ///   Specifies the message.
        /// </param>
        public override void Log(LogType type, string message)
        {
            writer.WriteLine(Formatter.GetFormattedLog(type, message));
        }
    }
}