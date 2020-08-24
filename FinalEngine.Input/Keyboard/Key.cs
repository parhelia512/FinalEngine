// <copyright file="Key.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input
{
    /// <summary>
    ///   Enumerates the available keyboard key on a standard US-keyboard.
    /// </summary>
    public enum Key
    {
        /// <summary>
        ///   Specifies the Unknown key.
        /// </summary>
        Unknown,

        /// <summary>
        ///   Specifies the left Shift key.
        /// </summary>
        ShiftLeft,

        /// <summary>
        ///   Specifies the right Shift key.
        /// </summary>
        ShiftRight,

        /// <summary>
        ///   Specifies the left Control key.
        /// </summary>
        ControlLeft,

        /// <summary>
        ///   Specifies the right Control key.
        /// </summary>
        ControlRight,

        /// <summary>
        ///   Specifies the left ALT key.
        /// </summary>
        AltLeft,

        /// <summary>
        ///   Specifies the right ALT key.
        /// </summary>
        AltRight,

        /// <summary>
        ///   Specifies the left operating system key.
        /// </summary>
        OSLeft,

        /// <summary>
        ///   Specifies the right operating system key.
        /// </summary>
        OSRight,

        /// <summary>
        ///   Specifies the Menu key.
        /// </summary>
        Menu,

        /// <summary>
        ///   Specifies the F1 key.
        /// </summary>
        F1,

        /// <summary>
        ///   Specifies the F2 key.
        /// </summary>
        F2,

        /// <summary>
        ///   Specifies the F3 key.
        /// </summary>
        F3,

        /// <summary>
        ///   Specifies the F4 key.
        /// </summary>
        F4,

        /// <summary>
        ///   Specifies the F5 key.
        /// </summary>
        F5,

        /// <summary>
        ///   Specifies the F6 key.
        /// </summary>
        F6,

        /// <summary>
        ///   Specifies the F7 key.
        /// </summary>
        F7,

        /// <summary>
        ///   Specifies the F8 key.
        /// </summary>
        F8,

        /// <summary>
        ///   Specifies the F9 key.
        /// </summary>
        F9,

        /// <summary>
        ///   Specifies the F10 key.
        /// </summary>
        F10,

        /// <summary>
        ///   Specifies the F11 key.
        /// </summary>
        F11,

        /// <summary>
        ///   Specifies the F12 key.
        /// </summary>
        F12,

        /// <summary>
        ///   Specifies the F13 key.
        /// </summary>
        F13,

        /// <summary>
        ///   Specifies the F14 key.
        /// </summary>
        F14,

        /// <summary>
        ///   Specifies the F15 key.
        /// </summary>
        F15,

        /// <summary>
        ///   Specifies the F16 key.
        /// </summary>
        F16,

        /// <summary>
        ///   Specifies the F17 key.
        /// </summary>
        F17,

        /// <summary>
        ///   Specifies the F18 key.
        /// </summary>
        F18,

        /// <summary>
        ///   Specifies the F19 key.
        /// </summary>
        F19,

        /// <summary>
        ///   Specifies the F20 key.
        /// </summary>
        F20,

        /// <summary>
        ///   Specifies the F21 key.
        /// </summary>
        F21,

        /// <summary>
        ///   Specifies the F22 key.
        /// </summary>
        F22,

        /// <summary>
        ///   Specifies the F23 key.
        /// </summary>
        F23,

        /// <summary>
        ///   Specifies the F24 key.
        /// </summary>
        F24,

        /// <summary>
        ///   Specifies the F25 key.
        /// </summary>
        F25,

        /// <summary>
        ///   Specifies the F26 key.
        /// </summary>
        F26,

        /// <summary>
        ///   Specifies the F27 key.
        /// </summary>
        F27,

        /// <summary>
        ///   Specifies the F28 key.
        /// </summary>
        F28,

        /// <summary>
        ///   Specifies the F29 key.
        /// </summary>
        F29,

        /// <summary>
        ///   Specifies the F30 key.
        /// </summary>
        F30,

        /// <summary>
        ///   Specifies the F31 key.
        /// </summary>
        F31,

        /// <summary>
        ///   Specifies the F32 key.
        /// </summary>
        F32,

        /// <summary>
        ///   Specifies the F33 key.
        /// </summary>
        F33,

        /// <summary>
        ///   Specifies the F34 key.
        /// </summary>
        F34,

        /// <summary>
        ///   Specifies the F35 key.
        /// </summary>
        F35,

        /// <summary>
        ///   Specifies the Up key.
        /// </summary>
        Up,

        /// <summary>
        ///   Specifies the Down key.
        /// </summary>
        Down,

        /// <summary>
        ///   Specifies the Left key.
        /// </summary>
        Left,

        /// <summary>
        ///   Specifies the Right key.
        /// </summary>
        Right,

        /// <summary>
        ///   Specifies the Enter key.
        /// </summary>
        Enter,

        /// <summary>
        ///   Specifies the Escape key.
        /// </summary>
        Escape,

        /// <summary>
        ///   Specifies the Space key.
        /// </summary>
        Space,

        /// <summary>
        ///   Specifies the Tab key.
        /// </summary>
        Tab,

        /// <summary>
        ///   Specifies the Back Space key.
        /// </summary>
        BackSpace,

        /// <summary>
        ///   Specifies the Insert key.
        /// </summary>
        Insert,

        /// <summary>
        ///   Specifies the Delete key.
        /// </summary>
        Delete,

        /// <summary>
        ///   Specifies the Page Up key.
        /// </summary>
        PageUp,

        /// <summary>
        ///   Specifies the Page Down key.
        /// </summary>
        PageDown,

        /// <summary>
        ///   Specifies the Home key.
        /// </summary>
        Home,

        /// <summary>
        ///   Specifies the End key.
        /// </summary>
        End,

        /// <summary>
        ///   Specifies the Caps Lock key.
        /// </summary>
        CapsLock,

        /// <summary>
        ///   Specifies the Scroll Lock key.
        /// </summary>
        ScrollLock,

        /// <summary>
        ///   Specifies the Print Screen key.
        /// </summary>
        PrintScreen,

        /// <summary>
        ///   Specifies the Pause key.
        /// </summary>
        Pause,

        /// <summary>
        ///   Specifies the Number Lock key.
        /// </summary>
        NumLock,

        /// <summary>
        ///   Specifies the Clear key.
        /// </summary>
        Clear,

        /// <summary>
        ///   Specifies the Sleep key.
        /// </summary>
        Sleep,

        /// <summary>
        ///   Specifies the Keypad 0 key.
        /// </summary>
        Keypad0,

        /// <summary>
        ///   Specifies the Keypad 1 key.
        /// </summary>
        Keypad1,

        /// <summary>
        ///   Specifies the Keypad 2 key.
        /// </summary>
        Keypad2,

        /// <summary>
        ///   Specifies the Keypad 3 key.
        /// </summary>
        Keypad3,

        /// <summary>
        ///   Specifies the Keypad 4 key.
        /// </summary>
        Keypad4,

        /// <summary>
        ///   Specifies the Keypad 5 key.
        /// </summary>
        Keypad5,

        /// <summary>
        ///   Specifies the Keypad 6 key.
        /// </summary>
        Keypad6,

        /// <summary>
        ///   Specifies the Keypad 7 key.
        /// </summary>
        Keypad7,

        /// <summary>
        ///   Specifies the Keypad 8 key.
        /// </summary>
        Keypad8,

        /// <summary>
        ///   Specifies the Keypad 9 key.
        /// </summary>
        Keypad9,

        /// <summary>
        ///   Specifies the keypad Divide key.
        /// </summary>
        KeypadDivide,

        /// <summary>
        ///   Specifies the keypad Multiply key.
        /// </summary>
        KeypadMultiply,

        /// <summary>
        ///   Specifies the keypad Subtract key.
        /// </summary>
        KeypadSubtract,

        /// <summary>
        ///   Specifies the keypad Add key.
        /// </summary>
        KeypadAdd,

        /// <summary>
        ///   Specifies the keypad period key.
        /// </summary>
        KeypadPeriod,

        /// <summary>
        ///   Specifies the keypad Enter key.
        /// </summary>
        KeypadEnter,

        /// <summary>
        ///   Specifies the A key.
        /// </summary>
        A,

        /// <summary>
        ///   Specifies the B key.
        /// </summary>
        B,

        /// <summary>
        ///   Specifies the C key.
        /// </summary>
        C,

        /// <summary>
        ///   Specifies the D key.
        /// </summary>
        D,

        /// <summary>
        ///   Specifies the E key.
        /// </summary>
        E,

        /// <summary>
        ///   Specifies the F key.
        /// </summary>
        F,

        /// <summary>
        ///   Specifies the G key.
        /// </summary>
        G,

        /// <summary>
        ///   Specifies the H key.
        /// </summary>
        H,

        /// <summary>
        ///   Specifies the I key.
        /// </summary>
        I,

        /// <summary>
        ///   Specifies the J key.
        /// </summary>
        J,

        /// <summary>
        ///   Specifies the K key.
        /// </summary>
        K,

        /// <summary>
        ///   Specifies the L key.
        /// </summary>
        L,

        /// <summary>
        ///   Specifies the M key.
        /// </summary>
        M,

        /// <summary>
        ///   Specifies the N key.
        /// </summary>
        N,

        /// <summary>
        ///   Specifies the O key.
        /// </summary>
        O,

        /// <summary>
        ///   Specifies the P key.
        /// </summary>
        P,

        /// <summary>
        ///   Specifies the Q key.
        /// </summary>
        Q,

        /// <summary>
        ///   Specifies the R key.
        /// </summary>
        R,

        /// <summary>
        ///   Specifies the S key.
        /// </summary>
        S,

        /// <summary>
        ///   Specifies the T key.
        /// </summary>
        T,

        /// <summary>
        ///   Specifies the U key.
        /// </summary>
        U,

        /// <summary>
        ///   Specifies the V key.
        /// </summary>
        V,

        /// <summary>
        ///   Specifies the W key.
        /// </summary>
        W,

        /// <summary>
        ///   Specifies the X key.
        /// </summary>
        X,

        /// <summary>
        ///   Specifies the Y key.
        /// </summary>
        Y,

        /// <summary>
        ///   Specifies the Z key.
        /// </summary>
        Z,

        /// <summary>
        ///   Specifies the Number 0 key.
        /// </summary>
        Number0,

        /// <summary>
        ///   Specifies the Number 1 key.
        /// </summary>
        Number1,

        /// <summary>
        ///   Specifies the Number 2 key.
        /// </summary>
        Number2,

        /// <summary>
        ///   Specifies the Number 3 key.
        /// </summary>
        Number3,

        /// <summary>
        ///   Specifies the Number 4 key.
        /// </summary>
        Number4,

        /// <summary>
        ///   Specifies the Number 5 key.
        /// </summary>
        Number5,

        /// <summary>
        ///   Specifies the Number 6 key.
        /// </summary>
        Number6,

        /// <summary>
        ///   Specifies the Number 7 key.
        /// </summary>
        Number7,

        /// <summary>
        ///   Specifies the Number 8 key.
        /// </summary>
        Number8,

        /// <summary>
        ///   Specifies the Number 9 key.
        /// </summary>
        Number9,

        /// <summary>
        ///   Specifies the Grave key.
        /// </summary>
        Grave,

        /// <summary>
        ///   Specifies the Subtract key.
        /// </summary>
        Subtract,

        /// <summary>
        ///   Specifies the Add key.
        /// </summary>
        Add,

        /// <summary>
        ///   Specifies the left Bracket key.
        /// </summary>
        BracketLeft,

        /// <summary>
        ///   Specifies the right Bracket key.
        /// </summary>
        BracketRight,

        /// <summary>
        ///   Specifies the Semicolon key.
        /// </summary>
        Semicolon,

        /// <summary>
        ///   Specifies the Quote key.
        /// </summary>
        Quote,

        /// <summary>
        ///   Specifies the Comma key.
        /// </summary>
        Comma,

        /// <summary>
        ///   Specifies the Period key.
        /// </summary>
        Period,

        /// <summary>
        ///   Specifies the Slash key.
        /// </summary>
        Slash,

        /// <summary>
        ///   Specifies the Back Slash key.
        /// </summary>
        BackSlash,

        /// <summary>
        ///   Specifies the Non-US Back Slash key.
        /// </summary>
        NonUSBackSlash,
    }
}