// <copyright file="MainPresenter.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Editor.Presenters
{
    using System;
    using FinalEngine.Editor.Views;

    public sealed class MainPresenter : IMainPresenter
    {
        private readonly IMainView view;

        public MainPresenter(IMainView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view), $"The specified {nameof(view)} parameter cannot be null.");
        }

        public void Present()
        {
            this.view.Run();
        }
    }
}