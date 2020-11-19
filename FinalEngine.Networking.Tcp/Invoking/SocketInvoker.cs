// <copyright file="SocketInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Sockets;

    public interface ISocketInvoker
    {
        IEndPointInvoker LocalEndPoint { get; }

        IEndPointInvoker RemoteEndPoint { get; }
    }

    [ExcludeFromCodeCoverage]
    public class SocketInvoker : ISocketInvoker
    {
        private readonly Socket socket;

        public SocketInvoker(Socket socket)
        {
            this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
        }

        public IEndPointInvoker LocalEndPoint
        {
            get { return new EndPointInvoker(this.socket.LocalEndPoint); }
        }

        public IEndPointInvoker RemoteEndPoint
        {
            get { return new EndPointInvoker(this.socket.RemoteEndPoint); }
        }
    }
}