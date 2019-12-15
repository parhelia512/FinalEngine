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
                default:
                    return Key.Unknown;
            }
        }

        private KeyModifier ConvertToNativeModifiers(bool control, bool alt, bool shift)
        {
            KeyModifier result = default;

            if (control)
            {
                result |= KeyModifier.Control;
            }

            if (alt)
            {
                result |= KeyModifier.Alt;
            }

            if (shift)
            {
                result |= KeyModifier.Shift;
            }

            return result;
        }

        private void NativeWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            KeyPressed?.Invoke(this, new KeyEventArgs(ConvertToNativeKey(e.Key),
                                                      LockableKeyState.Unknown,
                                                      LockableKeyState.Unknown,
                                                      LockableKeyState.Unknown,
                                                      ConvertToNativeModifiers(e.Control, e.Alt, e.Shift)));
        }

        private void NativeWindow_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            KeyReleased?.Invoke(this, new KeyEventArgs(ConvertToNativeKey(e.Key),
                                                       LockableKeyState.Unknown,
                                                       LockableKeyState.Unknown,
                                                       LockableKeyState.Unknown,
                                                       ConvertToNativeModifiers(e.Control, e.Alt, e.Shift)));
        }
    }
}