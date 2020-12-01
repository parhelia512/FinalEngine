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
        /// <inheritdoc/>
        public void CullFace(CullFaceMode mode)
        {
            GL.CullFace(mode);
        }

        /// <inheritdoc/>
        public void Disable(EnableCap cap)
        {
            GL.Disable(cap);
        }

        /// <inheritdoc/>
        public void Enable(EnableCap cap)
        {
            GL.Enable(cap);
        }

        public void FrontFace(FrontFaceDirection mode)
        {
            GL.FrontFace(mode);
        }

        /// <inheritdoc/>
        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
        }

        /// <inheritdoc/>
        public void PolygonMode(MaterialFace face, PolygonMode mode)
        {
            GL.PolygonMode(face, mode);
        }

        /// <inheritdoc/>
        public void Viewport(Rectangle rectangle)
        {
            GL.Viewport(rectangle);
        }
    }
}