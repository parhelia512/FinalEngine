// <copyright file="ImageSharpInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Invocation
{
    using System.IO;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    public sealed class ImageSharpInvoker : IImageSharpInvoker
    {
        public Image<TPixel> Load<TPixel>(Stream stream)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            return Image.Load<TPixel>(stream);
        }
    }
}