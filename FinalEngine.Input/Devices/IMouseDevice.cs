namespace FinalEngine.Input.Devices
{
    using System;
    using FinalEngine.Input.Events;

    public interface IMouseDevice
    {
        event EventHandler<MouseButtonEventArgs> ButtonPressed;

        event EventHandler<MouseButtonEventArgs> ButtonReleased;

        event EventHandler<MouseMoveEventArgs> PositionChanged;

        event EventHandler<MouseMoveEventArgs> WheelPositionChanged;
    }
}