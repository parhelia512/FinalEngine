namespace FinalEngine.Launcher.Desktop
{
    using System;
    using System.Runtime.InteropServices;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
    using FinalEngine.Platform.Windows;

    internal static class Program
    {
        private static void Main()
        {
            Logger.Instance.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));

            Logger.Instance.Log(LogType.Information, "Final Engine is starting...");
            Logger.Instance.Log(LogType.Information, "OS: " + RuntimeInformation.OSDescription);
            Logger.Instance.Log(LogType.Information, "NET Version: " + RuntimeInformation.FrameworkDescription);

            Logger.Instance.Log(LogType.Information, "Creating display...");

            var display = new WinFormDisplay(1024, 768, "Final Engine")
            {
                Visible = true
            };

            var eventsProcessor = new WinFormEventsProcessor();

            Logger.Instance.Log(LogType.Information, "Entering main loop...");

            while (!display.IsClosing)
            {
                eventsProcessor.ProcessEvents();
            }

            display.Dispose();
        }
    }
}