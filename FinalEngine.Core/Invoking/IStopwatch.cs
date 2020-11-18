// <copyright file="IStopwatch.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    /// <summary>
    ///     Defines an interface that provides a set of methods and properties that you can use to
    ///     accurately measure elapsed time.
    /// </summary>
    /// <remarks>
    ///     This interface exists to provide easier abstraction and unit testing capabilities.
    /// </remarks>
    public interface IStopwatch
    {
        /// <summary>
        ///     Gets the total elapsed time measured by the current instance.
        /// </summary>
        /// <value>
        ///     The total elapsed time measured by the current instance.
        /// </value>
        ITimeSpan Elapsed { get; }

        /// <summary>
        ///     Gets a value indicating whether the timer is running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the timer is running; otherwise, <c>false</c>.
        /// </value>
        bool IsRunning { get; }

        /// <summary>
        ///     Stops time interval measurement, resets the elapsed time to zero, and starts
        ///     measuring elapsed time.
        /// </summary>
        void Restart();
    }
}