namespace FinalEngine.Platform.Windows
{
    using System.Windows.Forms;
    using FinalEngine.Drawing;

    /// <summary>
    ///   Provides an implementation of the <see cref="IDisplay"/> interface that runs on Windows.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form"/>
    /// <seealso cref="FinalEngine.Platform.IDisplay"/>
    public sealed class WinFormDisplay : Form, IDisplay
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="WinFormDisplay"/> class.
        /// </summary>
        /// <param name="width">
        ///   Specifies the width (in pixels) of this <see cref="WinFormDisplay"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies the height (in pixels of this <see cref="WinFormDisplay"/>.
        /// </param>
        /// <param name="title">
        ///   Specifies the title of this <see cref="WinFormDisplay"/>.
        /// </param>
        public WinFormDisplay(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;

            // TODO: Handle form resizing and context recreation.
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds of this <see cref="WinFormDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="WinFormDisplay"/>.
        /// </value>
        Rectangle IDisplay.ClientRectangle
        {
            get { return ClientRectangle.ToFinalEngineDrawingRectangle(); }
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal size of this <see cref="WinFormDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="WinFormDisplay"/>.
        /// </value>
        Size IDisplay.ClientSize
        {
            get { return ClientSize.ToFinalEngineDrawingSize(); }
        }

        /// <summary>
        ///   Gets a <see cref="T:System.Boolean"/> indicating whether this <see cref="WinFormDisplay"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="WinFormDisplay"/> is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; private set; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the upper-left corner of the <see cref="WinFormDisplay"/> in screen coordinates.
        /// </summary>
        /// <value>
        ///   The upper-left corner of the <see cref="WinFormDisplay"/> in screen coordinates.
        /// </value>
        Point IDisplay.Location
        {
            get { return Location.ToFinalEngineDrawingPoint(); }
            set { Location = value.ToSystemDrawingPoint(); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="WinFormDisplay"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="WinFormDisplay"/>.
        /// </value>
        Size IDisplay.Size
        {
            get { return Size.ToFinalEngineDrawingSize(); }
            set { Size = value.ToSystemDrawingSize(); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="string"/> that represents the title of this <see cref="WinFormDisplay"/>.
        /// </summary>
        /// <value>
        ///   The title of this <see cref="WinFormDisplay"/>.
        /// </value>
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        /// <summary>
        ///   Raises the <see cref="Form.FormClosing"/> event.
        /// </summary>
        /// <param name="e">
        ///   A <see cref="FormClosedEventArgs"/> that contains the event data.
        /// </param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // TODO: Handle reasons for closing here.
            IsClosing = !e.Cancel;

            base.OnFormClosing(e);
        }
    }
}