namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Drawing;
    using FinalEngine.Input.Devices;

    /// <summary>
    ///   Provides event data for the <see cref="IMouseDevice.PositionChanged"/> event.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public sealed class MouseMoveEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseMoveEventArgs"/> class.
        /// </summary>
        /// <param name="location">
        ///   Specifies a <see cref="PointF"/> that represents the location of cursor in window pixel coordinates during the time that the event was raised.
        /// </param>
        public MouseMoveEventArgs(PointF location)
        {
            Location = location;
        }

        /// <summary>
        ///   Gets a <see cref="PointF"/> that represents the location of cursor in window pixel coordinates during the time that the event was raised.
        /// </summary>
        /// <value>
        ///   The location of cursor in window pixel coordinates during the time that the event was raised.
        /// </value>
        public PointF Location { get; }
    }
}