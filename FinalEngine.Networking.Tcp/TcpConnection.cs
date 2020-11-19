// <copyright file="TcpConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

//// TODO: Unit Test

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpConnection : IConnection
    {
        private readonly ITcpClientInvoker client;

        public TcpConnection(ITcpClientInvoker client, Guid guid)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.Guid = guid;
        }

        public string Address
        {
            get { return this.client.Socket.GetAddress(AreaCode.Remote); }
        }

        public Guid Guid { get; }

        public int Port
        {
            get { return this.client.Socket.GetPort(AreaCode.Remote); }
        }

        public void Disconnect()
        {
            this.client.Close();
        }
    }
}