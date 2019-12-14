namespace FinalEngine.Platform.Desktop
{
    using System.ComponentModel;
    using OpenTK;
    using Point = Drawing.Point;
    using Rectangle = Drawing.Rectangle;
    using Size = Drawing.Size;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IWindow"/> and <see cref="IEventsProcessor"/>.
    /// </summary>
    /// <seealso cref="OpenTK.NativeWindow"/>
    /// <seealso cref="FinalEngine.Platform.IWindow"/>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    public sealed class OpenTKWindow : NativeWindow, IWindow, IEventsProcessor
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenTKWindow"/> class.
        /// </summary>
        /// <param name="width">
        ///   Specifies a <see cref="Int32"/> that represents the width (in pixels) of this <see cref="OpenTKWindow"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="Int32"/> that represents the height (in pixels) of this <see cref="OpenTKWindow"/>.
        /// </param>
        /// <param name="title">
        ///   Specifies a <see cref="String"/> that represents the title of this <see cref="OpenTKWindow"/>.
        /// </param>
        public OpenTKWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // Set CurrentScreen to primrary.
            TryChangeCurrentScreen(0);

            // Center the window to the current screen.
            X = (CurrentScreen.Size.Width - Width) / 2;
            Y = (CurrentScreen.Size.Height - Height) / 2;
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds (in pixels) of this <see cref="OpenTKWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="OpenTKWindow"/>.
        /// </value>
        Rectangle IWindow.ClientRectangle
        {
            get
            {
                return new Rectangle(new Point(ClientRectangle.X, ClientRectangle.Y),
                                     new Size(ClientSize.Width, ClientSize.Height));
            }
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal size (in pixels) of this <see cref="OpenTKWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="OpenTKWindow"/>.
        /// </value>
        Size IWindow.ClientSize
        {
            get { return new Size(ClientSize.Width, ClientSize.Height); }
        }

        /// <summary>
        ///   Gets a <see cref="Screen"/> that represents the current screen of this <see cref="OpenTKWindow"/>.
        /// </summary>
        /// <value>
        ///   The current screen of this <see cref="OpenTKWindow"/>.
        /// </value>
        /// <remarks>
        ///   If you want to change the screen that an <see cref="OpenTK"/> is on, see <see cref="OpenTKScreenManager.TryGetScreenByIndex(uint, out Screen)"/>.
        /// </remarks>
        public Screen CurrentScreen { get; private set; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="OpenTKWindow"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="OpenTKWindow"/> is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; private set; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location (in screen coordinates) of this <see cref="OpenTKWindow"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="OpenTKWindow"/>.
        /// </value>
        Point IWindow.Location
        {
            get { return new Point(Location.X, Location.Y); }
            set { Location = new OpenTK.Point(value.X, value.Y); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="OpenTKWindow"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="OpenTKWindow"/>.
        /// </value>
        /// <remarks>
        ///   The size of an <see cref="OpenTKWindow"/> can include anything that is outside the drawing area, including (but not limited too) any title bars and status strips.
        /// </remarks>
        Size IWindow.Size
        {
            get { return new Size(Size.Width, Size.Height); }
            set { Size = new OpenTK.Size(value.Width, value.Height); }
        }

        /// <summary>
        ///   Tries to change the <see cref="CurrentScreen"/> to the screen represented by the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">
        ///   Specifies a <see cref="uint"/> that represents the indexical-location of the <see cref="Screen"/>.
        /// </param>
        /// <returns>
        ///   <c>true</c> if the <see cref="CurrentScreen"/> changed to the a screen located at the specific <paramref name="index"/>; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        ///   On all platforms, you should be able to set the specified <paramref name="index"/> parameter to 0 to access the primary <see cref="Screen"/> on the underlying platform.
        /// </remarks>
        public bool TryChangeCurrentScreen(uint index)
        {
            if (OpenTKScreenManager.Instance.TryGetScreenByIndex(index, out Screen screen))
            {
                CurrentScreen = screen;
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Called when the <see cref="OpenTKWindow"/> is about to close.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="CancelEventArgs"/> for this event. Set e.Cancel to true in order to stop the <see cref="NativeWindow"/> from closing.
        /// </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            IsClosing = !e.Cancel;

            base.OnClosing(e);
        }
    }
}