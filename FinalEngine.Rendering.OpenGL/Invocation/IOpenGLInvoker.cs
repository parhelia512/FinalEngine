// <copyright file="IOpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using OpenTK;

    public interface IOpenGLInvoker
    {
        void LoadBindings(IBindingsContext context);
    }
}