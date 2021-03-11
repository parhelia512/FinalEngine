// <copyright file="ITexture2DLoader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Textures
{
    /// <summary>
    ///   Defines an interface that provides a method for loading textures from a file system.
    /// </summary>
    public interface ITexture2DLoader
    {
        /// <summary>
        ///   Loads the texture from the specified <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">
        ///   The file path of texture to load.
        /// </param>
        /// <returns>
        ///   The newly loaded texture resource.
        /// </returns>
        ITexture2D LoadTexture(string filePath);
    }
}