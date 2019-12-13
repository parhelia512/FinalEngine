namespace FinalEngine.Logging.Handlers
{
    using System;
    using System.IO;

    public sealed class TextWriterLogHandler : LogHandler
    {
        private readonly TextWriter writer;

        public TextWriterLogHandler(ILogFormatter formatter, TextWriter writer)
            : base(formatter)
        {
            this.writer = writer ?? throw new ArgumentNullException(nameof(writer), $"The specified { nameof(writer) } parameter is null.");
        }

        public override void Log(LogType type, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message), $"The specified { nameof(message) } parameter is null.");
            }

            writer.WriteLine(Formatter.GetFormattedLog(type, message));
        }
    }
}