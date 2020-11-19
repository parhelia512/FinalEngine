// <copyright file="TcpServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Networking.Tcp.Extensions;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpServer : IServer
    {
        private readonly IConnectionHandler handler;

        private readonly ITcpListenerInvoker listener;

        public TcpServer(ITcpListenerInvoker listener, IConnectionHandler handler)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public bool IsRunning { get; private set; }

        public int Port
        {
            get { return this.listener.Server.GetLocalPort(); }
        }

        public void Start()
        {
            if (this.IsRunning)
            {
                return;
            }

            this.IsRunning = true;
            this.listener.Start();

#if DEBUG
            Logger.Instance.Log(LogType.Debug, $"Server listening on port: {this.Port}");
#endif

            this.handler.Handle(this);
        }

        public void Stop()
        {
            if (!this.IsRunning)
            {
                return;
            }

            this.IsRunning = false;
            this.listener.Stop();
        }
    }
}