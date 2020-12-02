// <copyright file="OpenGLShader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Pipeline
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLShader : IOpenGLShader
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLShader(IOpenGLInvoker invoker, PipelineTarget target, string sourceCode)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));

            this.EntryPoint = target;

            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                throw new ArgumentNullException(nameof(sourceCode));
            }

            ShaderType type;

            switch (target)
            {
                case PipelineTarget.Vertex:
                    type = ShaderType.VertexShader;
                    break;

                case PipelineTarget.Fragment:
                    type = ShaderType.FragmentShader;
                    break;

                default:
                    throw new NotSupportedException($"The specified {nameof(target)} is not supported by the OpenGL Backend.");
            }

            this.id = this.invoker.CreateShader(type);
            this.invoker.ShaderSource(this.id, sourceCode);
            this.invoker.CompileShader(this.id);

            string? log = this.invoker.GetShaderInfoLog(this.id);

            if (!string.IsNullOrWhiteSpace(log))
            {
                // TODO: Use appropriate logging system.
                throw new Exception(log);
            }
        }

        [ExcludeFromCodeCoverage]
        ~OpenGLShader()
        {
            this.Dispose(false);
        }

        public PipelineTarget EntryPoint { get; }

        protected bool IsDisposed { get; private set; }

        public void Attach(int program)
        {
            this.invoker.AttachShader(program, this.id);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (this.id != -1)
                {
                    this.invoker.DeleteShader(this.id);
                    this.id = -1;
                }
            }

            this.IsDisposed = true;
        }
    }
}