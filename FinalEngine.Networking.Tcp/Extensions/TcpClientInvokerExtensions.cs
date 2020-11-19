// <copyright file="TcpClientInvokerExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Networking.Tcp.Invoking;

    [ExcludeFromCodeCoverage]
    public static class TcpClientInvokerExtensions
    {
        public static IIPAddressInvoker GetLocalAddress(this ITcpClientInvoker client)
        {
            return client.Client.LocalEndPoint.ToIPEndPoint().Address;
        }

        public static int GetLocalPort(this ITcpClientInvoker client)
        {
            return client.Client.LocalEndPoint.ToIPEndPoint().Port;
        }

        public static IIPAddressInvoker GetRemoteAddress(this ITcpClientInvoker client)
        {
            return client.Client.GetRemoteAddress();
        }

        public static int GetRemotePort(this ITcpClientInvoker client)
        {
            return client.Client.GetRemotePort();
        }
    }
}