// <copyright file="IGameTimeFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    /// <summary>
    ///     Defines an interface that provide a factory for creating <see cref="IGameTime"/>'s and
    ///     <see cref="IGameTimeProcessor"/>'s.
    /// </summary>
    public interface IGameTimeFactory
    {
        /// <summary>
        ///     Creates a <see cref="IGameTime"/>.and <see cref="IGameTimeProcessor"/> at the
        ///     specified <paramref name="frameCap"/>.
        /// </summary>
        /// <param name="frameCap">
        ///     Specifies the maximum number of frames that can be processed per second (this can be
        ///     thought of as the "maximum FPS" or V-Syncing).
        /// </param>
        /// <param name="gameTime">
        ///     Specifies the newly created <see cref="IGameTime"/>.
        /// </param>
        /// <param name="processor">
        ///     Specifies the newly created <see cref="IGameTimeProcessor"/>.
        /// </param>
        void CreateGameTime(double frameCap, out IGameTime gameTime, out IGameTimeProcessor processor);
    }
}