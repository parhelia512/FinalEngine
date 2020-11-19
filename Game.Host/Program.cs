// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace Game.Host
{
    using System;
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

            var invoker = new TcpListenerInvoker("127.0.0.1", 43594);
            var handler = new TcpConnectionHandler(invoker);
            var server = new TcpServer(invoker, handler);

            using (var game = new GameServer(server))
            {
                game.Run();
            }
        }
    }
}