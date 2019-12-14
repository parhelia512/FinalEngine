namespace FinalEngine.Platform.Desktop.Devices
{
    using System;
    using FinalEngine.Input.Devices;
    using FinalEngine.Input.Events;
    using OpenTK;

    public sealed class OpenTKKeyboardDevice : IKeyboardDevice
    {
        private readonly INativeWindow nativeWindow;

        public OpenTKKeyboardDevice(INativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow), $"The specified { nameof(nativeWindow) } parameter is null.");

            nativeWindow.KeyDown += NativeWindow_KeyDown;
            nativeWindow.KeyUp += NativeWindow_KeyUp;
        }

        ~OpenTKKeyboardDevice()
        {
            nativeWindow.KeyDown -= NativeWindow_KeyDown;
            nativeWindow.KeyUp -= NativeWindow_KeyUp;
        }

        public event EventHandler<KeyEventArgs> KeyPressed;

        public event EventHandler<KeyEventArgs> KeyReleased;

        private void NativeWindow_KeyDown(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NativeWindow_KeyUp(object sender, OpenTK.Input.KeyboardKeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}