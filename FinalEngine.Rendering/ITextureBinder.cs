// <copyright file="ITextureBinder.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using FinalEngine.Rendering.Textures;

    public interface ITextureBinder : IResetable
    {
        int GetTextureID(ITexture2D texture);
    }
}