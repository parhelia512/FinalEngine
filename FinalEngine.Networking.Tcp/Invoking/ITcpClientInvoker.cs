// <copyright file="ITcpClientInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    public interface ITcpClientInvoker
    {
        ISocketInvoker Socket { get; }

        void Close();
    }
}