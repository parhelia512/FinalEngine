// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace Game.Host
{
    using System;
    using FinalEngine.Core;
    using FinalEngine.Core.Threading;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
    using FinalEngine.Networking.Tcp;
    using FinalEngine.Networking.Tcp.Invoking;

    internal static class Program
    {
        private static void Main()
        {
            Logger.Instance.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));

            var listener = new TcpListenerInvoker("127.0.0.1", 43594);

            var factory = new TcpClientConnectionFactory();
            var handler = new TcpConnectionHandler(listener, factory);

            var executer = new TaskExecuter();
            var server = new TcpServer(listener, executer, handler);

            using (var game = new GameServer(server, handler))
            {
                var gameTime = new GameTime(120.0d);
                var processor = gameTime as IGameTimeProcessor;

                game.Run(gameTime, processor);
            }

            Console.ReadLine();
        }
    }
}