// <copyright file="GameContainer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    using System;
    using System.Threading;

    public abstract class GameContainer : IGame, IDisposable
    {
        ~GameContainer()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        protected bool IsRunning { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Exit()
        {
            this.IsRunning = false;
        }

        public void Run()
        {
            this.Run(120.0d);
        }

        public void Run(double frameCap)
        {
            this.Run(new GameTimeFactory(), frameCap);
        }

        public void Run(IGameTimeFactory factory, double frameCap)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            factory.CreateGameTime(frameCap, out IGameTime gameTime, out IGameTimeProcessor processor);

            this.Initialize();

            this.IsRunning = true;

            while (this.IsRunning)
            {
                if (!processor.CanProcessNextFrame())
                {
                    // TODO: This is a temporary fix to the CPU cycles issue.
                    Thread.Sleep(1);
                }

                this.Update(gameTime);
                this.Render(gameTime);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
            }

            this.IsDisposed = true;
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void Render(IGameTime gameTime)
        {
        }

        protected virtual void Update(IGameTime gameTime)
        {
        }
    }
}