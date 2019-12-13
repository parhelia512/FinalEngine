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
        ///   Specifies the location of the cursor coordinates (in pixels) relative to the upper-left corner of a display.
        /// </param>
        public MouseMoveEventArgs(PointF location)
        {
            Location = location;
        }

        /// <summary>
        ///   Gets a <see cref="PointF"/> that represents the location (in pixels) of the cursor, relative to the upper-left corner of a display.
        /// </summary>
        /// <value>
        ///   The location (in pixels) of the cursor, relative to the upper-left corner of a display.
        /// </value>
        public PointF Location { get; }
    }
}