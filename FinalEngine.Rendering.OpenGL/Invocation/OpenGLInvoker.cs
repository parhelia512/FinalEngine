// <copyright file="OpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IOpenGLInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.OpenGL.Invocation.IOpenGLInvoker"/>
    [ExcludeFromCodeCoverage]
    public class OpenGLInvoker : IOpenGLInvoker
    {
        public void Disable(EnableCap cap)
        {
            GL.Disable(cap);
        }

        public void Enable(EnableCap cap)
        {
            GL.Enable(cap);
        }

        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
        }

        public void Viewport(Rectangle rectangle)
        {
            GL.Viewport(rectangle);
        }
    }
}