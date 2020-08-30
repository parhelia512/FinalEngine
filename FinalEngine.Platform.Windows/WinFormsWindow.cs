// <copyright file="WinFormsWindow.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Windows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using FinalEngine.Drawing;
    using FinalEngine.Platform;

    /// <summary>
    ///   Provides an implementation of <see cref="IWindow"/> for Windows Forms.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form"/>
    /// <seealso cref="FinalEngine.Platform.IWindow"/>
    [ExcludeFromCodeCoverage]
    public sealed class WinFormsWindow : Form, IWindow
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="WinFormsWindow"/> class.
        /// </summary>
        /// <param name="width">
        ///   Specifies a <see cref="int"/> that represents the width (in pixels) of this <see cref="WinFormsWindow"/>.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="int"/> that represents the height (in pixels) of this <see cref="WinFormsWindow"/>.
        /// </param>
        /// <param name="title">
        ///   Specifies a <see cref="string"/> that represents the title of this <see cref="WinFormsWindow"/>.
        /// </param>
        public WinFormsWindow(int width, int height, string title)
        {
            this.Width = width;
            this.Height = height;
            this.Title = title;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds (in pixels) of this <see cref="WinFormsWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="WinFormsWindow"/>.
        /// </value>
        Rectangle IWindow.ClientRectangle
        {
            get
            {
                return new Rectangle(
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                    new Size(this.ClientRectangle.Width, this.ClientRectangle.Height));
            }
        }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal size (in pixels) of this <see cref="WinFormsWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="WinFormsWindow"/>.
        /// </value>
        Size IWindow.ClientSize
        {
            get
            {
                return new Size(this.ClientSize.Width, this.ClientSize.Height);
            }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location (in screen coordinates) of this <see cref="WinFormsWindow"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="WinFormsWindow"/>.
        /// </value>
        Point IWindow.Location
        {
            get { return new Point(this.Location.X, this.Location.Y); }
            set { this.Location = new System.Drawing.Point(value.X, value.Y); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="WinFormsWindow"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="WinFormsWindow"/>.
        /// </value>
        /// <remarks>
        ///   The size of an <see cref="WinFormsWindow"/> can include anything that is outside the drawing area of it's overall contents.
        /// </remarks>
        Size IWindow.Size
        {
            get { return new Size(this.Size.Width, this.Size.Height); }
            set { this.Size = new System.Drawing.Size(value.Width, value.Height); }
        }

        /// <summary>
        ///   Gets or sets a <see cref="string"/> that represents the title of this <see cref="WinFormsWindow"/>.
        /// </summary>
        /// <value>
        ///   The title of this <see cref="WinFormsWindow"/>.
        /// </value>
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}