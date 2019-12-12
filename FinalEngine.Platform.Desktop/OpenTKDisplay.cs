namespace FinalEngine.Platform.Desktop
{
    using System;
    using System.ComponentModel;
    using FinalEngine.Drawing;

    /// <summary>
    ///   Provides an <see cref="OpenTK.NativeWindow"/> implementation of an <see cref="IDisplay"/> and <see cref="IEventsProcessor"/>.
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
        ///   Specifies the width (in pixels) of this <see cref="OpenTKDisplay"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies the height (in pixels) of this <see cref="OpenTKDisplay"/>.
        /// </param>
        /// <param name="title">
        ///   Specifies the title of this <see cref="OpenTKDisplay"/>.
        /// </param>
        public OpenTKDisplay(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // TODO: this probably shouldn't be in the constructor?
            OpenTK.Rectangle workingArea = OpenTK.DisplayDevice.Default.Bounds;

            X = Math.Max(workingArea.X, workingArea.X + ((workingArea.Width - Width) / 2));
            Y = Math.Max(workingArea.Y, workingArea.Y + ((workingArea.Height - Height) / 2));
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="OpenTKDisplay"/>.
        /// </value>
        Rectangle IDisplay.ClientRectangle
        {
            get { return ClientRectangle.ToRectangle(); }
        }

        /// <summary>
        ///   Gets a <see cref="Size"/> that represents the internal size of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="OpenTKDisplay"/>.
        /// </value>
        Size IDisplay.ClientSize
        {
            get { return ClientSize.ToSize(); }
        }

        /// <summary>
        ///   Gets a <see cref="T:System.Boolean"/> indicating whether this <see cref="OpenTKDisplay"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="OpenTK"/> is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; private set; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> structure that contains the location of this window on the desktop.
        /// </summary>
        Point IDisplay.Location
        {
            get { return Location.ToPoint(); }
            set { Location = value.ToTKPoint(); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> structure that contains the external size of this window.
        /// </summary>
        Size IDisplay.Size
        {
            get { return Size.ToSize(); }
            set { Size = value.ToTKSize(); }
        }

        /// <summary>
        ///   Called when the <see cref="OpenTKDisplay"/> is about to close.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="T:System.ComponentModel.CancelEventArgs"/> for this event. Set e.Cancel to true in order to stop the <see cref="OpenTKDisplay"/> from closing.
        /// </param>
        protected override void OnClosing(CancelEventArgs e)
        {
            IsClosing = !e.Cancel;

            base.OnClosing(e);
        }
    }
}