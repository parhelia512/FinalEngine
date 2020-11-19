// <copyright file="StopwatchInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Provides a <see cref="Stopwatch"/> implementation of the <see cref="IStopwatchInvoker"/> interface.
    /// </summary>
    /// <seealso cref="FinalEngine.Core.Invoking.IStopwatchInvoker"/>
    [ExcludeFromCodeCoverage]
    public class StopwatchInvoker : IStopwatchInvoker
    {
        /// <summary>
        ///     The stopwatch.
        /// </summary>
        private readonly Stopwatch watch;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StopwatchInvoker"/> class.
        /// </summary>
        /// <remarks>
        ///     This class constructor creates a new stopwatch internally.
        /// </remarks>
        public StopwatchInvoker()
        {
            this.watch = new Stopwatch();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="StopwatchInvoker"/> class.
        /// </summary>
        /// <param name="watch">
        ///     Specifies a <see cref="Stopwatch"/> that represents the watch used by the invoker.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="watch"/> parameter is null.
        /// </exception>
        public StopwatchInvoker(Stopwatch watch)
        {
            this.watch = watch ?? throw new ArgumentNullException(nameof(watch));
        }

        /// <summary>
        ///     Gets the total elapsed time measured by the current instance.
        /// </summary>
        /// <value>
        ///     The total elapsed time measured by the current instance.
        /// </value>
        public ITimeSpanInvoker Elapsed
        {
            get { return new TimeSpanInvoker(this.watch.Elapsed); }
        }

        /// <summary>
        ///     Gets a value indicating whether the timer is running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the timer is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning
        {
            get { return this.watch.IsRunning; }
        }

        /// <summary>
        ///     Stops time interval measurement, resets the elapsed time to zero, and starts
        ///     measuring elapsed time.
        /// </summary>
        public void Restart()
        {
            this.watch.Restart();
        }
    }
}