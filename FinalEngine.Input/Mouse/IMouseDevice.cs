// <copyright file="IMouseDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;
    using System.Drawing;

    /// <summary>
    ///     Defines an interface that provides access to common mouse device operations.
    /// </summary>
    public interface IMouseDevice
    {
        /// <summary>
        ///     Occurs when a mouse button is pressed.
        /// </summary>
        event EventHandler<MouseButtonEventArgs>? ButtonDown;

        /// <summary>
        ///     Occurs when a mouse button is released.
        /// </summary>
        event EventHandler<MouseButtonEventArgs>? ButtonUp;

        /// <summary>
        ///     Occurs when the location of the mouse has changed.
        /// </summary>
        event EventHandler<MouseMoveEventArgs>? Move;

        /// <summary>
        ///     Occurs when the position of the scroll wheel has changed.
        /// </summary>
        event EventHandler<MouseScrollEventArgs>? Scroll;

        void SetCursorLocation(PointF location);
    }
}