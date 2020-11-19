// <copyright file="ITcpListenerInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    public interface ITcpListenerInvoker
    {
        void Start();

        void Stop();
    }
}