// <copyright file="ITcpClientConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;

    public interface ITcpClientConnection : IClientConnection
    {
        event EventHandler<ClientConnectionEventArgs> Disconnected;

        event EventHandler<PacketReceivedEventArgs> PacketReceived;
    }
}