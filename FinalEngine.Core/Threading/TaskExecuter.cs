// <copyright file="TaskExecuter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System.Threading;

    public class TaskExecuter : ITaskExecuter
    {
        public void Execute(ThreadStart start)
        {
            var thread = new Thread(start);
            thread.Start();
        }
    }
}