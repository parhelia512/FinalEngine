namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Input.Devices;

    /// <summary>
    ///   Provides event data for the <see cref="IMouseDevice.WheelPositionChanged"/> event.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public sealed class MouseWheelEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseWheelEventArgs"/> class.
        /// </summary>
        /// <param name="delta">
        ///   Specifies the number of detents the mouse wheel has rotated.
        /// </param>
        public MouseWheelEventArgs(float delta)
        {
            Delta = delta;
        }

        /// <summary>
        ///   Gets a <see cref="float"/> that represents the number of detents the mouse wheel has rotated.
        /// </summary>
        /// <value>
        ///   The number of detents the mouse wheel has rotated.
        /// </value>
        public float Delta { get; }
    }
}