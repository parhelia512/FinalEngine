namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Input.Devices;

    /// <summary>
    ///   Provides event data for the <see cref="IMouseDevice.ButtonPressed"/> and <see cref="IMouseDevice.ButtonReleased"/> events.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public sealed class MouseButtonEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MouseButtonEventArgs"/> class.
        /// </summary>
        /// <param name="button">
        ///   Specifies a <see cref="MouseButton"/> that represents the button that raised the event.
        /// </param>
        public MouseButtonEventArgs(MouseButton button)
        {
            Button = button;
        }

        /// <summary>
        ///   Gets a <see cref="MouseButton"/> that represents the button that raised the event.
        /// </summary>
        /// <value>
        ///   The button that raised the event.
        /// </value>
        public MouseButton Button { get; }
    }
}