// <copyright file="TaskScheduler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ExcludeFromCodeCoverage]
    public class TaskScheduler : ITaskScheduler
    {
        public void Execute(ThreadStart start)
        {
            var thread = new Thread(start);
            thread.Start();
        }

        public void Sleep(int ms)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(ms));
        }
    }
}