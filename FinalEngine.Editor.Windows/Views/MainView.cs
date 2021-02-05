// <copyright file="MainView.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Editor.Windows.Views
{
    using System.Windows.Forms;
    using FinalEngine.Editor.Views;

    public partial class MainView : Form, IMainView
    {
        static MainView()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public MainView()
        {
            this.InitializeComponent();
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}