// <copyright file="ILogFormatter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    public interface ILogFormatter
    {
        string GetFormattedLog(LogType type, string message);
    }
}