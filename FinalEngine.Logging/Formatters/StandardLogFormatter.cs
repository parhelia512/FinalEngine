// <copyright file="StandardLogFormatter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Logging.Formatters
{
    public sealed class StandardLogFormatter : ILogFormatter
    {
        public string GetFormattedLog(LogType type, string message)
        {
            return $"[{type.ToString().ToUpper()}] {message}";
        }
    }
}