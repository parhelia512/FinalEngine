// <copyright file="TcpClientInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>
namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Sockets;

    public interface ITcpClientInvoker
    {
        ISocketInvoker Client { get; }
    }

    [ExcludeFromCodeCoverage]
    public class TcpClientInvoker : ITcpClientInvoker
    {
        private readonly TcpClient client;

        public TcpClientInvoker(TcpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ISocketInvoker Client
        {
            get { return new SocketInvoker(this.client.Client); }
        }
    }
}