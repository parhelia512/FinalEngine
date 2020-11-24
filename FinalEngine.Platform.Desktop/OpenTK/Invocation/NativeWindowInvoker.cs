// <copyright file="NativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using System;
    using global::OpenTK.Windowing.Desktop;

    /// <summary>
    ///     Provides an implementation of an <see cref="INativeWindowInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.Desktop.OpenTK.Invocation.INativeWindowInvoker"/>
    public sealed class NativeWindowInvoker : INativeWindowInvoker
    {
        /// <summary>
        ///     The native window.
        /// </summary>
        private readonly NativeWindow nativeWindow;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeWindowInvoker"/> class.
        /// </summary>
        /// <param name="nativeWindow">
        ///     Specifies a <see cref="NativeWindow"/> that represents the native window whose
        ///     methods will be invoked.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="nativeWindow"/> parameter is null.
        /// </exception>
        public NativeWindowInvoker(NativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow));
        }

        /// <inheritdoc/>
        public bool IsDisposed { get; private set; }

        /// <inheritdoc/>
        public bool IsExiting
        {
            get { return this.nativeWindow.IsExiting; }
        }

        /// <inheritdoc/>
        public bool IsVisible
        {
            get { return this.nativeWindow.IsVisible; }
            set { this.nativeWindow.IsVisible = value; }
        }

        /// <inheritdoc/>
        public string Title
        {
            get { return this.nativeWindow.Title; }
            set { this.nativeWindow.Title = value; }
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.nativeWindow.Close();
            this.IsDisposed = true;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.nativeWindow.Dispose();
            this.IsDisposed = true;
        }

        /// <inheritdoc/>
        public void ProcessEvents()
        {
            this.nativeWindow.ProcessEvents();
        }
    }
}