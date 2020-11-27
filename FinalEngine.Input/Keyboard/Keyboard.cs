// <copyright file="Keyboard.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public class Keyboard : IKeyboard
    {
        private readonly IKeyboardDevice? device;

        private readonly IList<Key> keysDown;

        private IReadOnlyCollection<Key> keysDownLast;

        internal Keyboard(IKeyboardDevice? device)
        {
            this.device = device;

            this.keysDown = new List<Key>();
            this.keysDownLast = new List<Key>();

            if (this.device != null)
            {
                this.device.KeyDown += this.Device_KeyDown;
                this.device.KeyUp += this.Device_KeyUp;
            }
        }

        [ExcludeFromCodeCoverage(Justification = "Empty Constructor")]
        private Keyboard()
        {
        }

        public bool IsKeyDown(Key key)
        {
            return this.keysDown.Contains(key);
        }

        public bool IsKeyPressed(Key key)
        {
            return this.keysDown.Contains(key); // && !this.keysDownLast.Contains(key);
        }

        public bool IsKeyReleased(Key key)
        {
            return !this.keysDown.Contains(key) && this.keysDownLast.Contains(key);
        }

        internal void Update()
        {
            this.keysDownLast = new List<Key>(this.keysDown);
        }

        private void Device_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            this.keysDown.Add(e.Key);
        }

        private void Device_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            while (this.keysDown.Contains(e.Key))
            {
                this.keysDown.Remove(e.Key);
            }
        }
    }
}