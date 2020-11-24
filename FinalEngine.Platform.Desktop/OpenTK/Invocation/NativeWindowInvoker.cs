// <copyright file="NativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using System;
    using global::OpenTK.Windowing.Desktop;

    public class NativeWindowInvoker : INativeWindowInvoker
    {
        private readonly NativeWindow nativeWindow;

        public NativeWindowInvoker(NativeWindow nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow));
        }

        public bool IsDisposed { get; private set; }

        public bool IsExiting
        {
            get { return this.nativeWindow.IsExiting; }
        }

        public bool IsVisible
        {
            get { return this.nativeWindow.IsVisible; }
            set { this.nativeWindow.IsVisible = value; }
        }

        public string Title
        {
            get { return this.nativeWindow.Title; }
            set { this.nativeWindow.Title = value; }
        }

        public void Close()
        {
            this.nativeWindow.Close();
            this.IsDisposed = true;
        }

        public void Dispose()
        {
            this.nativeWindow.Dispose();
            this.IsDisposed = true;
        }

        public void ProcessEvents()
        {
            this.nativeWindow.ProcessEvents();
        }
    }
}