// <copyright file="IPAddressInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    public interface IIPAddressInvoker
    {
    }

    [ExcludeFromCodeCoverage]
    public class IPAddressInvoker : IIPAddressInvoker
    {
        private readonly IPAddress address;

        public IPAddressInvoker(IPAddress ipAddress)
        {
            this.address = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
        }

        public override string ToString()
        {
            return this.address.ToString();
        }
    }
}