// <copyright file="OpenGLShaderProgram.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Pipeline
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;

    public class OpenGLShaderProgram : IShaderProgram, IOpenGLShaderProgram
    {
        private readonly IOpenGLInvoker invoker;

        private int id;

        public OpenGLShaderProgram(IOpenGLInvoker invoker, IEnumerable<IOpenGLShader> shaders)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));

            if (shaders == null)
            {
                throw new ArgumentNullException(nameof(shaders));
            }

            this.id = this.invoker.CreateProgram();

            //// TODO: Should we make sure the user creates a program with both a vertex and fragment shader?
            //// TODO: How should we handle errors and warnings? Perhaps we need a way to decipher them and print out our own errors or warnings?

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

        [ExcludeFromCodeCoverage]
        ~OpenGLShaderProgram()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Bind()
        {
            this.invoker.UseProgram(this.id);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int GetUniformLocation(string name)
        {
            return this.invoker.GetUniformLocation(this.id, name);
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
                    this.invoker.DeleteProgram(this.id);
                    this.id = -1;
                }
            }

            this.IsDisposed = true;
        }
    }
}