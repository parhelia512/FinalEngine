namespace FinalEngine.Platform.Desktop.Devices
{
    using System;
    using FinalEngine.Input;
    using FinalEngine.Input.Devices;
    using FinalEngine.Input.Events;
    using OpenTK;
    using OpenTK.Input;
    using Key = Input.Key;

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

        private Key ConvertToNativeKey(OpenTK.Input.Key key)
        {
            switch (key)
            {
                // TODO: Fill this.
                default:
                    return Key.Unknown;
            }
        }

        private void NativeWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            KeyPressed?.Invoke(this, new KeyEventArgs(ConvertToNativeKey(e.Key),
                                                      LockableKeyState.Unknown,
                                                      LockableKeyState.Unknown,
                                                      LockableKeyState.Unknown,
                                                      e.Shift, e.Alt, e.Control));
        }

        private void NativeWindow_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            KeyReleased?.Invoke(this, new KeyEventArgs(ConvertToNativeKey(e.Key),
                                                       LockableKeyState.Unknown,
                                                       LockableKeyState.Unknown,
                                                       LockableKeyState.Unknown,
                                                      e.Shift, e.Alt, e.Control));
        }
    }
}