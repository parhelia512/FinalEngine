// <copyright file="ITimeSpan.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Invoking
{
    /// <summary>
    ///     Defines an interface that represents a time interval.
    /// </summary>
    /// <remarks>
    ///     This interface exists to provide easier abstraction and unit testing capabilities.
    /// </remarks>
    public interface ITimeSpanInvoker
    {
        /// <summary>
        ///     Gets the value of the current System.TimeSpan structure expressed in whole and
        ///     fractional milliseconds.
        /// </summary>
        /// <value>
        ///     The value of the current System.TimeSpan structure expressed in whole and fractional milliseconds.
        /// </value>
        double TotalMilliseconds { get; }
    }
}