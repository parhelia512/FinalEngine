// <copyright file="TcpListenerInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Sockets;

    [ExcludeFromCodeCoverage]
    public class TcpListenerInvoker : ITcpListenerInvoker
    {
        private readonly TcpListener listener;

        public TcpListenerInvoker(TcpListener listener)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
        }

        public ITcpClientInvoker AcceptTcpClient()
        {
            return new TcpClientInvoker(this.listener.AcceptTcpClient());
        }

        public void Start()
        {
            this.listener.Start();
        }

        public void Stop()
        {
            this.listener.Stop();
        }
    }
}