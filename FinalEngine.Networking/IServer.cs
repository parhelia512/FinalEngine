// <copyright file="IServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    /// <summary>
    ///     Defines an interface that represents a centralized networking service.
    /// </summary>
    public interface IServer
    {
        /// <summary>
        ///     Gets the IP address of this <see cref="IServer"/>.
        /// </summary>
        /// <value>
        ///     The IP Address of this <see cref="IServer"/>.
        /// </value>
        string IPAddress { get; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="IServer"/> is running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="IServer"/> is running; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        ///     Gets the port address of this <see cref="IServer"/>.
        /// </summary>
        /// <value>
        ///     The port address of this <see cref="IServer"/>.
        /// </value>
        int Port { get; }

        /// <summary>
        ///     Starts this <see cref="IServer"/> and listens for incoming connections on the
        ///     current <see cref="IPAddress"/> and <see cref="Port"/>.
        /// </summary>
        void Start();

        /// <summary>
        ///     Stops this <see cref="IServer"/>.
        /// </summary>
        void Stop();
    }
}