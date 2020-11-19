// <copyright file="IPEndPointInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    public interface IIPEndPointInvoker
    {
        IIPAddressInvoker Address { get; }

        int Port { get; }
    }

    [ExcludeFromCodeCoverage]
    public class IPEndPointInvoker : IIPEndPointInvoker
    {
        private readonly IPEndPoint ipEndPoint;

        public IPEndPointInvoker(IPEndPoint ipEndPoint)
        {
            this.ipEndPoint = ipEndPoint ?? throw new ArgumentNullException(nameof(ipEndPoint));
        }

        public IIPAddressInvoker Address
        {
            get { return new IPAddressInvoker(this.ipEndPoint.Address); }
        }

        public int Port
        {
            get { return this.ipEndPoint.Port; }
        }
    }
}