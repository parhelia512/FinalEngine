// <copyright file="WinFormsEventProcessor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Platform.Windows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    [ExcludeFromCodeCoverage]
    public sealed class WinFormsEventProcessor : IEventsProcessor
    {
        public WinFormsEventProcessor(Form form)
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

        public bool CanProcessEvents { get; private set; } = true;

        public void ProcessEvents()
        {
            Application.DoEvents();
        }
    }
}