// <copyright file="TcpConnectionHandler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

//// TODO: Unit Test

namespace FinalEngine.Networking.Tcp
{
    using System;
    using FinalEngine.Core.Threading;
    using FinalEngine.Networking;
    using FinalEngine.Networking.Tcp.Invoking;

    public class TcpConnectionHandler : IConnectionHandler
    {
        private readonly ITcpConnectionFactory factory;

        private readonly ITcpListenerInvoker listener;

        private readonly ITaskScheduler scheduler;

        public TcpConnectionHandler(ITcpListenerInvoker listener)
            : this(listener, new TaskScheduler(), new TcpConnectionFactory())
        {
        }

        public TcpConnectionHandler(ITcpListenerInvoker listener, ITaskScheduler scheduler, ITcpConnectionFactory factory)
        {
            this.listener = listener ?? throw new ArgumentNullException(nameof(listener));
            this.scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public void Handle(IServer server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            this.scheduler.Execute(() =>
            {
                while (server.IsRunning)
                {
                    ITcpClientInvoker client = this.listener.AcceptTcpClient();
                    TcpConnection connection = this.factory.CreateTcpConnection(client, Guid.NewGuid());

                    Console.WriteLine("Client Connected");

                    this.scheduler.Execute(() => this.SetupConnection(connection));
                }
            });
        }

        private void SetupConnection(IConnection connection)
        {
            connection.Disconnect();

            Console.WriteLine("Client Disconnected");
        }
    }
}