namespace FinalEngine.Logging
{
    using System;

    /// <summary>
    ///   Provides an abstract representation of an <see cref="ILogHandler"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Logging.ILogHandler"/>
    public abstract class LogHandler : ILogHandler
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="LogHandler"/> class.
        /// </summary>
        /// <param name="formatter">
        ///   Specifies the formatter used to format a message before it is logged.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="formatter"/> parameter is null.
        /// </exception>
        protected LogHandler(ILogFormatter formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter), $"The specified { nameof(formatter) } parameter is null.");
        }

        /// <summary>
        ///   Gets a <see cref="ILogFormatter"/> that represents the formatter of this <see cref="LogHandler"/>.
        /// </summary>
        /// <value>
        ///   The Formatter of this <see cref="LogHandler"/>.
        /// </value>
        protected ILogFormatter Formatter { get; }

        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies the log type.
        /// </param>
        /// <param name="message">
        ///   Specifies the message.
        /// </param>
        public abstract void Log(LogType type, string message);
    }
}