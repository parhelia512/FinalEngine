namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
    using FinalEngine.Platform.Desktop;

    internal static class Program
    {
        private static void Main()
        {
            ILogger logger = Logger.Instance;

            // Log to the console, maybe we should make a ConsoleLogHandler, that'll color code the console?
            logger.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));
            logger.Log(LogType.Information, "Final Engine is starting...");

            var display = new OpenTKDisplay(1024, 768, "Final Engine")
            {
                Visible = true
            };

            logger.Log(LogType.Information, "Entering game loop...");

            while (!display.IsClosing)
            {
                display.ProcessEvents();
            }

            logger.Log(LogType.Information, "Disposing of resources...");

            display.Dispose();
        }
    }
}