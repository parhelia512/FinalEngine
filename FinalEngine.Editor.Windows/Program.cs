// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Editor.Windows
{
    using System;
    using FinalEngine.Editor.Presenters;
    using FinalEngine.Editor.Views;
    using FinalEngine.Editor.Windows.Views;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///   The main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            new ServiceCollection()
                .AddSingleton<IMainView, MainView>()
                .AddSingleton<IMainPresenter, MainPresenter>()
                .BuildServiceProvider()
                .GetService<IMainPresenter>()?.Present();
        }
    }
}