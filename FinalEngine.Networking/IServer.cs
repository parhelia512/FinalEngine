// <copyright file="IServer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Networking
{
    public interface IServer
    {
        bool IsRunning { get; }

        int Port { get; }

        void Start();

        void Stop();
    }
}