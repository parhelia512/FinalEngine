// <copyright file="ISocketInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking.Tcp.Invoking
{
    public interface ISocketInvoker
    {
        string GetAddress(AreaCode code);

        int GetPort(AreaCode code);
    }
}