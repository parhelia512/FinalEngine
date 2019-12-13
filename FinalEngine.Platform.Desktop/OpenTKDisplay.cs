namespace FinalEngine.Platform.Desktop
{
    using System;
    using System.ComponentModel;
    using FinalEngine.Drawing;

    /// <summary>
    ///   Provides an OpenTK implementation of <see cref="IDisplay"/> and <see cref="IEventsProcessor"/>.
    /// </summary>
    /// <seealso cref="OpenTK.NativeWindow"/>
    /// <seealso cref="FinalEngine.Platform.IDisplay"/>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    public sealed class OpenTKDisplay : OpenTK.NativeWindow, IDisplay, IEventsProcessor
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenTKDisplay"/> class.
        /// </summary>
        /// <param name="width">
        ///   Specifies a <see cref="int"/> that represents the width (in pixels) of this <see cref="OpenTKDisplay"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="int"/> that represents the height (in pixels) of this <see cref="OpenTKDisplay"/>.
        /// </param>
        /// <param name="title">
        ///   Specifies a <see cref="string"/> that represents the title of this <see cref="OpenTKDisplay"/>
        /// </param>
        public OpenTKDisplay(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // TODO: Centering the window like this is just ugly, let's maybe abstract this into a IDisplay.Center() method?
            OpenTK.Rectangle workingArea = OpenTK.DisplayDevice.Default.Bounds;

            X = Math.Max(workingArea.X, workingArea.X + ((workingArea.Width - Width) / 2));
            Y = Math.Max(workingArea.Y, workingArea.Y + ((workingArea.Height - Height) / 2));
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The client rectangle of this <see cref="OpenTKDisplay"/>.
        /// </value>
        Rectangle IDisplay.ClientRectangle
        {
            get { return new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientSize.Width, ClientSize.Height); }
        }

        /// <summary>
        ///   Gets a <see cref="Size"/> that represents the internal size of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="OpenTKDisplay"/>.
        /// </value>
        Size IDisplay.ClientSize
        {
            get { return new Size(ClientSize.Width, ClientSize.Height); }
        }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="OpenTKDisplay"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="OpenTKDisplay"/> is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; private set; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location (in screen coordinates) of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="IDisplay"/>.
        /// </value>
        Point IDisplay.Location
        {
            get { return new Point(Location.X, Location.Y); }
            set { Location = new OpenTK.Point(value.X, value.Y); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="IDisplay"/>.
        /// </value>
        /// <remarks>
        ///   The size of an <see cref="IDisplay"/> can include anything that is outside the drawing area, including any title bars, status strips or anything of the like.
        /// </remarks>
        Size IDisplay.Size
        {
            get { return new Size(Size.Width, Size.Height); }
            set { Size = new OpenTK.Size(value.Width, value.Height); }
        }

        /// <summary>
        ///   Called when the <see cref="OpenTK.NativeWindow"/> is about to close.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="CancelEventArgs"/> for this event. Set e.Cancel to true in order to stop the NativeWindow from closing.
        /// </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            IsClosing = !e.Cancel;

            base.OnClosing(e);
        }
    }
}