// <copyright file="ITcpClientConnectionFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using FinalEngine.Networking.Tcp.Invoking;

    public interface ITcpClientConnectionFactory
    {
        TcpClientConnection CreateClientConnection(ITcpClientInvoker client);
    }
}