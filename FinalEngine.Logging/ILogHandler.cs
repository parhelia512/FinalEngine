// <copyright file="ILogHandler.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Logging
{
    /// <summary>
    ///   Defines an interface that represents a handler that writes sequential information to a singular destination.
    /// </summary>
    /// <remarks>
    ///   If you want to implement your own handler, you should instead use the <see cref="LogHandler"/> class as it forces a user to provide an <see cref="ILogFormatter"/> as a parameter to the constructor; giving you, the developer the reassurance of decoupling formatting a message and logging it.
    /// </remarks>
    public interface ILogHandler
    {
        /// <summary>
        ///   Logs the specified <paramref name="message"/> of the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">
        ///   Specifies a <see cref="LogType"/> that represents the type of message to be logged.
        /// </param>
        /// <param name="message">
        ///   Specifies a <see cref="String"/> that represents the message to be logged.
        /// </param>
        void Log(LogType type, string message);
    }
}