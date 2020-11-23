// <copyright file="TcpConnectionHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using System.Threading.Tasks;
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

        public event EventHandler<PacketReceivedEventArgs> PacketReceived;

        public async Task Handle(IServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            while (server.IsRunning)
            {
                ITcpClientInvoker client = await this.listener.AcceptTcpClientAsync();
                ITcpClientConnection connection = this.factory.CreateClientConnection(client);

                connection.Disconnected += this.Connection_Disconnected;
                connection.PacketReceived += this.Connection_PacketReceived;

                this.ClientConnected?.Invoke(this, new ClientConnectionEventArgs(connection));
            }
        }

        private void Connection_Disconnected(object sender, ClientConnectionEventArgs e)
        {
            this.ClientDisconnected?.Invoke(this, e);
        }

        private void Connection_PacketReceived(object sender, PacketReceivedEventArgs e)
        {
            this.PacketReceived?.Invoke(this, e);
        }
    }
}
