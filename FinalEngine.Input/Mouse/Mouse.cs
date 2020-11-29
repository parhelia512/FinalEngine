// <copyright file="Mouse.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Mouse
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Mouse : IMouse
    {
        private readonly IList<MouseButton> buttonsDown;

        private readonly IMouseDevice? device;

        private IList<MouseButton> buttonsDownLast;

        private PointF location;

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

        public double WheelOffset { get; private set; }

        public bool IsButtonDown(MouseButton button)
        {
            return this.buttonsDown.Contains(button);
        }

        public bool IsButtonPressed(MouseButton button)
        {
            return this.buttonsDown.Contains(button) && !this.buttonsDownLast.Contains(button);
        }

        public bool IsButtonReleased(MouseButton button)
        {
            return !this.buttonsDown.Contains(button) && this.buttonsDownLast.Contains(button);
        }

        public void Update()
        {
            this.buttonsDownLast = new List<MouseButton>(this.buttonsDown);
        }

        private void Device_ButtonDown(object? sender, MouseButtonEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.buttonsDown.Add(e.Button);
        }

        private void Device_ButtonUp(object? sender, MouseButtonEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            while (this.buttonsDown.Contains(e.Button))
            {
                this.buttonsDown.Remove(e.Button);
            }
        }

        private void Device_Move(object? sender, MouseMoveEventArgs e)
        {
            this.location = e.Location;
        }

        private void Device_Scroll(object? sender, MouseScrollEventArgs e)
        {
            this.WheelOffset = e.Offset;
        }
    }
}