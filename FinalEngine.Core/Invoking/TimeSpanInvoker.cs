// <copyright file="TimeSpanInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Provides a <see cref="TimeSpan"/> implementation of the <see cref="ITimeSpan"/> interface.
    /// </summary>
    /// <seealso cref="FinalEngine.Core.Invoking.ITimeSpan"/>
    [ExcludeFromCodeCoverage]
    public class TimeSpanInvoker : ITimeSpan
    {
        /// <summary>
        ///     The time span.
        /// </summary>
        private readonly TimeSpan timeSpan;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeSpanInvoker"/> class.
        /// </summary>
        /// <remarks>
        ///     This class constructor instantiates a default <see cref="TimeSpan"/> internally.
        /// </remarks>
        public TimeSpanInvoker()
        {
            this.timeSpan = default(TimeSpan);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeSpanInvoker"/> class.
        /// </summary>
        /// <param name="timeSpan">
        ///     Specifies a <see cref="TimeSpan"/> that represents the time span used by this invoker.
        /// </param>
        public TimeSpanInvoker(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        /// <summary>
        ///     Gets the value of the current System.TimeSpan structure expressed in whole and
        ///     fractional milliseconds.
        /// </summary>
        /// <value>
        ///     The value of the current System.TimeSpan structure expressed in whole and fractional milliseconds.
        /// </value>
        public double TotalMilliseconds
        {
            get { return this.timeSpan.TotalMilliseconds; }
        }
    }
}