// <copyright file="Keyboard.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Keyboard : IKeyboard
    {
        private readonly IKeyboardDevice? device;

        private readonly IList<Key>? keysDown;

        private IReadOnlyCollection<Key>? keysDownLast;

        private Keyboard(IKeyboardDevice? device)
        {
            if (device == null)
            {
                return;
            }

            this.device = device;

            this.keysDown = new List<Key>();
            this.keysDownLast = new List<Key>();

            this.device.KeyDown += this.Device_KeyDown;
            this.device.KeyUp += this.Device_KeyUp;
        }

        public bool IsKeyDown(Key key)
        {
            if (this.keysDown == null)
            {
                return false;
            }

            return this.keysDown.Contains(key);
        }

        public bool IsKeyPressed(Key key)
        {
            if (this.keysDown == null ||
                this.keysDownLast == null)
            {
                return false;
            }

            return this.keysDown.Contains(key) && !this.keysDownLast.Contains(key);
        }

        public bool IsKeyReleased(Key key)
        {
            if (this.keysDown == null ||
                this.keysDownLast == null)
            {
                return false;
            }

            return !this.keysDown.Contains(key) && this.keysDownLast.Contains(key);
        }

        internal static Keyboard Create(IKeyboardDevice? device)
        {
            return new Keyboard(device);
        }

        internal void Update()
        {
            if (this.keysDown == null)
            {
                return;
            }

            this.keysDownLast = new List<Key>(this.keysDown);
        }

        private void Device_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.keysDown == null)
            {
                throw new NullReferenceException($"The {nameof(this.keysDown)} field is null. Did you accidently invoke this method?");
            }

            this.keysDown.Add(e.Key);
        }

        private void Device_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (this.keysDown == null)
            {
                throw new NullReferenceException($"The {nameof(this.keysDown)} field is null. Did you accidently invoke this method?");
            }

            while (this.keysDown.Contains(e.Key))
            {
                this.keysDown.Remove(e.Key);
            }
        }
    }
}