// <copyright file="Keyboard.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;
    using System.Collections.Generic;

    public static class Keyboard
    {
        private static IList<Key>? keysDown;

        private static IList<Key>? keysDownLast;

        public static bool IsKeyDown(Key key)
        {
            if (keysDown == null)
            {
                return false;
            }

            return keysDown.Contains(key);
        }

        public static bool IsKeyPressed(Key key)
        {
            if (keysDown == null)
            {
                return false;
            }

            if (keysDownLast == null)
            {
                throw new NullReferenceException($"The {nameof(keysDownLast)} field is null. Did you forget to call {nameof(Initialize)} or {nameof(Update)}?");
            }

            return keysDown.Contains(key) && !keysDownLast.Contains(key);
        }

        public static bool IsKeyReleased(Key key)
        {
            if (keysDown == null)
            {
                return false;
            }

            if (keysDownLast == null)
            {
                throw new NullReferenceException($"The {nameof(keysDownLast)} field is null. Did you forget to call {nameof(Initialize)} or {nameof(Update)}?");
            }

            return !keysDown.Contains(key) && keysDownLast.Contains(key);
        }

        internal static void Initialize(IKeyboardDevice? device)
        {
            if (device == null)
            {
                return;
            }

            keysDown = new List<Key>();
            keysDownLast = new List<Key>();

            device.KeyUp += Device_KeyUp;
            device.KeyDown += Device_KeyDown;
        }

        internal static void Update()
        {
            if (keysDown == null)
            {
                throw new NullReferenceException($"The {nameof(keysDown)} field is null. Did you forget to call {nameof(Initialize)}?");
            }

            keysDownLast = new List<Key>(keysDown);
        }

        private static void Device_KeyDown(object? sender, KeyEventArgs e)
        {
            if (keysDown == null)
            {
                throw new NullReferenceException($"The {nameof(keysDown)} field is null. Did you forget to call {nameof(Initialize)}?");
            }

            keysDown.Add(e.Key);
        }

        private static void Device_KeyUp(object? sender, KeyEventArgs e)
        {
            if (keysDown == null)
            {
                throw new NullReferenceException($"The {nameof(keysDown)} field is null. Did you forget to call {nameof(Initialize)}?");
            }

            while (keysDown.Contains(e.Key))
            {
                keysDown.Remove(e.Key);
            }
        }
    }
}