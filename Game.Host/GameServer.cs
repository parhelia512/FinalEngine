// <copyright file="GameServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace Game.Host
{
    using System;
    using FinalEngine.Core;
    using FinalEngine.Networking.Tcp;

    public class GameServer : GameContainer
    {
        private readonly TcpServer server;

        public GameServer(TcpServer server)
        {
            this.server = server ?? throw new ArgumentNullException(nameof(server));
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}