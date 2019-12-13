namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Drawing;

    public sealed class MouseMoveEventArgs : EventArgs
    {
        public MouseMoveEventArgs(PointF location, PointF delta)
        {
            Location = location;
            Delta = delta;
        }

        // The change in position produced by this event
        public PointF Delta { get; }

        public PointF Location { get; }
    }
}