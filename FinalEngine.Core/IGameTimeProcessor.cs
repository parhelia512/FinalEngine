// <copyright file="IGameTimeProcessor.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    /// <summary>
    ///     Defines an interface that provides a method for processing time within a game.
    /// </summary>
    public interface IGameTimeProcessor
    {
        /// <summary>
        ///     Determines whether a game can process the next frame.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the game can process; otherwise, <c>false</c>.
        /// </returns>
        bool CanProcessNextFrame();
    }
}