// <copyright file="ITimeSpanInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    public interface ITimeSpanInvoker
    {
        double TotalMilliseconds { get; }
    }
}