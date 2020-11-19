// <copyright file="TcpConnectionFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpConnectionFactory : ITcpConnectionFactory
    {
        public TcpConnection CreateTcpConnection(ITcpClientInvoker client, Guid guid)
        {
            return new TcpConnection(client, guid);
        }
    }
}