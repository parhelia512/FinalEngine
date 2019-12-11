namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var formatter = new StandardLogFormatter();
            var logger = new TextWriterLogHandler(formatter, Console.Out);

            logger.Log(LogType.Information, "Test logging");
            logger.Log(LogType.Debug, "Test debugging");
            logger.Log(LogType.Error, "Test error");
            logger.Log(LogType.Warning, "Test warning");
        }
    }
}