// <copyright file="IEventsProcessor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    /// <summary>
    /// Defines an interface that provides a method for processing OS-specific events in a message
    /// queue.
    /// </summary>
    /// <example>
    /// Below is an example implementation of the <see cref="IEventsProcessor" /> interface using the Form class:
    /// <code title="Program.cs">
    /// namespace WinFormsIEventsProcessorExample
    /// {
    ///     using System.Windows.Forms;
    ///     using FinalEngine.Platform;
    ///
    ///     public class WinFormsWindow : Form, IWindow, IEventsProcessor
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
    ///         public void ProcessEvents()
    ///         {
    ///             Application.DoEvents();
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
    ///             var window = new WinFormsWindow(800, 600, "WinForms IEventsProcessor Implementation")
    ///             {
    ///                 // Make sure it's visible on startup.
    ///                 Visible = true
    ///             };
    ///
    ///             // The main loop.
    ///             while (!window.IsExiting)
    ///             {
    ///                 window.ProcessEvents();
    ///             }
    ///
    ///             // Dispose of the window.
    ///             window.Dispose();
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    public interface IEventsProcessor
    {
        /// <summary>
        /// Processes the events that are currently in the message queue.
        /// </summary>
        void ProcessEvents();
    }
}