// <copyright file="TcpClientConnectionFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpClientConnectionFactory : ITcpClientConnectionFactory
    {
        public ITcpClientConnection CreateClientConnection(ITcpClientInvoker client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return new TcpClientConnection(client, Guid.NewGuid());
        }
    }
}