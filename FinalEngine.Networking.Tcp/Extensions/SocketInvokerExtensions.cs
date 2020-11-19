// <copyright file="SocketInvokerExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Networking.Tcp.Invoking;

    [ExcludeFromCodeCoverage]
    public static class SocketInvokerExtensions
    {
        public static IIPAddressInvoker GetLocalAddress(this ISocketInvoker socket)
        {
            return socket.LocalEndPoint.ToIPEndPoint().Address;
        }

        public static int GetLocalPort(this ISocketInvoker socket)
        {
            return socket.LocalEndPoint.ToIPEndPoint().Port;
        }

        public static IIPAddressInvoker GetRemoteAddress(this ISocketInvoker socket)
        {
            return socket.RemoteEndPoint.ToIPEndPoint().Address;
        }

        public static int GetRemotePort(this ISocketInvoker socket)
        {
            return socket.RemoteEndPoint.ToIPEndPoint().Port;
        }
    }
}