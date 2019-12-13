using System;
using System.Collections.Generic;
using System.Text;

namespace FinalEngine.Platform.Desktop
{
    public class Game : IEventsProcessor
    {
        #region Private Fields
        private readonly IDisplay _display;
        #endregion


        #region Constructors
        public Game(IDisplay display, int width, int height, string title)
        {
            _display = display;

            _display.Width = width;
            _display.Height = height;
            _display.Title = title;
        }
        #endregion


        #region Public Methods
        public void Run()
        {
            _display.Visible = true;

            while (!_display.IsClosing)
            {
                ProcessEvents();
            }
        }


        public void ProcessEvents()
        {
            //Add event processing code here
        }


        public void Dispose()
        {
        }
        #endregion
    }
}
