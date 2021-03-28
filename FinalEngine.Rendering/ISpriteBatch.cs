// <copyright file="ISpriteBatch.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering.Textures;

    public interface ISpriteBatch
    {
        void Begin();

        void Draw(ITexture2D texture, Color color, Vector2 origin, Vector2 position, float rotation, Vector2 scale);

        void End();

        void Flush();
    }
}