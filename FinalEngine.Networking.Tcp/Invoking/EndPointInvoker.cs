// <copyright file="EndPointInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    public interface IEndPointInvoker
    {
        IIPEndPointInvoker ToIPEndPoint();
    }

    [ExcludeFromCodeCoverage]
    public class EndPointInvoker : IEndPointInvoker
    {
        private readonly EndPoint endPoint;

        public EndPointInvoker(EndPoint endPoint)
        {
            this.endPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));
        }

        public IIPEndPointInvoker ToIPEndPoint()
        {
            return new IPEndPointInvoker((IPEndPoint)this.endPoint);
        }
    }
}