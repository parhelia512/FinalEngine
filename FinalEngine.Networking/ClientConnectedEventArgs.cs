// <copyright file="ClientConnectedEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    public class ClientConnectedEventArgs : EventArgs
    {
        public ClientConnectedEventArgs(IClientConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public IClientConnection Connection { get; }
    }
}