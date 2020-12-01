// <copyright file="IOpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using OpenTK;

    /// <summary>
    ///   Defines an interface that provides methods for invocation of the OpenGL Library.
    /// </summary>
    public interface IOpenGLInvoker
    {
        /// <summary>
        ///   Loads all bindings using the specified <paramref name="context"/>.
        /// </summary>
        /// <param name="context">
        ///   Specifies a <see cref="IBindingsContext"/> that represents the bindings context used to load the bindings.
        /// </param>
        void LoadBindings(IBindingsContext context);
    }
}