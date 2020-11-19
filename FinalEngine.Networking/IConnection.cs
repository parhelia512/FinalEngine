// <copyright file="IConnection.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    public interface IConnection
    {
        string Address { get; }

        Guid Guid { get; }

        int Port { get; }

        void Disconnect();
    }
}