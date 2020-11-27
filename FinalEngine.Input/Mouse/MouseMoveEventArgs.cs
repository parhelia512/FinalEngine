// <copyright file="MouseMoveEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;
    using System.Drawing;

    /// <summary>
    ///     Provides event data for the <see cref="IMouseDevice.Move"/> event.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class MouseMoveEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets the location of the mouse in window pixel coordinates.
        /// </summary>
        /// <value>
        ///     The location of the mouse in window pixel coordinates.
        /// </value>
        public PointF Location { get; init; }
    }
}