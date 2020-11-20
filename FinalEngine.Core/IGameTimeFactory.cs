// <copyright file="IGameTimeFactory.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    public interface IGameTimeFactory
    {
        void CreateGameTime(double frameCap, out IGameTime gameTime, out IGameTimeProcessor processor);
    }
}