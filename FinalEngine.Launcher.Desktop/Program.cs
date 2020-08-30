// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
    using FinalEngine.Platform.Windows;

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
            Logger.Instance.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));
            Logger.Instance.Log(LogType.Information, "Starting engine...");

            var window = new WinFormsWindow(1024, 768, "Game Engine")
            {
                Visible = true,
            };

            var eventsProcessor = new WinFormsEventProcessor(window);

            Logger.Instance.Log(LogType.Information, "Starting game loop...");

            while (eventsProcessor.CanProcessEvents)
            {
                eventsProcessor.ProcessEvents();
            }

            window.Close();
        }
    }
}