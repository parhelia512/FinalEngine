namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    public sealed class Logger : ILogger
    {
        private static ILogger instance;

        public Logger()
        {
            Handlers = new List<ILogHandler>();
        }

        public static ILogger Instance
        {
            get
            {
                return instance ?? (instance = new Logger());
            }
        }

        public ICollection<ILogHandler> Handlers { get; }

        public void Log(LogType type, string message)
        {
            foreach (ILogHandler handler in Handlers)
            {
                handler.Log(type, message);
            }
        }
    }
}