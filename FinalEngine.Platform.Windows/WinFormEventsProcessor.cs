namespace FinalEngine.Platform.Windows
{
    using System.Windows.Forms;

    /// <summary>
    ///   Provides an implementation of an <see cref="IEventsProcessor"/> that processes events on the Windows operating system.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    public sealed class WinFormEventsProcessor : IEventsProcessor
    {
        /// <summary>
        ///   Processes all Windows events that are currently in the message queue.
        /// </summary>
        public void ProcessEvents()
        {
            // TODO: Look into processing events similar to how SharpDX did it, but for now this is good.
            Application.DoEvents();
        }
    }
}