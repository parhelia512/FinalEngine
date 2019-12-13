namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Input.Devices;

    /// <summary>
    ///   Provides event data for the <see cref="IKeyboardDevice.KeyPressed"/> and <see cref="IKeyboardDevice.KeyReleased"/> events.
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public sealed class KeyEventArgs : EventArgs
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="key">
        ///   Specifies a <see cref="Key"/> that represents the key that raised the event.
        /// </param>
        /// <param name="capsLockState">
        ///   Specifies the state of the caps lock key at the time of raising the event.
        /// </param>
        /// <param name="numLockState">
        ///   Specifies the state of the number lock key at the time of raising the event.
        /// </param>
        /// <param name="scrollLockState">
        ///   Specifies the state of the scroll lock key at the time of raising the event.
        /// </param>
        /// <param name="keyModifiers">
        ///   Specifies a <see cref="KeyModifier"/> that represents the key modifiers that are present at the time of raising the event.
        /// </param>
        public KeyEventArgs(Key key, LockableKeyState capsLockState, LockableKeyState numLockState, LockableKeyState scrollLockState, KeyModifier keyModifiers)
        {
            Key = key;
            CapsLockState = capsLockState;
            NumLockState = numLockState;
            ScrollLockState = scrollLockState;
            KeyModifiers = keyModifiers;
        }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the caps lock key.
        /// </summary>
        /// <value>
        ///   The state of the caps-lock key.
        /// </value>
        public LockableKeyState CapsLockState { get; }

        /// <summary>
        ///   Gets a <see cref="Key"/> that represents the key that raised the event.
        /// </summary>
        /// <value>
        ///   The key that raised the event.
        /// </value>
        public Key Key { get; }

        /// <summary>
        ///   Gets a <see cref="KeyModifier"/> that represents the key modifiers that were present at the time of raising the event.
        /// </summary>
        /// <value>
        ///   The key modifiers that were present at the time of raising the event.
        /// </value>
        public KeyModifier KeyModifiers { get; }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the number lock key.
        /// </summary>
        /// <value>
        ///   The state of the number lock key.
        /// </value>
        public LockableKeyState NumLockState { get; }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the scroll lock key.
        /// </summary>
        /// <value>
        ///   The state of the scroll lock key.
        /// </value>
        public LockableKeyState ScrollLockState { get; }
    }
}