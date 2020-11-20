// <copyright file="ILogger.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    using System.Collections.Generic;

    public interface ILogger : ILogHandler
    {
        ICollection<ILogHandler> Handlers { get; }
    }
}