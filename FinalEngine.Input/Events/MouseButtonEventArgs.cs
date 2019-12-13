namespace FinalEngine.Input.Events
{
    using System;

    public sealed class MouseButtonEventArgs : EventArgs
    {
        public MouseButtonEventArgs(MouseButton button)
        {
            Button = button;
        }

        public MouseButton Button { get; }
    }
}