// <copyright file="IMouseDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    /// <summary>
    ///     Defines an interface that represents a (physical or virtual) mouse device.
    /// </summary>
    public interface IMouseDevice
    {
        /// <summary>
        ///     Occurs when a mouse button on this <see cref="IMouseDevice"/> has been pressed.
        /// </summary>
        event EventHandler<MouseButtonEventArgs> ButtonPressed;

        /// <summary>
        ///     Occurs when a mouse button on this <see cref="IMouseDevice"/> has been released.
        /// </summary>
        event EventHandler<MouseButtonEventArgs> ButtonReleased;

        /// <summary>
        ///     Occurs when the position of the <see cref="IMouseDevice"/> has changed.
        /// </summary>
        event EventHandler<MouseMoveEventArgs> PositionChanged;

        /// <summary>
        ///     Occurs when the position of the scroll wheel on this <see cref="IMouseDevice"/> has changed.
        /// </summary>
        event EventHandler<MouseWheelEventArgs> WheelPositionChanged;
    }
}