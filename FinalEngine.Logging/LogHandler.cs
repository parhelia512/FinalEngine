namespace FinalEngine.Logging
{
    using System;

    public abstract class LogHandler : ILogHandler
    {
        protected LogHandler(ILogFormatter formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter), $"The specified { nameof(formatter) } parameter is null.");
        }

        protected ILogFormatter Formatter { get; }

        public abstract void Log(LogType type, string message);
    }
}