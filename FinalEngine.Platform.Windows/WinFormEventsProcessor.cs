namespace FinalEngine.Platform.Windows
{
    using System.Windows.Forms;

    public sealed class WinFormEventsProcessor : IEventsProcessor
    {
        public void ProcessEvents()
        {
            // TODO: Look into processing events similar to how SharpDX did it, but for now this is good.
            Application.DoEvents();
        }
    }
}