namespace FinalEngine.Input.Devices
{
    using System;
    using FinalEngine.Input.Events;

    public interface IMouseDevice
    {
        event EventHandler<MouseButtonEventArgs> ButtonDown;

        event EventHandler<MouseButtonEventArgs> ButtonUp;

        event EventHandler<MouseMoveEventArgs> MouseMove;

        event EventHandler<MouseMoveEventArgs> MouseWheel;
    }
}