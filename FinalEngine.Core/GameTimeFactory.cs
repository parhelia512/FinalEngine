// <copyright file="GameTimeFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Provides a <see cref="GameTime"/> factory implementation of an <see cref="IGameTimeFactory"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Core.IGameTimeFactory"/>
    [ExcludeFromCodeCoverage]
    public class GameTimeFactory : IGameTimeFactory
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
        public void CreateGameTime(double frameCap, out IGameTime gameTime, out IGameTimeProcessor processor)
        {
            gameTime = new GameTime(frameCap);
            processor = gameTime as IGameTimeProcessor;
        }
    }
}