// <copyright file="TcpConnectionHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpConnectionHandler : IConnectionHandler
    {
        private readonly ITcpClientConnectionFactory factory;

        private readonly ITcpListenerInvoker listener;

        public TcpConnectionHandler(ITcpListenerInvoker listener, ITcpClientConnectionFactory factory)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public event EventHandler<ClientConnectionEventArgs> ClientConnected;

        public event EventHandler<ClientConnectionEventArgs> ClientDisconnected;

        public void Handle()
        {
            ITcpClientInvoker client = this.listener.AcceptTcpClient();
            TcpClientConnection connection = this.factory.CreateClientConnection(client);

            if (connection == null)
            {
                throw new Exception($"The {nameof(this.factory)} could not successfully create a client connection.");
            }

            connection.Disconnected += this.Connection_Disconnected;

            this.ClientConnected?.Invoke(this, new ClientConnectionEventArgs(connection));
        }

        private void Connection_Disconnected(object sender, ClientConnectionEventArgs e)
        {
            this.ClientDisconnected?.Invoke(this, new ClientConnectionEventArgs(e.Connection));
        }
    }
}