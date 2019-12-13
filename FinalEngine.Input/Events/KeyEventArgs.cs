namespace FinalEngine.Input.Events
{
    using System;

    public sealed class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(Key key, LockableKeyState capsLockState, LockableKeyState numLockState, LockableKeyState scrollLockState, KeyModifier keyModifiers)
        {
            Key = key;
            CapsLockState = capsLockState;
            NumLockState = numLockState;
            ScrollLockState = scrollLockState;
            KeyModifiers = keyModifiers;
        }

        public LockableKeyState CapsLockState { get; }

        public Key Key { get; }

        public KeyModifier KeyModifiers { get; }

        public LockableKeyState NumLockState { get; }

        public LockableKeyState ScrollLockState { get; }
    }
}