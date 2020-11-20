// <copyright file="ITaskExecuter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Threading
{
    using System.Threading;

    public interface ITaskExecuter
    {
        void Execute(ThreadStart start);
    }
}