namespace FinalEngine.Platform
{
    using System;
    using FinalEngine.Drawing;

    /// <summary>
    ///   Defines an interface that represents a display or window.
    /// </summary>
    /// <seealso cref="System.IDisposable"/>
    public interface IWindow : IDisposable
    {
        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal bounds (in pixels) of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal bounds of this <see cref="IWindow"/>.
        /// </value>
        Rectangle ClientRectangle { get; }

        /// <summary>
        ///   Gets a <see cref="Rectangle"/> that represents the internal size (in pixels) of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The internal size of this <see cref="IWindow"/>.
        /// </value>
        Size ClientSize { get; }

        Screen CurrentScreen { get; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="IWindow"/> is focused.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IWindow"/> is focused; otherwise, <c>false</c>.
        /// </value>
        bool Focused { get; }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="IWindow"/> is closing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IWindow"/> is closing; otherwise, <c>false</c>.
        /// </value>
        bool IsClosing { get; }

        /// <summary>
        ///   Gets or sets a <see cref="Point"/> that represents the location (in screen coordinates) of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The location of this <see cref="IWindow"/>.
        /// </value>
        Point Location { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="Size"/> that represents the size of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The size of this <see cref="IWindow"/>.
        /// </value>
        /// <remarks>
        ///   The size of an <see cref="IWindow"/> can include anything that is outside the drawing area of it's overall contents.
        /// </remarks>
        Size Size { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="string"/> that represents the title of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The title of this <see cref="IWindow"/>.
        /// </value>
        string Title { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether this <see cref="IWindow"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this <see cref="IWindow"/> is visible; otherwise, <c>false</c>.
        /// </value>
        bool Visible { get; set; }

        /// <summary>
        ///   Closes this <see cref="IWindow"/>.
        /// </summary>
        void Close();

        bool TryChangeCurrentScreen(uint index);
    }
}