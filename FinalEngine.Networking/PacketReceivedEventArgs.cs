// <copyright file="PacketReceivedEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    using System;

    public class PacketReceivedEventArgs : EventArgs
    {
        public PacketReceivedEventArgs(IClientConnection connection, byte[] bytes)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this.Bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));
        }

        public byte[] Bytes { get; }

        public IClientConnection Connection { get; }
    }
}