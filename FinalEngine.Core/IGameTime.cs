// <copyright file="IGameTime.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    /// <summary>
    ///     Defines an interface that provides properties for handling time within a real-time application.
    /// </summary>
    public interface IGameTime
    {
        /// <summary>
        ///     Gets the delta (the amount of time it took to process the previous frame, in milliseconds).
        /// </summary>
        /// <value>
        ///     The delta (the amount of time it took to process the previous frame, in milliseconds).
        /// </value>
        double Delta { get; }

        /// <summary>
        ///     Gets the current FPS (frames-per-second).
        /// </summary>
        /// <value>
        ///     The current FPS (frames-per-second).
        /// </value>
        double FPS { get; }
    }
}