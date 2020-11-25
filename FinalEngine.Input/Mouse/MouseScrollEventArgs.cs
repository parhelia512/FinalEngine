// <copyright file="MouseScrollEventArgs.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;

    public class MouseScrollEventArgs : EventArgs
    {
        public double Delta { get; init; }
    }
}