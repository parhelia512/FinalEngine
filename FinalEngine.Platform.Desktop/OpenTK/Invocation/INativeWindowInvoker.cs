// <copyright file="INativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using System;

    public interface INativeWindowInvoker : IDisposable
    {
        bool IsDisposed { get; }

        bool IsExiting { get; }

        bool IsVisible { get; set; }

        string Title { get; set; }

        void Close();

        void ProcessEvents();
    }
}