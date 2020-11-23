// <copyright file="TaskExecuter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class TaskExecuter : ITaskExecuter
    {
        public Task Create(Action action, CancellationToken token)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return new Task(action, token);
        }

        public Task CreateAndRun(Action action, CancellationToken token)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return Task.Run(action, token);
        }
    }
}