// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.IO;
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

            var fileSystem = new FileSystem();

            while (!window.IsExiting)
            {
                keyboard.Update();
                mouse.Update();

                window.ProcessEvents();
            }

            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}