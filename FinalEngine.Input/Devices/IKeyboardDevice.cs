namespace FinalEngine.Input.Devices
{
    using System;
    using FinalEngine.Input.Events;

    public interface IKeyboardDevice
    {
        event EventHandler<KeyEventArgs> KeyPressed;

        event EventHandler<KeyEventArgs> KeyReleased;
    }
}