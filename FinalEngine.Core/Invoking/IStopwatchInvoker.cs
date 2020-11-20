// <copyright file="IStopwatchInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    public interface IStopwatchInvoker
    {
        ITimeSpanInvoker Elapsed { get; }

        bool IsRunning { get; }

        void Restart();
    }
}