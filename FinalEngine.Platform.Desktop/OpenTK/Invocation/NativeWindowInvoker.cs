// <copyright file="NativeWindowInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using global::OpenTK.Windowing.Desktop;

    /// <summary>
    ///     Provides an implementation of an <see cref="INativeWindowInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.Desktop.OpenTK.Invocation.INativeWindowInvoker"/>
    [ExcludeFromCodeCoverage(Justification = "Invocation Class")]
    public sealed class NativeWindowInvoker : NativeWindow, INativeWindowInvoker
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NativeWindowInvoker"/> class.
        /// </summary>
        /// <param name="settings">
        ///     Specifies a <see cref="NativeWindowSettings"/> that represents the <see
        ///     cref="NativeWindow"/> related settings.
        /// </param>
        public NativeWindowInvoker(NativeWindowSettings settings)
            : base(settings)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        ///     only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.IsDisposed = true;
        }
    }
}