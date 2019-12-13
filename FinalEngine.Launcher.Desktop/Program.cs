namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;

    /// <summary>
    ///   The main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///   Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            Logger.Instance.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));

            Logger.Instance.Log(LogType.Information, "Final Engine is starting...");
        }
    }
}