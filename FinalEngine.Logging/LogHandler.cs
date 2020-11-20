// <copyright file="LogHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    using System;

    public abstract class LogHandler : ILogHandler
    {
        protected LogHandler(ILogFormatter formatter)
        {
            this.Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter), $"The specified {nameof(formatter)} parameter is null.");
        }

        protected ILogFormatter Formatter { get; }

        public abstract void Log(LogType type, string message);
    }
}