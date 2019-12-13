namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Logging;
    using FinalEngine.Logging.Formatters;
    using FinalEngine.Logging.Handlers;
    using FinalEngine.Platform;
    using FinalEngine.Platform.Desktop;
    using SimpleInjector;

    internal static class Program
    {
        private static Container _container;

        private static void Main()
        {
            InitIoC();

            ILogger logger = Logger.Instance;

            // Log to the console, maybe we should make a ConsoleLogHandler, that'll color code the console?
            logger.Handlers.Add(new TextWriterLogHandler(new StandardLogFormatter(), Console.Out));
            logger.Log(LogType.Information, "Final Engine is starting...");

            Game game = _container.GetInstance<Game>();

            game.Run();

            logger.Log(LogType.Information, "Entering game loop...");


            logger.Log(LogType.Information, "Disposing of resources...");

            game.Dispose();
        }


        private static void InitIoC()
        {
            _container = new Container();

            _container.Register<IDisplay, OpenTKDisplay>();

            _container.Register<Game>(() =>
            {
                return new Game(_container.GetInstance<IDisplay>(), 1024, 768, "Final Engine");
            }, Lifestyle.Singleton);
        }
    }
}