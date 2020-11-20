// <copyright file="TcpServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Core.Threading;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpServer : IServer
    {
        private readonly object @lock = new object();

        private readonly ITaskExecuter executer;

        private readonly IConnectionHandler handler;

        private readonly ITcpListenerInvoker listener;

        private bool isRunning;

        public TcpServer(ITcpListenerInvoker listener, ITaskExecuter executer, IConnectionHandler handler)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
            this.executer = executer ?? throw new ArgumentNullException(nameof(executer));
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public string IPAddress
        {
            get { return this.listener.Server.GetAddress(AreaCode.Local); }
        }

        public bool IsRunning
        {
            get
            {
                lock (this.@lock)
                {
                    return this.isRunning;
                }
            }

            set
            {
                lock (this.@lock)
                {
                    this.isRunning = value;
                }
            }
        }

        public int Port
        {
            get { return this.listener.Server.GetPort(AreaCode.Local); }
        }

        public void Start()
        {
            if (this.IsRunning)
            {
                return;
            }

            this.IsRunning = true;

            this.listener.Start();

            this.executer.Execute(() => this.handler.Handle(this));
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