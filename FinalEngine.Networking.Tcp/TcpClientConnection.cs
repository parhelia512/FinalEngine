// <copyright file="TcpClientConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpClientConnection : IClientConnection
    {
        private readonly ITcpClientInvoker client;

        public TcpClientConnection(ITcpClientInvoker client, Guid guid)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.Guid = guid;
        }

        public event EventHandler<ClientConnectionEventArgs> Disconnected;

        public Guid Guid { get; }

        public string IPAddress
        {
            get { return this.client.Socket.GetAddress(AreaCode.Remote); }
        }

        public int Port
        {
            get { return this.client.Socket.GetPort(AreaCode.Remote); }
        }

        public void Disconnect()
        {
            this.Disconnected?.Invoke(this, new ClientConnectionEventArgs(this));
            this.client.Close();
        }
    }
}