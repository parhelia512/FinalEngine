// <copyright file="KeyEventArgs.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Input.Keyboard
{
    using System;

    //// TODO: Unit Test TONIGHT

    public sealed class KeyEventArgs : EventArgs
    {
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

        public bool IsAltDown { get; }

        public bool IsCapsLocked { get; }

        public bool IsControlDown { get; }

        public bool IsNumLocked { get; }

        public bool IsScrollLocked { get; }

        public bool IsShiftDown { get; }

        public Key Key { get; }
    }
}