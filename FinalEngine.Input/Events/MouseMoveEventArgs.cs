namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Drawing;

    public sealed class MouseMoveEventArgs : EventArgs
    {
        public MouseMoveEventArgs(PointF location)
        {
            Location = location;
        }

        public PointF Location { get; }
    }
}