namespace FinalEngine.Platform.Desktop
{
    using System;
    using System.ComponentModel;
    using OpenTK;
    using FinalEngine.Drawing;
    using FESize = Drawing.Size;
    using FEPoint = Drawing.Point;
    using FERectangle = Drawing.Rectangle;
    using System.Diagnostics.CodeAnalysis;


    /// <summary>
    ///   Provides an OpenTK implementation of <see cref="IDisplay"/> and <see cref="IEventsProcessor"/>.
    /// </summary>
    /// <seealso cref="OpenTK.NativeWindow"/>
    /// <seealso cref="FinalEngine.Platform.IDisplay"/>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    [ExcludeFromCodeCoverage]
    public sealed class OpenTKDisplay : IDisplay, IEventsProcessor
    {
        #region Private Fields
        private readonly NativeWindow _nativeWindow;
        #endregion


        #region Constructors
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
        public OpenTKDisplay()
        {
            _nativeWindow = new NativeWindow();

            _nativeWindow.Closing += _nativeWindow_Closing;

            // TODO: Centering the window like this is just ugly, let's maybe abstract this into a IDisplay.Center() method?
            OpenTK.Rectangle workingArea = DisplayDevice.Default.Bounds;

            _nativeWindow.X = Math.Max(workingArea.X, workingArea.X + ((workingArea.Width - Width) / 2));
            _nativeWindow.Y = Math.Max(workingArea.Y, workingArea.Y + ((workingArea.Height - Height) / 2));
        }
        #endregion


        #region Props
        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The client rectangle of this <see cref="OpenTKDisplay"/>.
        /// </value>
        FERectangle IDisplay.ClientRectangle
        {
            get { return new FERectangle(ClientRectangle.X, ClientRectangle.Y, ClientSize.Width, ClientSize.Height); }
        }

        /// <summary>
        ///   Gets a <see cref="Size"/> that represents the internal size of this <see cref="OpenTKDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="OpenTKDisplay"/>.
        /// </value>
        FESize IDisplay.ClientSize
        {
            get { return new FESize(ClientSize.Width, ClientSize.Height); }
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
        FEPoint IDisplay.Location
        {
            get { return new FEPoint(Location.X, Location.Y); }
            set { Location = new FEPoint(value.X, value.Y); }
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
        FESize IDisplay.Size
        {
            get { return new FESize(Size.Width, Size.Height); }
            set { Size = new FESize(value.Width, value.Height); }
        }

        public FERectangle ClientRectangle { get; }

        public FESize ClientSize { get; }

        public bool Focused { get; }

        public FEPoint Location { get; set; }

        public FESize Size { get; set; }

        public string Title
        {
            get => _nativeWindow.Title;
            set => _nativeWindow.Title = value;
        }

        public bool Visible
        {
            get => _nativeWindow.Visible;
            set => _nativeWindow.Visible = value;
        }

        public int X
        {
            get => _nativeWindow.X;
            set => _nativeWindow.X = value;
        }

        public int Y
        {
            get => _nativeWindow.Y;
            set => _nativeWindow.Y = value;
        }

        public int Width
        {
            get => _nativeWindow.Width;
            set => _nativeWindow.Width = value;
        }

        public int Height
        {
            get => _nativeWindow.Height;
            set => _nativeWindow.Height = value;
        }
        #endregion


        #region Public Mehtods
        /// <summary>
        ///   Processes the events that are currently in the message queue.
        /// </summary>
        public void ProcessEvents()
        {
            //TODO: Add Code Here
        }


        public void Close()
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Private Methods
        /// <summary>
        ///   Called when the <see cref="OpenTK.NativeWindow"/> is about to close.
        /// </summary>
        /// <param name="e">
        ///   The <see cref="CancelEventArgs"/> for this event. Set e.Cancel to true in order to stop the NativeWindow from closing.
        /// </param>
        private void _nativeWindow_Closing(object sender, CancelEventArgs e)
        {
            IsClosing = !e.Cancel;
        }
        #endregion
    }
}