namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    /// <summary>
    ///   Defines an interface that represents a central logger.
    /// </summary>
    /// <remarks>
    ///   An <see cref="ILogger"/> provides a place for users to add, remove and access <see cref="ILogHandler"/> s. An <see cref="ILogger"/> also implements the <see cref="ILogHandler"/> interface to allow users to create separate loggers and join them together.
    /// </remarks>
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