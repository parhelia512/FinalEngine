namespace FinalEngine.Platform
{
    using System;
    using System.Drawing;

    public interface IDisplay : IDisposable
    {
        Rectangle ClientRectangle { get; }

        Size ClientSize { get; }

        bool Focused { get; }

        bool IsClosing { get; }

        Point Location { get; set; }

        Size Size { get; set; }

        string Title { get; set; }

        bool Visible { get; set; }

        void Close();
    }
}