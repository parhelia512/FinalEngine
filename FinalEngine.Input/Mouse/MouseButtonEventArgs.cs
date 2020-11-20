// <copyright file="MouseButtonEventArgs.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    public sealed class MouseButtonEventArgs : EventArgs
    {
        public MouseButtonEventArgs(MouseButton button)
        {
            this.Button = button;
        }

        public MouseButton Button { get; }
    }
}