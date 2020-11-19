// <copyright file="GameServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace Game.Host
{
    using System;
    using FinalEngine.Core;
    using FinalEngine.Networking;

    public class GameServer : GameContainer
    {
        private readonly IServer server;

        public GameServer(IServer server)
        {
            this.server = server ?? throw new ArgumentNullException(nameof(server));
        }

        protected override void Initialize()
        {
            this.server.Start();

            base.Initialize();
        }
    }
}