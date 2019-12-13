namespace FinalEngine.Input.Devices
{
    using System;
    using FinalEngine.Input.Events;

    /// <summary>
    ///   Defines an interface that represents a physical or virtual mouse device.
    /// </summary>
    public interface IMouseDevice
    {
        /// <summary>
        ///   Occurs when a mouse button on this <see cref="IMouseDevice"/> has been pressed.
        /// </summary>
        event EventHandler<MouseButtonEventArgs> ButtonPressed;

        /// <summary>
        ///   Occurs when the mouse button on this <see cref="IMouseDevice"/> has been released.
        /// </summary>
        event EventHandler<MouseButtonEventArgs> ButtonReleased;

        /// <summary>
        ///   Occurs when the mouse position of this <see cref="IMouseDevice"/> has changed.
        /// </summary>
        event EventHandler<MouseMoveEventArgs> PositionChanged;

        /// <summary>
        ///   Occurs when the mouse wheel position of this <see cref="IMouseDevice"/> has changed.
        /// </summary>
        event EventHandler<MouseMoveEventArgs> WheelPositionChanged;
    }
}