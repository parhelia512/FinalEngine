// <copyright file="IMouseDevice.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    public interface IMouseDevice
    {
        event EventHandler<MouseButtonEventArgs> ButtonPressed;

        event EventHandler<MouseButtonEventArgs> ButtonReleased;

        event EventHandler<MouseMoveEventArgs> PositionChanged;

        event EventHandler<MouseWheelEventArgs> WheelPositionChanged;
    }
}