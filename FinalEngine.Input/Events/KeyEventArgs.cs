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
        ///   Specifies the key that raised this event.
        /// </param>
        /// <param name="capsLockState">
        ///   Specifies the state of the caps-lock key.
        /// </param>
        /// <param name="numLockState">
        ///   Specifies the state of the num-lock key.
        /// </param>
        /// <param name="scrollLockState">
        ///   Specifies the state of the scroll-lock key.
        /// </param>
        /// <param name="keyModifiers">
        ///   Specifies any key modifiers that were when raising this event.
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
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the caps-lock key for this <see cref="KeyEventArgs"/>.
        /// </summary>
        /// <value>
        ///   The state of the caps-lock key for this <see cref="KeyEventArgs"/>.
        /// </value>
        public LockableKeyState CapsLockState { get; }

        /// <summary>
        ///   Gets a <see cref="Key"/> that represents the key that raised this event.
        /// </summary>
        /// <value>
        ///   The key that raised this event.
        /// </value>
        public Key Key { get; }

        /// <summary>
        ///   Gets a <see cref="KeyModifier"/> that represents the modifiers that were present during the creation of this <see cref="KeyEventArgs"/>.
        /// </summary>
        /// <value>
        ///   The modifiers that were present during the creation of this <see cref="KeyEventArgs"/>.
        /// </value>
        public KeyModifier KeyModifiers { get; }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the num-lock key for this <see cref="KeyEventArgs"/>.
        /// </summary>
        /// <value>
        ///   The state of the num-lock key for this <see cref="KeyEventArgs"/>.
        /// </value>
        public LockableKeyState NumLockState { get; }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the scroll-lock key for this <see cref="KeyEventArgs"/>.
        /// </summary>
        /// <value>
        ///   The state of the scroll-lock key for this <see cref="KeyEventArgs"/>.
        /// </value>
        public LockableKeyState ScrollLockState { get; }
    }
}