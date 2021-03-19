// <copyright file="Material.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using FinalEngine.Rendering.Textures;

    public class Material : IMaterial
    {
        private readonly ITexture? diffuseMap;

        public Material(ITexture? diffuseMap)
        {
            this.diffuseMap = diffuseMap;
        }

        public void Set(IPipeline pipeline)
        {
            if (pipeline == null)
            {
                throw new ArgumentNullException(nameof(pipeline), $"The specified {nameof(pipeline)} parameter cannot be null.");
            }

            pipeline.SetUniform("u_material.diffuseMap", 0);

            pipeline.SetTexture(this.diffuseMap, 0);
        }
    }
}