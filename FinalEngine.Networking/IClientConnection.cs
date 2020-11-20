// <copyright file="IClientConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    public interface IClientConnection
    {
        Guid Guid { get; }

        string IPAddress { get; }

        int Port { get; }
    }
}