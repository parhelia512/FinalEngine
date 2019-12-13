namespace FinalEngine.Platform.Windows
{
    using System.Windows.Forms;
    using FinalEngine.Drawing;

    public sealed class WinFormDisplay : Form, IDisplay
    {
        public WinFormDisplay(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // TODO: Handle form resizing and context recreation.
            StartPosition = FormStartPosition.CenterScreen;
        }

        Rectangle IDisplay.ClientRectangle
        {
            get { return ClientRectangle.ToFinalEngineDrawingRectangle(); }
        }

        Size IDisplay.ClientSize
        {
            get { return ClientSize.ToFinalEngineDrawingSize(); }
        }

        public bool IsClosing { get; private set; }

        Point IDisplay.Location
        {
            get { return Location.ToFinalEngineDrawingPoint(); }
            set { Location = value.ToSystemDrawingPoint(); }
        }

        Size IDisplay.Size
        {
            get { return Size.ToFinalEngineDrawingSize(); }
            set { Size = value.ToSystemDrawingSize(); }
        }

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // TODO: Handle reasons for closing here.
            IsClosing = !e.Cancel;

            base.OnFormClosing(e);
        }
    }
}