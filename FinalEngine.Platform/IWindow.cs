// <copyright file="IWindow.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    /// <summary>
    ///     Defines an interface that represents a display or window.
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        ///     Gets a value indicating whether this <see cref="IWindow"/> is exiting.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="IWindow"/> is exiting; otherwise, <c>false</c>.
        /// </value>
        bool IsExiting { get; }

        /// <summary>
        ///     Gets or sets the title of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        ///     The title of this <see cref="IWindow"/>.
        /// </value>
        string Title { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="IWindow"/> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this <see cref="IWindow"/> is visible; otherwise, <c>false</c>.
        /// </value>
        bool Visible { get; set; }
    }
}