// <copyright file="WinFormsEventsProcessor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Windows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    /// <summary>
    ///   Provides an implementation of <see cref="IEventsProcessor"/> for Windows Forms.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.IEventsProcessor"/>
    [ExcludeFromCodeCoverage]
    public sealed class WinFormsEventsProcessor : IEventsProcessor
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="WinFormsEventsProcessor"/> class.
        /// </summary>
        /// <param name="form">
        ///   Specifies a <see cref="Form"/> that represents the form to process events for.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="form"/> parameter is null.
        /// </exception>
        public WinFormsEventsProcessor(Form form)
        {
            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            form.FormClosing += (s, e) =>
            {
                if (e.Cancel)
                {
                    return;
                }

                this.CanProcessEvents = false;
            };
        }

        /// <summary>
        ///   Gets a value indicating whether this <see cref="WinFormsEventsProcessor"/> can process events.
        /// </summary>
        /// <value>
        ///   <c>true</c> if can process events; otherwise, <c>false</c>.
        /// </value>
        public bool CanProcessEvents { get; private set; } = true;

        /// <summary>
        ///   Processes the events that are currently in the message queue.
        /// </summary>
        public void ProcessEvents()
        {
            Application.DoEvents();
        }
    }
}