// <copyright file="Mouse.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    ///     Provides a standard implementation of an <see cref="IMouse"/>, that interfaces with an
    ///     <see cref="IMouseDevice"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Input.Mouse.IMouse"/>
    public class Mouse : IMouse
    {
        /// <summary>
        ///     The buttons down during the current frame.
        /// </summary>
        private readonly IList<MouseButton> buttonsDown;

        /// <summary>
        ///     The physical mouse device.
        /// </summary>
        private readonly IMouseDevice? device;

        /// <summary>
        ///     The buttons down during the previous frame.
        /// </summary>
        private IList<MouseButton> buttonsDownLast;

        /// <summary>
        ///     The cursor location as of the last time <see cref="IMouseDevice.Move"/> was raised.
        /// </summary>
        private PointF location;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Mouse"/> class.
        /// </summary>
        /// <param name="device">
        ///     Specifies a <see cref="IMouseDevice"/> that represents the mouse device to listen
        ///     to.
        /// </param>
        public Mouse(IMouseDevice? device)
        {
            this.device = device;

            this.buttonsDown = new List<MouseButton>();
            this.buttonsDownLast = new List<MouseButton>();

            if (this.device != null)
            {
                this.device.ButtonDown += this.Device_ButtonDown;
                this.device.ButtonUp += this.Device_ButtonUp;
                this.device.Move += this.Device_Move;
                this.device.Scroll += this.Device_Scroll;
            }
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="Mouse"/> class.
        /// </summary>
        ~Mouse()
        {
            if (this.device != null)
            {
                this.device.ButtonDown -= this.Device_ButtonDown;
                this.device.ButtonUp -= this.Device_ButtonUp;
                this.device.Move -= this.Device_Move;
                this.device.Scroll -= this.Device_Scroll;
            }
        }

        /// <summary>
        ///     Gets or sets the location of the cursor in window pixel coordinates.
        /// </summary>
        /// <value>
        ///     The location of the cursor in window pixel coordinates.
        /// </value>
        public PointF Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (this.device != null)
                {
                    if (this.Location.Equals(value))
                    {
                        return;
                    }

                    this.device.SetCursorLocation(value);
                }
            }
        }

        /// <summary>
        ///     Gets the scroll wheel offset.
        /// </summary>
        /// <value>
        ///     The scroll wheel offset.
        /// </value>
        public double WheelOffset { get; private set; }

        /// <summary>
        ///     Determines whether the specified <paramref name="button"/> is currently down.
        /// </summary>
        /// <param name="button">
        ///     Specifies a <see cref="MouseButton"/> that represents the button to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="button"/> is currently down; otherwise,
        ///     <c>false</c>.
        /// </returns>
        public bool IsButtonDown(MouseButton button)
        {
            return this.buttonsDown.Contains(button);
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="button"/> has been pressed this
        ///     frame.
        /// </summary>
        /// <param name="button">
        ///     Specifies a <see cref="MouseButton"/> that represents the button to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="button"/> has been pressed this frame;
        ///     otherwise, <c>false</c>.
        /// </returns>
        public bool IsButtonPressed(MouseButton button)
        {
            return this.buttonsDown.Contains(button) && !this.buttonsDownLast.Contains(button);
        }

        /// <summary>
        ///     Determines whether the specified <paramref name="button"/> has been released since
        ///     the previous frame.
        /// </summary>
        /// <param name="button">
        ///     Specifies a <see cref="MouseButton"/> that represents the button to check for.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the specified <paramref name="button"/> has been released since the
        ///     previous frame; otherwise, <c>false</c>.
        /// </returns>
        public bool IsButtonReleased(MouseButton button)
        {
            return !this.buttonsDown.Contains(button) && this.buttonsDownLast.Contains(button);
        }

        /// <summary>
        ///     Updates this <see cref="Mouse"/>.
        /// </summary>
        /// <remarks>
        ///     This method should only be called after the user has checked for input state
        ///     changes.
        /// </remarks>
        public void Update()
        {
            this.buttonsDownLast = new List<MouseButton>(this.buttonsDown);
        }

        /// <summary>
        ///     Handles the <see cref="IMouseDevice.ButtonDown"/> event.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The <see cref="MouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="e"/> parameter is null.
        /// </exception>
        private void Device_ButtonDown(object? sender, MouseButtonEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null");
            }

            this.buttonsDown.Add(e.Button);
        }

        /// <summary>
        ///     Handles the <see cref="IMouseDevice.ButtonUp"/> event.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The <see cref="MouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="e"/> parameter is null.
        /// </exception>
        private void Device_ButtonUp(object? sender, MouseButtonEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null");
            }

            while (this.buttonsDown.Contains(e.Button))
            {
                this.buttonsDown.Remove(e.Button);
            }
        }

        /// <summary>
        ///     Handles the <see cref="IMouseDevice.Move"/> event.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The <see cref="MouseMoveEventArgs"/> instance containing the event data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="e"/> parameter is null.
        /// </exception>
        private void Device_Move(object? sender, MouseMoveEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null");
            }

            this.location = e.Location;
        }

        /// <summary>
        ///     Handles the <see cref="IMouseDevice.Scroll"/> event.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The <see cref="MouseScrollEventArgs"/> instance containing the event data.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The specified <paramref name="e"/> parameter is null.
        /// </exception>
        private void Device_Scroll(object? sender, MouseScrollEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), $"The specified {nameof(e)} parameter cannot be null");
            }

            this.WheelOffset = e.Offset;
        }
    }
}