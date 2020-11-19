// <copyright file="TcpConnectionHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpConnectionHandler : IConnectionHandler
    {
        private readonly ITcpListenerInvoker listener;

        public TcpConnectionHandler(ITcpListenerInvoker listener)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
        }

        public void Handle(IServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            while (server.IsRunning)
            {
            }
        }
    }
}