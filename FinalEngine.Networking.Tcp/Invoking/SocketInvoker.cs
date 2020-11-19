// <copyright file="SocketInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Sockets;

    public enum AreaCode
    {
        Local,

        Remote,
    }

    public interface ISocketInvoker
    {
        string GetAddress(AreaCode code);

        int GetPort(AreaCode code);
    }

    [ExcludeFromCodeCoverage]
    public class SocketInvoker : ISocketInvoker
    {
        private readonly Socket socket;

        public SocketInvoker(Socket socket)
        {
            this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
        }

        public string GetAddress(AreaCode code)
        {
            return (this.GetEndPoint(code) as IPEndPoint).Address.ToString();
        }

        public int GetPort(AreaCode code)
        {
            return (this.GetEndPoint(code) as IPEndPoint).Port;
        }

        private EndPoint GetEndPoint(AreaCode code)
        {
            switch (code)
            {
                case AreaCode.Local:
                    return this.socket.LocalEndPoint;

                case AreaCode.Remote:
                    return this.socket.RemoteEndPoint;
            }

            return null;
        }
    }
}