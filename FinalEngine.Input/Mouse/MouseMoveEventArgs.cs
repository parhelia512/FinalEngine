// <copyright file="MouseMoveEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;
    using FinalEngine.Drawing;

    public sealed class MouseMoveEventArgs : EventArgs
    {
        public MouseMoveEventArgs(PointF location)
        {
            this.Location = location;
        }

        public PointF Location { get; }
    }
}