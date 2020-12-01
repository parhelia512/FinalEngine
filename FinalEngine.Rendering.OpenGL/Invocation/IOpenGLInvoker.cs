// <copyright file="IOpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Invocation")]
    public interface IOpenGLInvoker
    {
        void Disable(EnableCap cap);

        void Enable(EnableCap cap);

        void LoadBindings(IBindingsContext context);

        void Viewport(Rectangle rectangle);
    }
}