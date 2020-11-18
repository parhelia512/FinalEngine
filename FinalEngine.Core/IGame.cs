// <copyright file="IGame.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    /// <summary>
    ///     Defines an interface that represents a real-time game application.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        ///     Runs this <see cref="IGame"/> at the specified <paramref name="frameCap"/>.
        /// </summary>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames to be updated and rendered per second.
        /// </param>
        void Run(double frameCap);
    }
}