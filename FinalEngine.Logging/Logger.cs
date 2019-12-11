namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    /// <summary>
    ///   Provides a central logger.
    /// </summary>
    /// <seealso cref="FinalEngine.Logging.ILogger"/>
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
            Handlers = new List<ILogHandler>();
        }

        /// <summary>
        ///   Gets an instanced <see cref="ILogger"/>.
        /// </summary>
        /// <value>
        ///   The instanced <see cref="ILogger"/>.
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
        ///   The Handlers of this <see cref="ILogger"/>.
        /// </value>
        public ICollection<ILogHandler> Handlers { get; }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies the log type.
        /// </param>
        /// <param name="message">
        ///   Specifies the message.
        /// </param>
        public void Log(LogType type, string message)
        {
            foreach (ILogHandler handler in Handlers)
            {
                handler.Log(type, message);
            }
        }
    }
}