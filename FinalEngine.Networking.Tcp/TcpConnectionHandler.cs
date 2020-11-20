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

        public void Handle()
        {
            ITcpClientInvoker client = this.listener.AcceptTcpClient();
            TcpClientConnection connection = this.factory.CreateClientConnection(client);

            //// TODO: Hook onto disconnection and packet received events.
            //// TODO: Raise client connected event here, will be helpful for ECS?
        }
    }
}