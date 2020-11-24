// <copyright file="OpenTKWindow.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK
{
    using global::OpenTK.Windowing.Desktop;

    /// <summary>
    ///     Provides an OpenTK implementation of an <see cref="IWindow"/> and <see cref="IEventsProcessor"/>.
    /// </summary>
    /// <seealso cref="OpenTK.Windowing.Desktop.NativeWindow"/>
    /// <seealso cref="FinalEngine.Platform.IWindow"/>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    public class OpenTKWindow : NativeWindow, IWindow, IEventsProcessor
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenTKWindow"/> class.
        /// </summary>
        /// <param name="settings">
        ///     Specifies a <see cref="NativeWindowSettings"/> that represents the <see
        ///     cref="NativeWindow"/> related settings.
        /// </param>
        public OpenTKWindow(NativeWindowSettings settings)
            : base(settings)
        {
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the underlying <see cref="NativeWindow"/> is visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the underlying <see cref="NativeWindow"/> is visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible
        {
            get { return this.IsVisible; }
            set { this.IsVisible = value; }
        }
    }
}