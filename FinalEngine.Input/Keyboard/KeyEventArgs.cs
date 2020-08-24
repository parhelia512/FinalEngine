// <copyright file="KeyEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;

    //// TODO: Unit Test TONIGHT

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
        ///   Specifies a <see cref="Key"/> that represents the key that raised this event.
        /// </param>
        /// <param name="isAltDown">
        ///   Specifies a value that indicates whether the ALT key is down.
        /// </param>
        /// <param name="isShiftDown">
        ///   Specifies a value that indicates whether the shift key is down.
        /// </param>
        /// <param name="isControlDown">
        ///   Specifies a value that indicates whether the control key is down.
        /// </param>
        /// <param name="isCapsLocked">
        ///   Specifies a value that indicates whether the CAPS key is locked.
        /// </param>
        /// <param name="isNumLocked">
        ///   Specifies a value that indicates whether the NUM key is locked.
        /// </param>
        /// <param name="isScrollLocked">
        ///   Specifies a value that indicates whether the SCROLL key is locked.
        /// </param>
        public KeyEventArgs(
            Key key,
            bool isAltDown,
            bool isShiftDown,
            bool isControlDown,
            bool isCapsLocked,
            bool isNumLocked,
            bool isScrollLocked)
        {
            this.Key = key;
            this.IsAltDown = isAltDown;
            this.IsShiftDown = isShiftDown;
            this.IsControlDown = isControlDown;
            this.IsCapsLocked = isCapsLocked;
            this.IsNumLocked = isNumLocked;
            this.IsScrollLocked = isScrollLocked;
        }

        /// <summary>
        ///   Gets a value indicating whether the ALT key is down.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the ALT key is down; otherwise, <c>false</c>.
        /// </value>
        public bool IsAltDown { get; }

        /// <summary>
        ///   Gets a value indicating whether the CAPS key is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the CAPS key is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsCapsLocked { get; }

        /// <summary>
        ///   Gets a value indicating whether the control key is down.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the control key is down; otherwise, <c>false</c>.
        /// </value>
        public bool IsControlDown { get; }

        /// <summary>
        ///   Gets a value indicating whether the NUM key is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the NUM key is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsNumLocked { get; }

        /// <summary>
        ///   Gets a value indicating whether the SCROLL key is locked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the SCROLL key is locked; otherwise, <c>false</c>.
        /// </value>
        public bool IsScrollLocked { get; }

        /// <summary>
        ///   Gets a value indicating whether the shift key is down.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the shift key is down; otherwise, <c>false</c>.
        /// </value>
        public bool IsShiftDown { get; }

        /// <summary>
        ///   Gets the key that raised this event.
        /// </summary>
        /// <value>
        ///   The key that raised this event.
        /// </value>
        public Key Key { get; }
    }
}