namespace FinalEngine.Platform.Desktop.Devices
{
    using System;
    using FinalEngine.Input.Devices;
    using FinalEngine.Input.Events;
    using OpenTK;
    using MouseButton = Input.MouseButton;
    using PointF = Drawing.PointF;

    public sealed class OpenTKMouseDevice : IMouseDevice
    {
        private readonly INativeWindow nativeWindow;

        public OpenTKMouseDevice(INativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow), $"The specified { nameof(nativeWindow) } parameter is null.");

            nativeWindow.MouseUp += NativeWindow_MouseUp;
            nativeWindow.MouseDown += NativeWindow_MouseDown;
            nativeWindow.MouseMove += NativeWindow_MouseMove;
            nativeWindow.MouseWheel += NativeWindow_MouseWheel;
        }

        ~OpenTKMouseDevice()
        {
            nativeWindow.MouseUp -= NativeWindow_MouseUp;
            nativeWindow.MouseDown -= NativeWindow_MouseDown;
            nativeWindow.MouseMove -= NativeWindow_MouseMove;
            nativeWindow.MouseWheel -= NativeWindow_MouseWheel;
        }

        public event EventHandler<MouseButtonEventArgs> ButtonPressed;

        public event EventHandler<MouseButtonEventArgs> ButtonReleased;

        public event EventHandler<MouseMoveEventArgs> PositionChanged;

        public event EventHandler<MouseWheelEventArgs> WheelPositionChanged;

        private MouseButton ConvertToNativeMouseButton(OpenTK.Input.MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                // TODO: Fill this.
                default:
                    return MouseButton.Unknown;
            }
        }

        private void NativeWindow_MouseDown(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            ButtonPressed?.Invoke(this, new MouseButtonEventArgs(ConvertToNativeMouseButton(e.Button)));
        }

        private void NativeWindow_MouseMove(object sender, OpenTK.Input.MouseMoveEventArgs e)
        {
            PositionChanged?.Invoke(this, new MouseMoveEventArgs(new PointF(e.Mouse.X, e.Mouse.Y)));
        }

        private void NativeWindow_MouseUp(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            ButtonReleased?.Invoke(this, new MouseButtonEventArgs(ConvertToNativeMouseButton(e.Button)));
        }

        private void NativeWindow_MouseWheel(object sender, OpenTK.Input.MouseWheelEventArgs e)
        {
            WheelPositionChanged?.Invoke(this, new MouseWheelEventArgs(e.DeltaPrecise));
        }
    }
}