// <copyright file="NativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using global::OpenTK.Windowing.Desktop;

    /// <summary>
    /// Provides an implementation of an <see cref="INativeWindowInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.Desktop.OpenTK.Invocation.INativeWindowInvoker"/>
    [ExcludeFromCodeCoverage]
    public sealed class NativeWindowInvoker : INativeWindowInvoker
    {
        /// <summary>
        /// The native window.
        /// </summary>
        private readonly NativeWindow nativeWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeWindowInvoker"/> class.
        /// </summary>
        /// <param name="nativeWindow">
        /// Specifies a <see cref="NativeWindow"/> that represents the native window whose methods
        /// will be invoked.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// The specified <paramref name="nativeWindow"/> parameter is null.
        /// </exception>
        public NativeWindowInvoker(NativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow), $"The specified {nameof(nativeWindow)} parameter cannot be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeWindowInvoker"/> class.
        /// </summary>
        /// <param name="settings">
        /// Specifies a <see cref="NativeWindowSettings"/> that represents the settings used to create a <see cref="NativeWindow"/>, internally.
        /// </param>
        public NativeWindowInvoker(NativeWindowSettings settings)
            : this(new NativeWindow(settings))
        {
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the shutdown sequence has been initiated for this
        /// window, either by calling <see cref="Close"/> or hitting the 'close' button. If this
        /// property is <c>true</c>, it is no longer safe to use any OpenTK.Input or
        /// OpenTK.Graphics.OpenGL functions or properties.
        /// </summary>
        /// <value>
        /// <c>true</c> if this window is exiting; otherwise, <c>false</c>.
        /// </value>
        public bool IsExiting
        {
            get { return this.nativeWindow.IsExiting; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this window is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this window is visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible
        {
            get { return this.nativeWindow.IsVisible; }
            set { this.nativeWindow.IsVisible = value; }
        }

        /// <summary>
        /// Gets or sets the title of this window.
        /// </summary>
        /// <value>
        /// The title of this window.
        /// </value>
        public string Title
        {
            get { return this.nativeWindow.Title; }
            set { this.nativeWindow.Title = value; }
        }

        /// <summary>
        /// Closes this window.
        /// </summary>
        public void Close()
        {
            this.nativeWindow.Close();
            this.IsDisposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.nativeWindow.Dispose();
            this.IsDisposed = true;
        }

        /// <summary>
        /// Processes pending window events.
        /// </summary>
        public void ProcessEvents()
        {
            this.nativeWindow.ProcessEvents();
        }
    }
}