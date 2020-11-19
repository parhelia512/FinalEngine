// <copyright file="ITcpConnectionFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Networking.Tcp.Invoking;

    public interface ITcpConnectionFactory
    {
        TcpConnection CreateTcpConnection(ITcpClientInvoker client, Guid guid);
    }
}