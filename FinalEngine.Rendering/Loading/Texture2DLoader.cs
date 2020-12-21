// <copyright file="Texture2DLoader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Loading
{
    using System;
    using System.IO;
    using FinalEngine.IO;
    using FinalEngine.Rendering.Textures;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    public sealed class Texture2DLoader : ITexture2DLoader
    {
        private readonly IGPUResourceFactory factory;

        private readonly IFileSystem fileSystem;

        public Texture2DLoader(IGPUResourceFactory factory, IFileSystem fileSystem)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory), $"The specified {nameof(factory)} parameter cannot be null.");
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem), $"The specified {nameof(fileSystem)} parameter cannot be null.");
        }

        public ITexture2D LoadTexture2D(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path), $"The specified {nameof(path)} parameter cannot be null.");
            }

            if (!this.fileSystem.FileExists(path))
            {
                throw new FileNotFoundException($"The specified {nameof(path)} couldn't be located on the disk.", nameof(path));
            }

            using (Stream stream = this.fileSystem.OpenFile(path, FileAccessMode.Read))
            {
                using (var image = Image.Load<Rgba32>(stream))
                {
                    var description = new Texture2DDescription()
                    {
                        Width = image.Width,
                        Height = image.Height,
                    };

                    int[] data = new int[image.Width * image.Height];

                    for (int x = 0; x < image.Width; x++)
                    {
                        for (int y = 0; y < image.Height; y++)
                        {
                            Rgba32 color = image[x, y];
                            data[(y * image.Width) + x] = (color.A << 24) | (color.B << 16) | (color.G << 8) | (color.R << 0);
                        }
                    }

                    return this.factory.CreateTexture2D(description, data, PixelFormat.Rgba, SizedFormat.Rgba8);
                }
            }
        }
    }
}