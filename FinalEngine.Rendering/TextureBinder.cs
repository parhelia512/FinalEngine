// <copyright file="TextureBinder.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Collections.Generic;
    using FinalEngine.Rendering.Textures;

    public class TextureBinder : ITextureBinder
    {
        private readonly IPipeline pipeline;

        private readonly IDictionary<ITexture2D, int> textureToIdentifierMap;

        public TextureBinder(IPipeline pipeline)
        {
            this.pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline), $"The specified {nameof(pipeline)} parameter cannot be null.");
            this.textureToIdentifierMap = new Dictionary<ITexture2D, int>(this.pipeline.MaxTextureSlots);

            for (int i = 0; i < this.pipeline.MaxTextureSlots; i++)
            {
                this.pipeline.SetUniform($"u_textures[{i}]", i);
            }
        }

        public bool ShouldReset
        {
            get { return this.textureToIdentifierMap.Count >= this.pipeline.MaxTextureSlots; }
        }

        public int GetTextureID(ITexture2D texture)
        {
            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture), $"The specified {nameof(texture)} parameter cannot be null.");
            }

            if (this.textureToIdentifierMap.ContainsKey(texture))
            {
                return this.textureToIdentifierMap[texture];
            }

            int textureID = this.textureToIdentifierMap.Count;
            this.pipeline.SetTexture(texture, textureID);
            this.textureToIdentifierMap.Add(texture, textureID);

            return textureID;
        }

        public void Reset()
        {
            this.textureToIdentifierMap.Clear();
        }
    }
}