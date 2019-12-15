namespace FinalEngine.Platform.Desktop.Devices
{
    using System;
    using FinalEngine.Input.Devices;
    using FinalEngine.Input.Events;
    using OpenTK;
    using MouseButton = Input.MouseButton;
    using PointF = Drawing.PointF;
    using TKMouseButton = OpenTK.Input.MouseButton;

    /// <summary>
    ///   Provides an OpenTK implementaiton of an <see cref="IMouseDevice"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Input.Devices.IMouseDevice"/>
    public sealed class OpenTKMouseDevice : IMouseDevice
    {
        /// <summary>
        ///   The native window.
        /// </summary>
        private readonly INativeWindow nativeWindow;

        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenTKMouseDevice"/> class.
        /// </summary>
        /// <param name="nativeWindow">
        ///   Specifies a <see cref="INativeWindow"/> that represents the native window that will be used to hook onto mouse related events.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="nativeWindow"/> parameter is null.
        /// </exception>
        public OpenTKMouseDevice(INativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow), $"The specified { nameof(nativeWindow) } parameter is null.");

            nativeWindow.MouseUp += NativeWindow_MouseUp;
            nativeWindow.MouseDown += NativeWindow_MouseDown;
            nativeWindow.MouseMove += NativeWindow_MouseMove;
            nativeWindow.MouseWheel += NativeWindow_MouseWheel;
        }

        /// <summary>
        ///   Finalizes an instance of the <see cref="OpenTKMouseDevice"/> class.
        /// </summary>
        ~OpenTKMouseDevice()
        {
            nativeWindow.MouseUp -= NativeWindow_MouseUp;
            nativeWindow.MouseDown -= NativeWindow_MouseDown;
            nativeWindow.MouseMove -= NativeWindow_MouseMove;
            nativeWindow.MouseWheel -= NativeWindow_MouseWheel;
        }

        /// <summary>
        ///   Occurs when a mouse button on this <see cref="OpenTKMouseDevice"/> has been pressed.
        /// </summary>
        public event EventHandler<MouseButtonEventArgs> ButtonPressed;

        /// <summary>
        ///   Occurs when a mouse button on this <see cref="OpenTKMouseDevice"/> has been released.
        /// </summary>
        public event EventHandler<MouseButtonEventArgs> ButtonReleased;

        /// <summary>
        ///   Occurs when the position of the <see cref="OpenTKMouseDevice"/> has changed.
        /// </summary>
        public event EventHandler<MouseMoveEventArgs> PositionChanged;

        /// <summary>
        ///   Occurs when the position of the scroll wheel on this <see cref="OpenTKMouseDevice"/> has changed.
        /// </summary>
        public event EventHandler<MouseWheelEventArgs> WheelPositionChanged;

        /// <summary>
        ///   Converts the specified <paramref name="mouseButton"/> to it's corresponding <see cref="MouseButton"/>.
        /// </summary>
        /// <param name="mouseButton">
        ///   Specifies a <see cref="TKMouseButton"/> that represents the mouse button to convert.
        /// </param>
        /// <returns>
        ///   The specified <paramref name="mouseButton"/>, converted to a <see cref="MouseButton"/>.
        /// </returns>
        private MouseButton ConvertToNativeMouseButton(TKMouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case TKMouseButton.Left:
                    return MouseButton.Left;

                case TKMouseButton.Right:
                    return MouseButton.Right;

                case TKMouseButton.Middle:
                    return MouseButton.Middle;

                default:
                    return MouseButton.Unknown;
            }
        }

        /// <summary>
        ///   Handles the MouseDown event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="OpenTK.Input.MouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseDown(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            ButtonPressed?.Invoke(this, new MouseButtonEventArgs(ConvertToNativeMouseButton(e.Button)));
        }

        /// <summary>
        ///   Handles the MouseMove event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="OpenTK.Input.MouseMoveEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseMove(object sender, OpenTK.Input.MouseMoveEventArgs e)
        {
            PositionChanged?.Invoke(this, new MouseMoveEventArgs(new PointF(e.Mouse.X, e.Mouse.Y)));
        }

        /// <summary>
        ///   Handles the MouseUp event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="OpenTK.Input.MouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseUp(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            ButtonReleased?.Invoke(this, new MouseButtonEventArgs(ConvertToNativeMouseButton(e.Button)));
        }

        /// <summary>
        ///   Handles the MouseWheel event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="OpenTK.Input.MouseWheelEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseWheel(object sender, OpenTK.Input.MouseWheelEventArgs e)
        {
            WheelPositionChanged?.Invoke(this, new MouseWheelEventArgs(e.DeltaPrecise));
        }
    }
}