// <copyright file="ITexture2DLoader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Textures
{
    public interface ITexture2DLoader
    {
        ITexture2D LoadTexture(string filePath);
    }
}