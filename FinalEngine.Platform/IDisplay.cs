namespace FinalEngine.Platform
{
    using System;
    using System.Drawing;

    /// <summary>
    ///   Defines an interface that represents a display or window.
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public interface IDisplay : IDisposable
    {
        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="IDisplay"/>.
        /// </value>
        Rectangle ClientRectangle { get; }

        /// <summary>
        ///   Gets a <see cref="Size"/> that represents the internal size of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="IDisplay"/>.
        /// </value>
        Size ClientSize { get; }

        /// <summary>
        ///   Gets a <see cref="bool"/> indicating whether this <see cref="IDisplay"/> is focused.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IDisplay"/> is focused; otherwise, <c>false</c>.
        /// </value>
        bool Focused { get; }

        /// <summary>
        ///   Gets a <see cref="bool"/> indicating whether this <see cref="IDisplay"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IDisplay"/> is closing; otherwise, <c>false</c>.
        /// </value>
        bool IsClosing { get; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="IDisplay"/>.
        /// </value>
        Point Location { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="IDisplay"/>.
        /// </value>
        Size Size { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="string"/> that represents the title of this <see cref="IDisplay"/>.
        /// </summary>
        /// <value>
        ///   The title of this <see cref="IDisplay"/>.
        /// </value>
        string Title { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="bool"/> indicating whether this <see cref="IDisplay"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IDisplay"/> is visible; otherwise, <c>false</c>.
        /// </value>
        bool Visible { get; set; }

        /// <summary>
        ///   Closes this <see cref="IDisplay"/>.
        /// </summary>
        void Close();
    }
}