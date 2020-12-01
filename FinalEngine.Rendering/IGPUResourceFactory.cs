// <copyright file="IGPUResourceFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using FinalEngine.Rendering.Pipeline;

    public interface IGPUResourceFactory
    {
        IShader CreateShader(PipelineTarget target, string sourceCode);

        IShaderProgram CreateShaderProgram(IShader[] shaders);
    }
}