// <copyright file="ITaskExecuter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITaskExecuter
    {
        Task Create(Action action, CancellationToken token);

        Task CreateAndRun(Action action, CancellationToken token);
    }
}