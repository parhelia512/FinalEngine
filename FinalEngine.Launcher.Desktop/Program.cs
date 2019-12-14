namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
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
            ILogger logger = Logger.Instance;
            logger.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));

            logger.Log(LogType.Information, "Final Engine is starting...");

            var window = new OpenTKWindow(1024, 768, "Final Engine");

            logger.Log(LogType.Information, "Attempting to move window to second monitor...");

            // TODO: We can only assume that the users default monitor IS their first monitor...
            if (!window.TryChangeCurrentScreen(2))
            {
                logger.Log(LogType.Warning, "Failed to move window to second monitor, perhaps the user doesn't have a second monitor?");
            }

            logger.Log(LogType.Information, "Starting game loop...");

            window.Visible = true;

            while (!window.IsClosing)
            {
                window.ProcessEvents();
            }

            logger.Log(LogType.Information, "Disposing of resources...");

            window.Dispose();
        }
    }
}