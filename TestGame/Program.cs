// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using OpenTK.Mathematics;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;

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
                if (keyboard.IsKeyDown(Key.A))
                {
                    Console.WriteLine("A is down");
                }

                if (keyboard.IsKeyPressed(Key.B))
                {
                    Console.WriteLine("B is pressed");
                }

                if (keyboard.IsKeyReleased(Key.A))
                {
                    Console.WriteLine("A is released");
                }

                if (mouse.IsButtonDown(MouseButton.Left))
                {
                    Console.WriteLine("Left is down");
                }

                if (mouse.IsButtonPressed(MouseButton.Right))
                {
                    Console.WriteLine("Right is pressed.");
                }

                if (mouse.IsButtonReleased(MouseButton.Right))
                {
                    Console.WriteLine("Right is released.");

                    Console.WriteLine(mouse.Location);
                    Console.WriteLine(mouse.WheelOffset);
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