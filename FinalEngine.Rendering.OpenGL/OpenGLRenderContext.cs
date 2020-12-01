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
            if (bindings == null)
            {
                throw new ArgumentNullException(nameof(bindings));
            }

            if (invoker == null)
            {
                throw new ArgumentNullException(nameof(invoker));
            }

            this.context = context ?? throw new ArgumentNullException(nameof(context));

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