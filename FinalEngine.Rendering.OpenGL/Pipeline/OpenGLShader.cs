// <copyright file="OpenGLShader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Pipeline
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Utilities;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLShader : IOpenGLShader
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLShader(IOpenGLInvoker invoker, IEnumMapper mapper, ShaderType type, string sourceCode)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                throw new ArgumentNullException(nameof(sourceCode), $"The specified {nameof(sourceCode)} parameter cannot be null, empty or contain only whitespace.");
            }

            this.EntryPoint = mapper.Reverse<PipelineTarget>(type);

            this.id = invoker.CreateShader(type);
            invoker.ShaderSource(this.id, sourceCode);
            invoker.CompileShader(this.id);

            string? log = invoker.GetShaderInfoLog(this.id);

            if (!string.IsNullOrWhiteSpace(log))
            {
                // TODO: Use appropriate logging system.
                throw new Exception(log);
            }
        }

        ~OpenGLShader()
        {
            this.Dispose(false);
        }

        public PipelineTarget EntryPoint { get; }

        protected bool IsDisposed { get; private set; }

        public void Attach(int program)
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLShader));
            }

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

            if (disposing && this.id != -1)
            {
                this.invoker.DeleteShader(this.id);
                this.id = -1;
            }

            this.IsDisposed = true;
        }
    }
}