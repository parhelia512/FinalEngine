// <copyright file="IKeyboardDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;

    /// <summary>
    ///   Defines an interface that represents a (physical or virtual) keyboard device.
    /// </summary>
    public interface IKeyboardDevice
    {
        /// <summary>
        ///   Occurs when a keyboard key on this <see cref="IKeyboardDevice"/> has been pressed.
        /// </summary>
        event EventHandler<KeyEventArgs> KeyPressed;

        /// <summary>
        ///   Occurs when a keyboard key on this <see cref="IKeyboardDevice"/> has been released.
        /// </summary>
        event EventHandler<KeyEventArgs> KeyReleased;
    }
}