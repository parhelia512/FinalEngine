// <copyright file="Program.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Launcher.Desktop
{
    using FinalEngine.Platform.Desktop;

    /// <summary>
    ///   Provides a program that runs on Desktop (Windows, Macintosh and Linux).
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///   Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var window = new OpenTKWindow(1024, 768, "Final Engine")
            {
                Visible = true,
            };

            while (!window.IsClosing)
            {
                window.ProcessEvents();
            }

            window.Dispose();
        }
    }
}