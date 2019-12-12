namespace FinalEngine.Sandbox.Desktop
{
    using FinalEngine.Platform.Desktop;

    /// <summary>
    ///   The main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///   Defines the entry point of the application.
        /// </summary>
        /// <param name="args">
        ///   Specifies the args.
        /// </param>
        private static void Main(string[] args)
        {
            const int WindowWidth = 1024;
            const int WindowHeight = 768;
            const string WindowTItle = "Final Engine on Desktop";

            var display = new OpenTKDisplay(WindowWidth, WindowHeight, WindowTItle)
            {
                Visible = true
            };

            while (!display.IsClosing)
            {
                display.ProcessEvents();
            }

            display.Dispose();
        }
    }
}