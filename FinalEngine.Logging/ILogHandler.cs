// <copyright file="ILogHandler.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    public interface ILogHandler
    {
        void Log(LogType type, string message);
    }
}