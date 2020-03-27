// <copyright file="ILogger.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    /// <summary>
    ///   Defines an interface that represents a central logger.
    /// </summary>
    /// <seealso cref="ILogHandler"/>
    public interface ILogger : ILogHandler
    {
        /// <summary>
        ///   Gets a <see cref="ICollection{ILogHandler}"/> that represents the handlers of this <see cref="ILogger"/>.
        /// </summary>
        /// <value>
        ///   The handlers of this <see cref="ILogger"/>.
        /// </value>
        ICollection<ILogHandler> Handlers { get; }
    }
}