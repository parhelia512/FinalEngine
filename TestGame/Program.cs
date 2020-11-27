// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using FinalEngine.Input.Keyboard;
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

            var keyboard = Keyboard.Create(keyboardDevice);

            while (!window.IsExiting)
            {
                if (keyboard.IsKeyDown(Key.A))
                {
                    Console.WriteLine("A is down");
                }

                if (keyboard.IsKeyPressed(Key.B))
                {
                    Console.WriteLine("A is pressed");
                }

                if (keyboard.IsKeyReleased(Key.A))
                {
                    Console.WriteLine("A is released");
                }

                keyboard.Update();
                window.ProcessEvents();
            }

            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}