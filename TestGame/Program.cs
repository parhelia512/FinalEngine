// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using System.Drawing;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using OpenTK.Mathematics;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;

    //// TODO: Unit tests should all have constant variables where required.

    /// <summary>
    ///     The main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var settings = new NativeWindowSettings()
            {
                WindowBorder = WindowBorder.Fixed,
                WindowState = WindowState.Normal,

                Size = new Vector2i(1024, 768),

                StartVisible = true,
            };

            var nativeWindow = new NativeWindowInvoker(settings);
            var window = new OpenTKWindow(nativeWindow);

            var keyboardDevice = new OpenTKKeyboardDevice(nativeWindow);
            var mouseDevice = new OpenTKMouseDevice(nativeWindow);

            var keyboard = new Keyboard(keyboardDevice);
            var mouse = new Mouse(mouseDevice);

            while (!window.IsExiting)
            {
                if (mouse.IsButtonDown(MouseButton.Left))
                {
                    Console.WriteLine("Left button is down");
                }

                if (mouse.IsButtonPressed(MouseButton.Middle))
                {
                    Console.WriteLine("Middle button is pressed");

                    Console.WriteLine(mouse.WheelOffset);
                }

                if (mouse.IsButtonReleased(MouseButton.Middle))
                {
                    Console.WriteLine("Middle button is released.");

                    mouse.Location = new PointF(200, 200);
                }

                keyboard.Update();
                mouse.Update();

                window.ProcessEvents();
            }

            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}