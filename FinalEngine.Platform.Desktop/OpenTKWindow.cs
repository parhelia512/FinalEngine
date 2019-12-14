namespace FinalEngine.Platform.Desktop
{
    using System.ComponentModel;
    using OpenTK;
    using Point = Drawing.Point;
    using Rectangle = Drawing.Rectangle;
    using Size = Drawing.Size;

    public sealed class OpenTKWindow : NativeWindow, IWindow, IEventsProcessor
    {
        public OpenTKWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // Set CurrentScreen to primrary.
            TryChangeCurrentScreen(0);
        }

        Rectangle IWindow.ClientRectangle
        {
            get
            {
                return new Rectangle(new Point(ClientRectangle.X, ClientRectangle.Y),
                                     new Size(ClientSize.Width, ClientSize.Height));
            }
        }

        Size IWindow.ClientSize
        {
            get { return new Size(ClientSize.Width, ClientSize.Height); }
        }

        public Screen CurrentScreen { get; private set; }

        public bool IsClosing { get; private set; }

        Point IWindow.Location
        {
            get { return new Point(Location.X, Location.Y); }
            set { Location = new OpenTK.Point(value.X, value.Y); }
        }

        Size IWindow.Size
        {
            get { return new Size(Size.Width, Size.Height); }
            set { Size = new OpenTK.Size(value.Width, value.Height); }
        }

        public bool TryChangeCurrentScreen(uint index)
        {
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            IsClosing = !e.Cancel;

            base.OnClosing(e);
        }
    }
}