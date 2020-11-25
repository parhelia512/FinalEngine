// <copyright file="INativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using global::OpenTK.Windowing.Desktop;

    /// <summary>
    /// Defines an interface that provides methods for invocation of a <see cref="NativeWindow"/>.
    /// </summary>
    public interface INativeWindowInvoker
    {
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        bool IsDisposed { get; }

        /// <summary>
        /// Gets a value indicating whether the shutdown sequence has been initiated for this
        /// window, either by calling <see cref="Close"/> or hitting the 'close' button. If this
        /// property is <c>true</c>, it is no longer safe to use any OpenTK.Input or
        /// OpenTK.Graphics.OpenGL functions or properties.
        /// </summary>
        /// <value>
        /// <c>true</c> if this window is exiting; otherwise, <c>false</c>.
        /// </value>
        bool IsExiting { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this window is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this window is visible; otherwise, <c>false</c>.
        /// </value>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the title of this window.
        /// </summary>
        /// <value>
        /// The title of this window.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Closes this window.
        /// </summary>
        void Close();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Processes pending window events.
        /// </summary>
        void ProcessEvents();
    }
}