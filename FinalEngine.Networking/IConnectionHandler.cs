// <copyright file="IConnectionHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;
    using System.Threading.Tasks;

    public interface IConnectionHandler
    {
        event EventHandler<ClientConnectionEventArgs> ClientConnected;

        event EventHandler<ClientConnectionEventArgs> ClientDisconnected;

        event EventHandler<PacketReceivedEventArgs> PacketReceived;

        Task Handle(IServer server);
    }
}