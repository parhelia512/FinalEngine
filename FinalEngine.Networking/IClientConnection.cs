// <copyright file="IClientConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    public interface IClientConnection
    {
        string IPAddress { get; }

        int Port { get; }
    }
}