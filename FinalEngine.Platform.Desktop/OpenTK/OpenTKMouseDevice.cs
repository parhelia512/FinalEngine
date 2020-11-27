// <copyright file="OpenTKMouseDevice.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Desktop.OpenTK
{
    using System;
    using System.Drawing;
    using FinalEngine.Input.Mouse;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using TKMouseButtonEventArgs = global::OpenTK.Windowing.Common.MouseButtonEventArgs;
    using TKMouseMoveEventArgs = global::OpenTK.Windowing.Common.MouseMoveEventArgs;
    using TKMouseWheelEventArgs = global::OpenTK.Windowing.Common.MouseWheelEventArgs;

    /// <summary>
    /// Provides an OpenTK implementation of an <see cref="IMouseDevice"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Input.Mouse.IMouseDevice" />
    public class OpenTKMouseDevice : IMouseDevice
    {
        /// <summary>
        /// The native window.
        /// </summary>
        private readonly INativeWindowInvoker nativeWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenTKMouseDevice"/> class.
        /// </summary>
        /// <param name="nativeWindow">
        /// Specifies a <see cref="INativeWindowInvoker"/> that represents the underlying native window used to hook onto mouse events.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The specified <paramref name="nativeWindow"/> parameter is null.
        /// </exception>
        public OpenTKMouseDevice(INativeWindowInvoker nativeWindow)
        {
            this.nativeWindow = nativeWindow ?? throw new ArgumentNullException(nameof(nativeWindow));

            this.nativeWindow.MouseUp += this.NativeWindow_MouseUp;
            this.nativeWindow.MouseDown += this.NativeWindow_MouseDown;
            this.nativeWindow.MouseMove += this.NativeWindow_MouseMove;
            this.nativeWindow.MouseWheel += this.NativeWindow_MouseWheel;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OpenTKMouseDevice"/> class.
        /// </summary>
        ~OpenTKMouseDevice()
        {
            this.nativeWindow.MouseUp -= this.NativeWindow_MouseUp;
            this.nativeWindow.MouseDown -= this.NativeWindow_MouseDown;
            this.nativeWindow.MouseMove -= this.NativeWindow_MouseMove;
            this.nativeWindow.MouseWheel -= this.NativeWindow_MouseWheel;
        }

        /// <summary>
        /// Occurs when a mouse button is pressed.
        /// </summary>
        public event EventHandler<MouseButtonEventArgs>? ButtonDown;

        /// <summary>
        /// Occurs when a mouse button is released.
        /// </summary>
        public event EventHandler<MouseButtonEventArgs>? ButtonUp;

        /// <summary>
        /// Occurs when the location of the mouse has changed.
        /// </summary>
        public event EventHandler<MouseMoveEventArgs>? Move;

        /// <summary>
        /// Occurs when the position of the scroll wheel has changed.
        /// </summary>
        public event EventHandler<MouseScrollEventArgs>? Scroll;

        /// <summary>
        /// Handles the <see cref="INativeWindowInvoker.MouseDown"/> event.
        /// </summary>
        /// <param name="args">
        /// The <see cref="TKMouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseDown(TKMouseButtonEventArgs args)
        {
            this.ButtonDown?.Invoke(this, new MouseButtonEventArgs()
            {
                Button = (MouseButton)args.Button,
            });
        }

        /// <summary>
        /// Handles the <see cref="INativeWindowInvoker.MouseMove"/> event.
        /// </summary>
        /// <param name="args">
        /// The <see cref="TKMouseMoveEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseMove(TKMouseMoveEventArgs args)
        {
            this.Move?.Invoke(this, new MouseMoveEventArgs()
            {
                Location = new PointF(args.X, args.Y),
            });
        }

        /// <summary>
        /// Handles the <see cref="INativeWindowInvoker.MouseUp"/> event.
        /// </summary>
        /// <param name="args">
        /// The <see cref="TKMouseButtonEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseUp(TKMouseButtonEventArgs args)
        {
            this.ButtonUp?.Invoke(this, new MouseButtonEventArgs()
            {
                Button = (MouseButton)args.Button,
            });
        }

        /// <summary>
        /// Handles the <see cref="INativeWindowInvoker.MouseWheel"/> event.
        /// </summary>
        /// <param name="args">
        /// The <see cref="TKMouseWheelEventArgs"/> instance containing the event data.
        /// </param>
        private void NativeWindow_MouseWheel(TKMouseWheelEventArgs args)
        {
            this.Scroll?.Invoke(this, new MouseScrollEventArgs()
            {
                Offset = args.OffsetY,
            });
        }
    }
}