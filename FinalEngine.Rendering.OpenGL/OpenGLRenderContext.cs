// <copyright file="OpenGLRenderContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK;
    using OpenTK.Windowing.Common;

    public class OpenGLRenderContext : IRenderContext
    {
        private readonly IGraphicsContext context;

        private readonly IOpenGLInvoker invoker;

        private int vao;

        public OpenGLRenderContext(IOpenGLInvoker invoker, IBindingsContext bindings, IGraphicsContext context)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            if (bindings == null)
            {
                throw new ArgumentNullException(nameof(bindings), $"The specified {nameof(bindings)} parameter cannot be null.");
            }

            this.context = context ?? throw new ArgumentNullException(nameof(context), $"The specified {nameof(context)} parameter cannot be null.");

            context.MakeCurrent();
            invoker.LoadBindings(bindings);

            this.vao = invoker.GenVertexArray();
            invoker.BindVertexArray(this.vao);
        }

        ~OpenGLRenderContext()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SwapBuffers()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(OpenGLRenderContext));
            }

            if (!this.context.IsCurrent)
            {
                throw new Exception($"This {nameof(OpenGLRenderContext)} is not current on the calling thread.");
            }

            this.context.SwapBuffers();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing && this.vao != -1)
            {
                this.invoker.DeleteVertexArray(this.vao);
                this.vao = -1;
            }

            this.IsDisposed = true;
        }
    }
}
