// <copyright file="GameTimeFactory.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class GameTimeFactory : IGameTimeFactory
    {
        public void CreateGameTime(double frameCap, out IGameTime gameTime, out IGameTimeProcessor processor)
        {
            gameTime = new GameTime(frameCap);
            processor = gameTime as IGameTimeProcessor;
        }
    }
}