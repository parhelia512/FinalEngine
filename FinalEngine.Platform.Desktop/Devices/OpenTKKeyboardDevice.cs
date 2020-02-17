// <copyright file="OpenTKKeyboardDevice.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.Devices
{
    using System;
    using FinalEngine.Input;
    using FinalEngine.Input.Devices;
    using FinalEngine.Input.Events;
    using OpenTK;
    using OpenTK.Input;
    using Key = FinalEngine.Input.Key;
    using TKKey = OpenTK.Input.Key;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IKeyboardDevice"/>.
    /// </summary>
    /// <seealso cref="IKeyboardDevice"/>
    public sealed class OpenTKKeyboardDevice : IKeyboardDevice
    {
        /// <summary>
        ///   The native window.
        /// </summary>
        private readonly INativeWindow nativeWindow;

        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenTKKeyboardDevice"/> class.
        /// </summary>
        /// <param name="nativeWindow">
        ///   Specifies a <see cref="INativeWindow"/> that represents the native window that will be used to hook onto mouse related events.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="nativeWindow"/> parameter is null.
        /// </exception>
        public OpenTKKeyboardDevice(INativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow), $"The specified {nameof(nativeWindow)} parameter is null.");

            nativeWindow.KeyDown += this.NativeWindow_KeyDown;
            nativeWindow.KeyUp += this.NativeWindow_KeyUp;
        }

        /// <summary>
        ///   Finalizes an instance of the <see cref="OpenTKKeyboardDevice"/> class.
        /// </summary>
        ~OpenTKKeyboardDevice()
        {
            this.nativeWindow.KeyDown -= this.NativeWindow_KeyDown;
            this.nativeWindow.KeyUp -= this.NativeWindow_KeyUp;
        }

        /// <summary>
        ///   Occurs when a keyboard key on this <see cref="OpenTKKeyboardDevice"/> has been pressed.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyPressed;

        /// <summary>
        ///   Occurs when a keyboard key on this <see cref="OpenTKKeyboardDevice"/> has been released.
        /// </summary>
        public event EventHandler<KeyEventArgs> KeyReleased;

        /// <summary>
        ///   Converts the specified <paramref name="key"/> to it's corresponding <see cref="Key"/>.
        /// </summary>
        /// <param name="key">
        ///   Specifies a <see cref="TKKey"/> that represents the key to convert.
        /// </param>
        /// <returns>
        ///   The specified <paramref name="key"/>, converted to a <see cref="Key"/>.
        /// </returns>
        private Key ConvertToNativeKey(TKKey key)
        {
            switch (key)
            {
                case TKKey.Unknown:
                    return Key.Unknown;

                case TKKey.ShiftLeft:
                    return Key.ShiftLeft;

                case TKKey.ShiftRight:
                    return Key.ShiftRight;

                case TKKey.ControlLeft:
                    return Key.ControlLeft;

                case TKKey.ControlRight:
                    return Key.ControlRight;

                case TKKey.AltLeft:
                    return Key.AltLeft;

                case TKKey.AltRight:
                    return Key.AltRight;

                case TKKey.WinLeft:
                    return Key.OSLeft;

                case TKKey.WinRight:
                    return Key.OSRight;

                case TKKey.Menu:
                    return Key.Menu;

                case TKKey.F1:
                    return Key.F1;

                case TKKey.F2:
                    return Key.F2;

                case TKKey.F3:
                    return Key.F3;

                case TKKey.F4:
                    return Key.F4;

                case TKKey.F5:
                    return Key.F5;

                case TKKey.F6:
                    return Key.F6;

                case TKKey.F7:
                    return Key.F7;

                case TKKey.F8:
                    return Key.F8;

                case TKKey.F9:
                    return Key.F9;

                case TKKey.F10:
                    return Key.F10;

                case TKKey.F11:
                    return Key.F11;

                case TKKey.F12:
                    return Key.F12;

                case TKKey.F13:
                    return Key.F13;

                case TKKey.F14:
                    return Key.F14;

                case TKKey.F15:
                    return Key.F15;

                case TKKey.F16:
                    return Key.F16;

                case TKKey.F17:
                    return Key.F17;

                case TKKey.F18:
                    return Key.F18;

                case TKKey.F19:
                    return Key.F19;

                case TKKey.F20:
                    return Key.F20;

                case TKKey.F21:
                    return Key.F21;

                case TKKey.F22:
                    return Key.F22;

                case TKKey.F23:
                    return Key.F23;

                case TKKey.F24:
                    return Key.F24;

                case TKKey.F25:
                    return Key.F25;

                case TKKey.F26:
                    return Key.F26;

                case TKKey.F27:
                    return Key.F27;

                case TKKey.F28:
                    return Key.F28;

                case TKKey.F29:
                    return Key.F29;

                case TKKey.F30:
                    return Key.F30;

                case TKKey.F31:
                    return Key.F31;

                case TKKey.F32:
                    return Key.F32;

                case TKKey.F33:
                    return Key.F33;

                case TKKey.F34:
                    return Key.F34;

                case TKKey.F35:
                    return Key.F35;

                case TKKey.Up:
                    return Key.Up;

                case TKKey.Down:
                    return Key.Down;

                case TKKey.Left:
                    return Key.Left;

                case TKKey.Right:
                    return Key.Right;

                case TKKey.Enter:
                    return Key.Enter;

                case TKKey.Escape:
                    return Key.Escape;

                case TKKey.Space:
                    return Key.Space;

                case TKKey.Tab:
                    return Key.Tab;

                case TKKey.BackSpace:
                    return Key.BackSpace;

                case TKKey.Insert:
                    return Key.Insert;

                case TKKey.Delete:
                    return Key.Delete;

                case TKKey.PageUp:
                    return Key.PageUp;

                case TKKey.PageDown:
                    return Key.PageDown;

                case TKKey.Home:
                    return Key.Home;

                case TKKey.End:
                    return Key.End;

                case TKKey.CapsLock:
                    return Key.CapsLock;

                case TKKey.ScrollLock:
                    return Key.ScrollLock;

                case TKKey.PrintScreen:
                    return Key.PrintScreen;

                case TKKey.Pause:
                    return Key.Pause;

                case TKKey.NumLock:
                    return Key.NumLock;

                case TKKey.Clear:
                    return Key.Clear;

                case TKKey.Sleep:
                    return Key.Sleep;

                case TKKey.Keypad0:
                    return Key.Keypad0;

                case TKKey.Keypad1:
                    return Key.Keypad1;

                case TKKey.Keypad2:
                    return Key.Keypad2;

                case TKKey.Keypad3:
                    return Key.Keypad3;

                case TKKey.Keypad4:
                    return Key.Keypad4;

                case TKKey.Keypad5:
                    return Key.Keypad5;

                case TKKey.Keypad6:
                    return Key.Keypad6;

                case TKKey.Keypad7:
                    return Key.Keypad7;

                case TKKey.Keypad8:
                    return Key.Keypad8;

                case TKKey.Keypad9:
                    return Key.Keypad9;

                case TKKey.KeypadDivide:
                    return Key.KeypadDivide;

                case TKKey.KeypadMultiply:
                    return Key.KeypadMultiply;

                case TKKey.KeypadSubtract:
                    return Key.KeypadSubtract;

                case TKKey.KeypadPlus:
                    return Key.KeypadAdd;

                case TKKey.KeypadPeriod:
                    return Key.KeypadPeriod;

                case TKKey.KeypadEnter:
                    return Key.KeypadEnter;

                case TKKey.A:
                    return Key.A;

                case TKKey.B:
                    return Key.B;

                case TKKey.C:
                    return Key.C;

                case TKKey.D:
                    return Key.D;

                case TKKey.E:
                    return Key.E;

                case TKKey.F:
                    return Key.F;

                case TKKey.G:
                    return Key.G;

                case TKKey.H:
                    return Key.H;

                case TKKey.I:
                    return Key.I;

                case TKKey.J:
                    return Key.J;

                case TKKey.K:
                    return Key.K;

                case TKKey.L:
                    return Key.L;

                case TKKey.M:
                    return Key.M;

                case TKKey.N:
                    return Key.N;

                case TKKey.O:
                    return Key.O;

                case TKKey.P:
                    return Key.P;

                case TKKey.Q:
                    return Key.Q;

                case TKKey.R:
                    return Key.R;

                case TKKey.S:
                    return Key.S;

                case TKKey.T:
                    return Key.T;

                case TKKey.U:
                    return Key.U;

                case TKKey.V:
                    return Key.V;

                case TKKey.W:
                    return Key.W;

                case TKKey.X:
                    return Key.X;

                case TKKey.Y:
                    return Key.Y;

                case TKKey.Z:
                    return Key.Z;

                case TKKey.Number0:
                    return Key.Number0;

                case TKKey.Number1:
                    return Key.Number1;

                case TKKey.Number2:
                    return Key.Number2;

                case TKKey.Number3:
                    return Key.Number3;

                case TKKey.Number4:
                    return Key.Number4;

                case TKKey.Number5:
                    return Key.Number5;

                case TKKey.Number6:
                    return Key.Number6;

                case TKKey.Number7:
                    return Key.Number7;

                case TKKey.Number8:
                    return Key.Number8;

                case TKKey.Number9:
                    return Key.Number9;

                case TKKey.Grave:
                    return Key.Grave;

                case TKKey.Minus:
                    return Key.Subtract;

                case TKKey.Plus:
                    return Key.Add;

                case TKKey.BracketLeft:
                    return Key.BracketLeft;

                case TKKey.BracketRight:
                    return Key.BracketRight;

                case TKKey.Semicolon:
                    return Key.Semicolon;

                case TKKey.Quote:
                    return Key.Quote;

                case TKKey.Comma:
                    return Key.Comma;

                case TKKey.Period:
                    return Key.Period;

                case TKKey.Slash:
                    return Key.Slash;

                case TKKey.BackSlash:
                    return Key.BackSlash;

                case TKKey.NonUSBackSlash:
                    return Key.NonUSBackSlash;

                default:
                    return Key.Unknown;
            }
        }

        /// <summary>
        ///   Handles the KeyDown event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="KeyboardKeyEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            var keyEventsArgs = new KeyEventArgs(
                this.ConvertToNativeKey(e.Key),
                LockableKeyState.Unknown,
                LockableKeyState.Unknown,
                LockableKeyState.Unknown,
                e.Shift,
                e.Alt,
                e.Control);

            this.KeyPressed?.Invoke(this, keyEventsArgs);
        }

        /// <summary>
        ///   Handles the KeyUp event of the <see cref="INativeWindow"/> control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   Specifies the <see cref="KeyboardKeyEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            var keyEventsArgs = new KeyEventArgs(
                this.ConvertToNativeKey(e.Key),
                LockableKeyState.Unknown,
                LockableKeyState.Unknown,
                LockableKeyState.Unknown,
                e.Shift,
                e.Alt,
                e.Control);

            this.KeyReleased?.Invoke(this, keyEventsArgs);
        }
    }
}