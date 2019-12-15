namespace FinalEngine.Launcher.Desktop
{
    using System;
    using FinalEngine.Platform.Desktop;
    using FinalEngine.Platform.Desktop.Devices;

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
                Visible = true
            };

            var keyboardDevice = new OpenTKKeyboardDevice(window);

            keyboardDevice.KeyReleased += (s, e) =>
            {
                Console.WriteLine($"SHIFT: { e.ShiftModifier }");
                Console.WriteLine($"CNTRL: { e.ControlModifier }");
                Console.WriteLine($"ALT { e.AltModifier }");
            };

            while (!window.IsClosing)
            {
                window.ProcessEvents();
            }

            window.Dispose();
        }
    }
}