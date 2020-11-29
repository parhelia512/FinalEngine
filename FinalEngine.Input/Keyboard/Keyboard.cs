// <copyright file="Keyboard.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Provides a standard implementation of an <see cref="IKeyboard"/>, that interfaces with
    ///     an <see cref="IKeyboardDevice"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Input.Keyboard.IKeyboard"/>
    public class Keyboard : IKeyboard
    {
        /// <summary>
        ///     The initial size capacity of the <see cref="keysDown"/> and <see
        ///     cref="keysDownLast"/> collections.
        /// </summary>
        private const int InitialSizeCapacity = 20;

        /// <summary>
        ///     The physical keyboard device.
        /// </summary>
        private readonly IKeyboardDevice? device;

        /// <summary>
        ///     The keys down during the current frame.
        /// </summary>
        private readonly IList<Key> keysDown;

        /// <summary>
        ///     The keys down during the previous frame.
        /// </summary>
        private IList<Key> keysDownLast;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Keyboard"/> class.
        /// </summary>
        /// <param name="device">
        ///     Specifies a <see cref="IKeyboardDevice"/> that represents the keyboard device to
        ///     listen to.
        /// </param>
        /// <remarks>
        ///     The <paramref name="device"/> parameter is nullable, when set to null the events are
        ///     not hooked and therefore the object will not listen out for keyboard events. This
        ///     can be useful in situtations where the end-user might not have a keyboard or require
        ///     a keyboard on the underlying platform (for example, a mobile device).
        /// </remarks>
        public Keyboard(IKeyboardDevice? device)
        {
            this.device = device;

            this.keysDown = new List<Key>(InitialSizeCapacity);
            this.keysDownLast = new List<Key>(InitialSizeCapacity);

            if (this.device != null)
            {
                this.device.KeyDown += this.Device_KeyDown;
                this.device.KeyUp += this.Device_KeyUp;
            }
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="Keyboard"/> class.
        /// </summary>
        ~Keyboard()
        {
            if (this.device != null)
            {
                this.device.KeyDown -= this.Device_KeyDown;
                this.device.KeyUp -= this.Device_KeyUp;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Key.LeftAlt"/> or <see
        ///     cref="Key.RightAlt"/> is down during the current frame.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the <see cref="Key.LeftAlt"/> or <see cref="Key.RightAlt"/> is down
        ///     during the current frame; otherwise, <c>false</c>.
        /// </value>
        public bool IsAltDown
        {
            get { return this.keysDown.Contains(Key.LeftAlt) || this.keysDown.Contains(Key.RightAlt); }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Key.CapsLock"/> is currently locked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the <see cref="Key.CapsLock"/> is currently locked; otherwise,
        ///     <c>false</c>.
        /// </value>
        public bool IsCapsLocked { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Key.LeftControl"/> or <see
        ///     cref="Key.RightControl"/> is down during the current frame.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the <see cref="Key.LeftControl"/> or <see cref="Key.RightControl"/>
        ///     is down during the current frame; otherwise, <c>false</c>.
        /// </value>
        public bool IsControlDown
        {
            get { return this.keysDown.Contains(Key.LeftControl) || this.keysDown.Contains(Key.RightControl); }
        }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Key.NumLock"/> is currently locked.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the <see cref="Key.NumLock"/> is currently locked; otherwise,
        ///     <c>false</c>.
        /// </value>
        public bool IsNumLocked { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the <see cref="Key.LeftShift"/> or <see
        ///     cref="Key.RightShift"/> is down during the current frame.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the <see cref="Key.LeftShift"/> or <see cref="Key.RightShift"/> is
        ///     down during the current frame; otherwise, <c>false</c>.
        /// </value>
        public bool IsShiftDown
        {
            get { return this.keysDown.Contains(Key.LeftShift) || this.keysDown.Contains(Key.RightShift); }
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="key"/> is down during the current
        ///     frame.
        /// </summary>
        /// <param name="key">
        ///     Specifies a <see cref="Key"/> that represents the key to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="key"/> is down during the current
        ///     frame; otherwise, <c>false</c>.
        /// </returns>
        public bool IsKeyDown(Key key)
        {
            return this.keysDown.Contains(key);
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="key"/> has been pressed this frame.
        /// </summary>
        /// <param name="key">
        ///     Specifies a <see cref="Key"/> that represents the key to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="key"/> has been pressed this frame;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public bool IsKeyPressed(Key key)
        {
            return this.keysDown.Contains(key) && !this.keysDownLast.Contains(key);
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="key"/> has been released since the
        ///     previous frame.
        /// </summary>
        /// <param name="key">
        ///     Specifies a <see cref="Key"/> that represents the key to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="key"/> has been released since the
        ///     previous frame; otherwise, <c>false</c>.
        /// </returns>
        public bool IsKeyReleased(Key key)
        {
            return !this.keysDown.Contains(key) && this.keysDownLast.Contains(key);
        }

        /// <summary>
        ///     Updates this <see cref="Keyboard"/>.
        /// </summary>
        /// <remarks>
        ///     This method should only be called after the user has checked for input state
        ///     changes.
        /// </remarks>
        public void Update()
        {
            this.keysDownLast = new List<Key>(this.keysDown);
        }

        /// <summary> Handles the <see cref="IKeyboardDevice.KeyDown"/> event. </summary> <param
        /// name="sender"> The sender. </param> <param name="e"> The <see cref="KeyEventArgs"/>
        /// instance containing the event data. </param> <exception cref="ArgumentNullException">
        /// The specified <paramref name="e"/> parameter is null. </exception> </exception>
        private void Device_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null");
            }

            this.IsCapsLocked = e.CapsLock;
            this.IsNumLocked = e.NumLock;

            this.keysDown.Add(e.Key);
        }

        /// <summary>
        ///     Handles the <see cref="IKeyboardDevice.KeyUp"/> event.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The <see cref="KeyEventArgs"/> instance containing the event data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="e"/> parameter is null.
        /// </exception>
        private void Device_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null.");
            }

            while (this.keysDown.Contains(e.Key))
            {
                this.keysDown.Remove(e.Key);
            }
        }
    }
}