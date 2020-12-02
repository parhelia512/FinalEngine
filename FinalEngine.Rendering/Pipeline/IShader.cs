// <copyright file="IShader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Pipeline
{
    using System;

    public enum PipelineTarget
    {
        // TODO: Should this even be here, I only did it to satisfy unit tests?
        None,

        Vertex,

        Fragment,
    }

    public interface IShader : IDisposable
    {
        PipelineTarget EntryPoint { get; }
    }
}