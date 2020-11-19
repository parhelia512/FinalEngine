// <copyright file="GameContainer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

//// TODO: Unit Test this later on, not now because too much will probably change.

namespace FinalEngine.Core
{
    using System;
    using FinalEngine.Core.Threading;

    /// <summary>
    ///     Provides an abstract representation of an <see cref="IGame"/>.
    /// </summary>
    /// <remarks>
    ///     You should inherit from this class and use it as your "main" method.
    /// </remarks>
    /// <seealso cref="FinalEngine.Core.IGame"/>
    /// <seealso cref="System.IDisposable"/>
    public abstract class GameContainer : IGame, IDisposable
    {
        private readonly ITaskScheduler scheduler;

        public GameContainer()
            : this(new Threading.TaskScheduler())
        {
        }

        public GameContainer(ITaskScheduler scheduler)
        {
            this.scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="GameContainer"/> class.
        /// </summary>
        ~GameContainer()
        {
            this.Dispose(false);
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this game is running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this game is running; otherwise, <c>false</c>.
        /// </value>
        protected bool IsRunning { get; private set; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting
        ///     unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Exits the game, don't forget to call <see cref="Dispose"/> after the game has exited.
        /// </summary>
        public void Exit()
        {
            this.IsRunning = false;
        }

        /// <summary>
        ///     Runs this <see cref="IGame"/> at a maximum of 120 frames-per-second.
        /// </summary>
        /// <remarks>
        ///     This method invokes <see cref="Run(double)"/> internally.
        /// </remarks>
        public void Run()
        {
            this.Run(120.0d);
        }

        /// <summary>
        ///     Runs this <see cref="IGame"/> at the specified <paramref name="frameCap"/>.
        /// </summary>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames to be updated and rendered per second.
        /// </param>
        /// <remarks>
        ///     This method invokes <see cref="Run(IGameTimeFactory, double)"/> internally.
        /// </remarks>
        public void Run(double frameCap)
        {
            this.Run(new GameTimeFactory(), frameCap);
        }

        /// <summary>
        ///     Runs this <see cref="IGame"/>, at the specified <paramref name="frameCap"/>.
        /// </summary>
        /// <param name="factory">
        ///     Specifies a <see cref="IGameTimeFactory"/> required to create a <see
        ///     cref="IGameTime"/> and <see cref="IGameTimeProcessor"/> to run the game.
        /// </param>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames to be updated and rendered per second.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="factory"/> parameter is null.
        /// </exception>
        public async void Run(IGameTimeFactory factory, double frameCap)
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
                    ////this.scheduler.Sleep(1);
                    ////await Task.Delay(1);

                    /*
                        It seems like there's an issue with how I'm managing time within the engine.
                        I really don't know what I'm supposed to do, I don't think it can be resolved
                        without designing an entirely new system for time management.
                    */

                    continue;
                }

                this.Update(gameTime);
                this.Render(gameTime);
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        ///     only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                //// TODO: Dispose of resources here.
            }

            this.IsDisposed = true;
        }

        /// <summary>
        ///     Initializes the game. You should do any logic initilization and content loading here.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        ///     Renders the game. This method is called once per frame, right after <see
        ///     cref="Update(IGameTime)"/> is called.
        /// </summary>
        /// <param name="gameTime">
        ///     Specifies the <see cref="IGameTime"/> which provides information about the current
        ///     time of the game at this frame.
        /// </param>
        protected virtual void Render(IGameTime gameTime)
        {
        }

        /// <summary>
        ///     Updates the game. This method is called once per frame, right before <see
        ///     cref="Render(IGameTime)"/> is called.
        /// </summary>
        /// <param name="gameTime">
        ///     Specifies the <see cref="IGameTime"/> which provides information about the current
        ///     time of the game at this frame.
        /// </param>
        protected virtual void Update(IGameTime gameTime)
        {
        }
    }
}