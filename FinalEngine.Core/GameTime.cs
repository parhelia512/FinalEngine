// <copyright file="GameTime.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Core.Invoking;

    public class GameTime : IGameTime, IGameTimeProcessor
    {
        private const double Second = 1000.0d;

        private readonly double waitTime;

        private readonly IStopwatchInvoker watch;

        private double lastTime;

        [ExcludeFromCodeCoverage]
        public GameTime()
            : this(120.0d)
        {
        }

        [ExcludeFromCodeCoverage]
        public GameTime(double frameCap)
            : this(new StopwatchInvoker(), frameCap)
        {
        }

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

        public double Delta { get; private set; }

        public double FPS { get; private set; }

        public bool CanProcessNextFrame()
        {
            if (!this.watch.IsRunning)
            {
                this.watch.Restart();
            }

            double currentTime = this.watch.Elapsed.TotalMilliseconds;

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