﻿// <copyright file="MouseWheelEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    /// <summary>
    ///     Provides event data for the <see cref="IMouseDevice.WheelPositionChanged"/> event.
    /// </summary>
    /// <seealso cref="EventArgs"/>
    public sealed class MouseWheelEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseWheelEventArgs"/> class.
        /// </summary>
        /// <param name="delta">
        ///     Specifies a <see cref="float"/> that represents the number of detents the scroll
        ///     wheel has rotated at the time of raising the event.
        /// </param>
        public MouseWheelEventArgs(float delta)
        {
            this.Delta = delta;
        }

        /// <summary>
        ///     Gets a <see cref="float"/> that represents the number of detents the scroll wheel
        ///     has rotated at the time of raising the event.
        /// </summary>
        /// <value>
        ///     The number of detents the scroll wheel has rotated at the time of raising the event.
        /// </value>
        public float Delta { get; }
    }
}