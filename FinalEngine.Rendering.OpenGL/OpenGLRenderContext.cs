// <copyright file="OpenGLRenderContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK;
    using OpenTK.Windowing.Common;

    /// <summary>
    ///   Provides an OpenGL implementation of an <see cref="IGraphicsContext"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.IRenderContext"/>
    public class OpenGLRenderContext : IRenderContext
    {
        /// <summary>
        ///   The underlying OpenGL Graphics Context.
        /// </summary>
        private readonly IGraphicsContext context;

        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenGLRenderContext"/> class.
        /// </summary>
        /// <param name="invoker">
        ///   Specifies an <see cref="IOpenGLInvoker"/> that represents the invoker used to load the libraries bindings.
        /// </param>
        /// <param name="bindings">
        ///   Specifies an <see cref="IBindingsContext"/> that represents the bindings context use to load the libraries bindings.
        /// </param>
        /// <param name="context">
        ///   Specifies an <see cref="IGraphicsContext"/> that represents the graphics context used to manage the OpenGL context.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="bindings"/>, <paramref name="invoker"/> or <paramref name="context"/> parameter is null.
        /// </exception>
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

        /// <inheritdoc/>
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