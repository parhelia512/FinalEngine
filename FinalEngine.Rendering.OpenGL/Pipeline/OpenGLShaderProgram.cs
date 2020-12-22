// <copyright file="OpenGLShaderProgram.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Pipeline
{
    using System;
    using System.Collections.Generic;
    using FinalEngine.Rendering.OpenGL.Invocation;

    public class OpenGLShaderProgram : IOpenGLShaderProgram
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLShaderProgram(IOpenGLInvoker invoker, IReadOnlyCollection<IOpenGLShader> shaders)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (shaders == null)
            {
                throw new ArgumentNullException(nameof(shaders), $"The specified {nameof(shaders)} parameter cannot be null.");
            }

            this.id = this.invoker.CreateProgram();

            foreach (IOpenGLShader? shader in shaders)
            {
                if (shader == null)
                {
                    continue;
                }

                shader.Attach(this.id);
            }

            this.invoker.LinkProgram(this.id);
            this.invoker.ValidateProgram(this.id);

            string? log = this.invoker.GetProgramInfoLog(this.id);

            if (!string.IsNullOrWhiteSpace(log))
            {
                // TODO: Use appropriate logging system.
                throw new Exception(log);
            }
        }

        ~OpenGLShaderProgram()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLShader));
            }

            this.invoker.UseProgram(this.id);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int GetUniformLocation(string name)
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLShader));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), $"The specified {nameof(name)} parameter cannot be null, empty or contain only whitespace.");
            }

            return this.invoker.GetUniformLocation(this.id, name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing && this.id != -1)
            {
                this.invoker.DeleteProgram(this.id);
                this.id = -1;
            }

            this.IsDisposed = true;
        }
    }
}