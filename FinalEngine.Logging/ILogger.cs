namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    /// <summary>
    ///   Defines an interface that represents a central logger.
    /// </summary>
    /// <seealso cref="FinalEngine.Logging.ILogHandler"/>
    public interface ILogger : ILogHandler
    {
        /// <summary>
        ///   Gets a <see cref="ICollection{ILogHandler}"/> that represents the handlers of this <see cref="ILogger"/>.
        /// </summary>
        /// <value>
        ///   The Handlers of this <see cref="ILogger"/>.
        /// </value>
        ICollection<ILogHandler> Handlers { get; }
    }
}