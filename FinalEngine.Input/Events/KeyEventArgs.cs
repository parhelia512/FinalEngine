// <copyright file="KeyEventArgs.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Events
{
    using System;
    using FinalEngine.Input.Devices;

    /// <summary>
    ///   Provides event data for the <see cref="IKeyboardDevice.KeyPressed"/> and <see cref="IKeyboardDevice.KeyReleased"/> events.
    /// </summary>
    /// <seealso cref="EventArgs"/>
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
        /// <param name="shiftModifier">
        ///   Specifies the state of the shift modifier key (was it present at the time of raising the event).
        /// </param>
        /// <param name="altModifier">
        ///   Specifies the state of the ALT modifier key (was it present at the time of raising the event).
        /// </param>
        /// <param name="controlModifier">
        ///   Specifies the state of the control modifier key (was it present at the time of raising the event).
        /// </param>
        public KeyEventArgs(Key key, LockableKeyState capsLockState, LockableKeyState numLockState, LockableKeyState scrollLockState, bool shiftModifier, bool altModifier, bool controlModifier)
        {
            this.Key = key;
            this.CapsLockState = capsLockState;
            this.NumLockState = numLockState;
            this.ScrollLockState = scrollLockState;
            this.ShiftModifier = shiftModifier;
            this.AltModifier = altModifier;
            this.ControlModifier = controlModifier;
        }

        /// <summary>
        ///   Gets a value indicating whether the ALT key modifier was down during the time the event was raised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the ALT key modifier was down during the time the event was raised; otherwise, <c>false</c>.
        /// </value>
        public bool AltModifier { get; }

        /// <summary>
        ///   Gets a <see cref="LockableKeyState"/> that represents the state of the caps lock key.
        /// </summary>
        /// <value>
        ///   The state of the caps-lock key.
        /// </value>
        public LockableKeyState CapsLockState { get; }

        /// <summary>
        ///   Gets a value indicating whether the control key modifier was down during the time the event was raised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control key modifier was down during the time the event was raised; otherwise, <c>false</c>.
        /// </value>
        public bool ControlModifier { get; }

        /// <summary>
        ///   Gets a <see cref="Key"/> that represents the key that raised the event.
        /// </summary>
        /// <value>
        ///   The key that raised the event.
        /// </value>
        public Key Key { get; }

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

        /// <summary>
        ///   Gets a value indicating whether the shift key modifier was down during the time the event was raised.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the shift key modifier was down during the time the event was raised; otherwise, <c>false</c>.
        /// </value>
        public bool ShiftModifier { get; }
    }
}