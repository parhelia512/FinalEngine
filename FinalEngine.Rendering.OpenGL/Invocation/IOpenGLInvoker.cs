// <copyright file="IOpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    /// <summary>
    ///   Defines an interface that provides methods for invocation of the <see cref="GL"/> functions.
    /// </summary>
    public interface IOpenGLInvoker
    {
        /// <inheritdoc cref="GL.CullFace(CullFaceMode)"/>
        void CullFace(CullFaceMode mode);

        /// <inheritdoc cref="GL.Disable(EnableCap)"/>
        void Disable(EnableCap cap);

        /// <inheritdoc cref="GL.Enable(EnableCap)"/>
        void Enable(EnableCap cap);

        /// <inheritdoc cref="GL.FrontFace(FrontFaceDirection)"/>
        void FrontFace(FrontFaceDirection mode);

        /// <inheritdoc cref="GL.LoadBindings(IBindingsContext)"/>
        void LoadBindings(IBindingsContext context);

        /// <inheritdoc cref="GL.PolygonMode(MaterialFace, PolygonMode)"/>
        void PolygonMode(MaterialFace face, PolygonMode mode);

        /// <inheritdoc cref="GL.Viewport(Rectangle)"/>
        void Viewport(Rectangle rectangle);
    }
}