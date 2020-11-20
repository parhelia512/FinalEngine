// <copyright file="TimeSpanInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TimeSpanInvoker : ITimeSpanInvoker
    {
        private readonly TimeSpan timeSpan;

        public TimeSpanInvoker()
        {
            this.timeSpan = default(TimeSpan);
        }

        public TimeSpanInvoker(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        public double TotalMilliseconds
        {
            get { return this.timeSpan.TotalMilliseconds; }
        }
    }
}