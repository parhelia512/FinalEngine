// <copyright file="WinFormsWindow.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Windows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using FinalEngine.Drawing;
    using FinalEngine.Platform;

    [ExcludeFromCodeCoverage]
    public sealed class WinFormsWindow : Form, IWindow
    {
        public WinFormsWindow(int width, int height, string title)
        {
            this.Width = width;
            this.Height = height;
            this.Title = title;

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        Rectangle IWindow.ClientRectangle
        {
            get
            {
                return new Rectangle(
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                    new Size(this.ClientRectangle.Width, this.ClientRectangle.Height));
            }
        }

        Size IWindow.ClientSize
        {
            get
            {
                return new Size(this.ClientSize.Width, this.ClientSize.Height);
            }
        }

        Point IWindow.Location
        {
            get { return new Point(this.Location.X, this.Location.Y); }
            set { this.Location = new System.Drawing.Point(value.X, value.Y); }
        }

        Size IWindow.Size
        {
            get { return new Size(this.Size.Width, this.Size.Height); }
            set { this.Size = new System.Drawing.Size(value.Width, value.Height); }
        }

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}