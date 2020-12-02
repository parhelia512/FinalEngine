// <copyright file="OpenGLGPUResourceFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using FinalEngine.Rendering.Pipeline;

    public class OpenGLGPUResourceFactory : IGPUResourceFactory
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLGPUResourceFactory(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        public IShader CreateShader(PipelineTarget target, string sourceCode)
        {
            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                throw new ArgumentNullException(nameof(sourceCode));
            }

            return new OpenGLShader(this.invoker, target, sourceCode);
        }

        public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders)
        {
            if (shaders == null)
            {
                throw new ArgumentNullException(nameof(shaders));
            }

            return new OpenGLShaderProgram(this.invoker, shaders.Cast<IOpenGLShader>());
        }
    }
}