// <copyright file="TaskScheduler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    [ExcludeFromCodeCoverage]
    public class TaskExecuter : ITaskExecuter
    {
        public void Execute(ThreadStart start)
        {
            var thread = new Thread(start);
            thread.Start();
        }
    }
}