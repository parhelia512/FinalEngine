// <copyright file="GameTime.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Core.Invoking;

    /// <summary>
    ///     Provides a standard implementation of an <see cref="IGameTime"/> and <see cref="IGameTimeProcessor"/>.
    /// </summary>
    /// <remarks>
    ///     This class should be used any time you wish to manage time within your game. It is
    ///     designed in such a way that it is framework independent, so there will not be much
    ///     trouble if you need to use this class.
    /// </remarks>
    /// <seealso cref="FinalEngine.Core.IGameTime"/>
    /// <seealso cref="FinalEngine.Core.IGameTimeProcessor"/>
    public class GameTime : IGameTime, IGameTimeProcessor
    {
        /// <summary>
        ///     One second in milliseconds.
        /// </summary>
        private const double Second = 1000.0d;

        /// <summary>
        ///     The amount of time required to wait before each frame can be processed.
        /// </summary>
        private readonly double waitTime;

        /// <summary>
        ///     The watch invoker.
        /// </summary>
        private readonly IStopwatchInvoker watch;

        /// <summary>
        ///     The last time a frame was processed.
        /// </summary>
        private double lastTime;

        /// <summary>
        ///     The last time the FPS was logged.
        /// </summary>
        private double lastTimeFPS;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameTime"/> class.
        /// </summary>
        /// <remarks>
        ///     This class constructor sets the frame cap to 120 frames-per-second.
        /// </remarks>
        [ExcludeFromCodeCoverage]
        public GameTime()
            : this(120.0d)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameTime"/> class.
        /// </summary>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames to be processed per second.
        /// </param>
        /// <remarks>
        ///     This class constructor instantiates a <see cref="StopwatchInvoker"/> internally.
        /// </remarks>
        [ExcludeFromCodeCoverage]
        public GameTime(double frameCap)
            : this(new StopwatchInvoker(), frameCap)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameTime"/> class.
        /// </summary>
        /// <param name="watch">
        ///     Specifies the watch to be used when handling time.
        /// </param>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames that can be processed per second.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///     The specified <paramref name="watch"/> parameter is null.
        /// </exception>
        /// <exception cref="System.DivideByZeroException">
        ///     The specified <paramref name="frameCap"/> parameter must be greater than zero.
        /// </exception>
        public GameTime(IStopwatchInvoker watch, double frameCap)
        {
            if (watch == null)
            {
                throw new ArgumentNullException(nameof(watch));
            }

            if (frameCap <= 0)
            {
                throw new DivideByZeroException($"The specified {nameof(frameCap)} parameter must be greater than zero.");
            }

            this.watch = watch;
            this.waitTime = Second / frameCap;
        }

        /// <summary>
        ///     Gets the delta (the amount of time it took to process the previous frame, in milliseconds).
        /// </summary>
        /// <value>
        ///     The delta (the amount of time it took to process the previous frame, in milliseconds).
        /// </value>
        public double Delta { get; private set; }

        /// <summary>
        ///     Gets the current FPS (frames-per-second).
        /// </summary>
        /// <value>
        ///     The current FPS (frames-per-second).
        /// </value>
        public double FPS { get; private set; }

        /// <summary>
        ///     Determines whether a game can process the next frame.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the game can process; otherwise, <c>false</c>.
        /// </returns>
        public bool CanProcessNextFrame()
        {
            if (!this.watch.IsRunning)
            {
                this.watch.Restart();
            }

            double currentTime = this.watch.Elapsed.TotalMilliseconds;

#if DEBUG
            if (currentTime >= this.lastTimeFPS + Second)
            {
                Console.WriteLine($"FPS: {this.FPS}");
                Console.WriteLine($"Delta: {this.Delta}");

                this.lastTimeFPS = currentTime;
            }
#endif

            if (currentTime >= this.lastTime + this.waitTime)
            {
                this.Delta = currentTime - this.lastTime;
                this.FPS = Math.Round(1.0f / this.Delta * Second);

                this.lastTime = currentTime;

                return true;
            }

            return false;
        }
    }
}