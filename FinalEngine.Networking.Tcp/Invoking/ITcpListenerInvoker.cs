// <copyright file="ITcpListenerInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    using System.Threading.Tasks;

    public interface ITcpListenerInvoker
    {
        ISocketInvoker Server { get; }

        Task<ITcpClientInvoker> AcceptTcpClientAsync();

        void Start();

        void Stop();
    }
}