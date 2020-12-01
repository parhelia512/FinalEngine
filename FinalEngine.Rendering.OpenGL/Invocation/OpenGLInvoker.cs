// <copyright file="OpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    public class OpenGLInvoker : IOpenGLInvoker
    {
        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
        }
    }
}