namespace FinalEngine.Launcher.Desktop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FinalEngine.Platform.Desktop;
    using FinalEngine.Platform.Desktop.Devices;

    /// <summary>
    ///   Provides a program that runs on Desktop (Windows, Macintosh and Linux).
    /// </summary>
    internal static class Program
    {
        public static IEnumerable<Enum> GetFlags(this Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag);
        }

        /// <summary>
        ///   Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var window = new OpenTKWindow(1024, 768, "Final Engine")
            {
                Visible = true
            };

            var keyboardDevice = new OpenTKKeyboardDevice(window);

            keyboardDevice.KeyPressed += (s, e) =>
            {
            };

            while (!window.IsClosing)
            {
                window.ProcessEvents();
            }

            window.Dispose();
        }
    }
}