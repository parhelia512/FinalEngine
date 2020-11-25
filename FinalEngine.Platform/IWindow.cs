// <copyright file="IWindow.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    using System;

    /// <summary>
    /// Defines an interface that represents a display or window.
    /// </summary>
    /// <example>
    /// Below is an example implementation of the <see cref="IWindow" /> interface using the Form class:
    /// <code title="Program.cs">
    /// namespace WinFormsIEventsProcessorExample
    /// {
    ///     using System.Windows.Forms;
    ///     using FinalEngine.Platform;
    ///
    ///     public class WinFormsWindow : Form, IWindow
    ///     {
    ///         public WinFormsWindow(int width, int height, string title)
    ///         {
    ///             this.Width = width;
    ///             this.Height = height;
    ///             this.Title = title;
    ///         }
    ///
    ///         public bool IsExiting { get; private set; }
    ///
    ///         public string Title
    ///         {
    ///             get { return this.Text; }
    ///             set { this.Text = value; }
    ///         }
    ///
    ///         protected override void OnFormClosing(FormClosingEventArgs e)
    ///         {
    ///             IsExiting = true;
    ///             base.OnFormClosing(e);
    ///         }
    ///     }
    ///
    ///     internal static class Program
    ///     {
    ///         private static void Main()
    ///         {
    ///             // In a real Final Engine application you would also implement the IEventsProcessor interface to handle the application in real-time.
    ///             Application.Run(new WinFormsWindow(800, 600, "WinForms IWindow Implementation"));
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="System.IDisposable" />
    public interface IWindow : IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IWindow"/> is exiting.
        /// </summary>
        /// <value>
        /// <c>true</c> if this <see cref="IWindow"/> is exiting; otherwise, <c>false</c>.
        /// </value>
        bool IsExiting { get; }

        /// <summary>
        /// Gets or sets the title of this <see cref="IWindow"/>.
        /// </summary>
        /// <value>
        /// The title of this <see cref="IWindow"/>.
        /// </value>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IWindow"/> is visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this <see cref="IWindow"/> is visible; otherwise, <c>false</c>.
        /// </value>
        bool Visible { get; set; }

        /// <summary>
        /// Closes this <see cref="IWindow"/>, disposing of it's resources.
        /// </summary>
        void Close();
    }
}