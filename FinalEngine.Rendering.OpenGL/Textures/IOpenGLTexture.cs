// <copyright file="IOpenGLTexture.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Textures
{
    using FinalEngine.Rendering.Textures;

    public interface IOpenGLTexture : ITexture
    {
        void Bind();

        void Slot(int index);
    }
}