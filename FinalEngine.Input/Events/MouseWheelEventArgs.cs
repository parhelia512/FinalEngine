namespace FinalEngine.Input.Events
{
    using System;

    public sealed class MouseWheelEventArgs : EventArgs
    {
        public MouseWheelEventArgs(float delta)
        {
            Delta = delta;
        }

        public float Delta { get; }
    }
}