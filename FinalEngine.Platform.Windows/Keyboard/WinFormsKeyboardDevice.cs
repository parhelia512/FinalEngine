// <copyright file="WinFormsKeyboardDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Windows.Keyboard
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using FinalEngine.Input.Keyboard;
    using FEKeyEventArgs = FinalEngine.Input.Keyboard.KeyEventArgs;
    using WFKeyEventArgs = System.Windows.Forms.KeyEventArgs;

    [ExcludeFromCodeCoverage]
    public sealed class WinFormsKeyboardDevice : IKeyboardDevice
    {
        public WinFormsKeyboardDevice(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.KeyUp += this.Control_KeyUp;
            control.KeyDown += this.Control_KeyDown;
        }

        public event EventHandler<FEKeyEventArgs> KeyPressed;

        public event EventHandler<FEKeyEventArgs> KeyReleased;

        private void Control_KeyDown(object sender, WFKeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_KeyUp(object sender, WFKeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}