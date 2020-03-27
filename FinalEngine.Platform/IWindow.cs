// <copyright file="IWindow.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    using System;
    using FinalEngine.Drawing;

    /// <summary>
    ///   Defines an interface that represents a display or window.
    /// </summary>
    /// <seealso cref="IDisposable"/>
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

        /// <summary>
        ///   Gets a <see cref="Screen"/> that represents the current screen of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///   The current screen of this <see cref="IWindow"/>.
        /// </value>
        /// <remarks>
        ///   If you want to change the screen that an <see cref="IWindow"/> is on, see <see cref="TryChangeCurrentScreen(uint)"/>.
        /// </remarks>
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

        /// <summary>
        ///   Tries to change the <see cref="CurrentScreen"/> to the screen represented by the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">
        ///   Specifies a <see cref="uint"/> that represents the indexical-location of the <see cref="Screen"/>.
        /// </param>
        /// <remarks>
        ///   On all platforms, you should be able to set the specified <paramref name="index"/> parameter to 0 to access the primary <see cref="Screen"/> on the underlying platform.
        /// </remarks>
        /// <returns>
        ///   <c>true</c> if the <see cref="CurrentScreen"/> changed to the a screen located at the specific <paramref name="index"/>; otherwise, <c>false</c>.
        /// </returns>
        bool TryChangeCurrentScreen(uint index);
    }
}