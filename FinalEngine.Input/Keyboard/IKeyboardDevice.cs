// <copyright file="IKeyboardDevice.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;

    public interface IKeyboardDevice
    {
        event EventHandler<KeyEventArgs> KeyPressed;

        event EventHandler<KeyEventArgs> KeyReleased;
    }
}