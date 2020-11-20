// <copyright file="IClientConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    /// <summary>
    ///     Defines an interface that represents the connection of a client to a server.
    /// </summary>
    public interface IClientConnection
    {
        /// <summary>
        ///     Gets the unique identifier of this connection.
        /// </summary>
        /// <value>
        ///     The unique identifier of this connection.
        /// </value>
        Guid Guid { get; }

        /// <summary>
        ///     Gets the IP address of this <see cref="IClientConnection"/>.
        /// </summary>
        /// <value>
        ///     The IP Address of this <see cref="IClientConnection"/>.
        /// </value>
        string IPAddress { get; }

        /// <summary>
        ///     Gets the port address of this <see cref="IClientConnection"/>.
        /// </summary>
        /// <value>
        ///     The port address of this <see cref="IClientConnection"/>.
        /// </value>
        int Port { get; }

        /// <summary>
        ///     Disconnects and closes the underlying connection.
        /// </summary>
        void Disconnect();
    }
}