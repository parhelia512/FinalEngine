// <copyright file="GameServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace Game.Host
{
    using System;
    using System.Threading;
    using FinalEngine.Core;
    using FinalEngine.Logging;
    using FinalEngine.Networking;

    public class GameServer : GameContainer
    {
        private readonly IConnectionHandler handler;

        private readonly IServer server;

        public GameServer(IServer server, IConnectionHandler handler)
        {
            this.server = server ?? throw new ArgumentNullException(nameof(server));
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        protected override void Initialize()
        {
            this.handler.ClientConnected += this.Handler_ClientConnected;
            this.handler.ClientDisconnected += this.Handler_ClientDisconnected;

            this.server.Start();

            Logger.Instance.Log(LogType.Debug, $"Server listening on port: {this.server.IPAddress}:{this.server.Port}");

            base.Initialize();
        }

        private void Handler_ClientConnected(object sender, ClientConnectionEventArgs e)
        {
            Logger.Instance.Log(LogType.Debug, $"Client Connected: {e.Connection.Guid}:{e.Connection.IPAddress}:{e.Connection.Port}");

            Thread.Sleep(2000);

            e.Connection.Disconnect();
        }

        private void Handler_ClientDisconnected(object sender, ClientConnectionEventArgs e)
        {
            Logger.Instance.Log(LogType.Debug, $"Client Diconnected: {e.Connection.Guid}:{e.Connection.IPAddress}:{e.Connection.Port}");
        }
    }
}