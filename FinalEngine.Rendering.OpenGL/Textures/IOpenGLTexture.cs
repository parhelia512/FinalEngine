// <copyright file="IOpenGLTexture.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Textures
{
    using System;
    using FinalEngine.Rendering.Textures;

    /// <summary>
    ///   Defines an interface that represents an OpenGL texture.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.Textures.ITexture"/>
    public interface IOpenGLTexture : ITexture
    {
        /// <summary>
        ///   Binds this <see cref="IOpenGLTexture"/> to the graphics processing unit.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///   The <see cref="IOpenGLTexture"/> has been disposed.
        /// </exception>
        void Bind(int slot);
    }
}