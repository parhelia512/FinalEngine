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

        public OpenGLRenderContext(IOpenGLInvoker invoker, IBindingsContext bindings, IGraphicsContext context)
        {
            if (invoker == null)
            {
                throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");
            }

            if (bindings == null)
            {
                throw new ArgumentNullException(nameof(bindings), $"The specified {nameof(bindings)} parameter cannot be null.");
            }

            this.context = context ?? throw new ArgumentNullException(nameof(context), $"The specified {nameof(context)} parameter cannot be null.");

            context.MakeCurrent();
            invoker.LoadBindings(bindings);
        }

        public void SwapBuffers()
        {
            if (!this.context.IsCurrent)
            {
                return;
            }

            this.context.SwapBuffers();
        }
    }
}