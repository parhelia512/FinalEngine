// <copyright file="IConnectionHandler.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    public interface IConnectionHandler
    {
        event EventHandler<ClientConnectionEventArgs> ClientConnected;

        event EventHandler<ClientConnectionEventArgs> ClientDisconnected;

        void Handle(IServer server);
    }
}