// <copyright file="IGPUResourceFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Collections.Generic;
    using FinalEngine.Rendering.Pipeline;

    public interface IGPUResourceFactory
    {
        IShader CreateShader(PipelineTarget target, string sourceCode);

        IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders);
    }
}