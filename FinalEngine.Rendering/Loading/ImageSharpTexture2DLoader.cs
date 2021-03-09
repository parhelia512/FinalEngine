// <copyright file="ImageSharpTexture2DLoader.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Loading
{
    using System;
    using System.IO;
    using FinalEngine.IO;
    using FinalEngine.Rendering.Invocation;
    using FinalEngine.Rendering.Textures;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    public class ImageSharpTexture2DLoader : ITexture2DLoader
    {
        private readonly IGPUResourceFactory factory;

        private readonly IFileSystem fileSystem;

        private readonly IImageSharpInvoker invoker;

        public ImageSharpTexture2DLoader(IFileSystem fileSystem, IImageSharpInvoker invoker, IGPUResourceFactory factory)
        {
            this.fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem), $"The specified {nameof(fileSystem)} parameter cannot be null.");
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory), $"The specified {nameof(factory)} parameter cannot be null.");
        }

        public unsafe ITexture2D LoadTexture(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), $"The specified {nameof(filePath)} parameter cannot be null, empty or consist of only whitespace characters.");
            }

            if (!this.fileSystem.FileExists(filePath))
            {
                throw new FileNotFoundException($"The specified {nameof(filePath)} parameter cannot be located.", filePath);
            }

            Stream stream = this.fileSystem.OpenFile(filePath, FileAccessMode.Read);
            Image<Rgba32> image = this.invoker.Load<Rgba32>(stream);

            int width = image.Width;
            int height = image.Height;

            int[] data = new int[width * height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Rgba32 color = image[x, y];
                    data[(y * width) + x] = (color.A << 24) | (color.B << 16) | (color.G << 8) | (color.R << 0);
                }
            }

            return this.factory.CreateTexture2D(
                new Texture2DDescription()
                {
                    Width = width,
                    Height = height,

                    MinFilter = TextureFilterMode.Nearest,
                    MagFilter = TextureFilterMode.Linear,

                    WrapS = TextureWrapMode.Repeat,
                    WrapT = TextureWrapMode.Repeat,

                    PixelType = PixelType.Byte,
                },
                data);
        }
    }
}