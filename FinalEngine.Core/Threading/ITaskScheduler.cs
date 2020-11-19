// <copyright file="ITaskScheduler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System.Threading;

    public interface ITaskScheduler
    {
        void Execute(ThreadStart start);

        void Sleep(int ms);
    }
}