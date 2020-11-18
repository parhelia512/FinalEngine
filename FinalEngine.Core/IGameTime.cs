// <copyright file="IGameTime.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core
{
    public interface IGameTime
    {
        double Delta { get; }

        double FPS { get; }
    }
}