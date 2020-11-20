// <copyright file="MouseWheelEventArgs.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    public sealed class MouseWheelEventArgs : EventArgs
    {
        public MouseWheelEventArgs(float delta)
        {
            this.Delta = delta;
        }

        public float Delta { get; }
    }
}