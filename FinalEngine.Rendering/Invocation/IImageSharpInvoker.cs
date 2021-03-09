// <copyright file="IImageSharpInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Invocation
{
    using System.IO;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    public interface IImageSharpInvoker
    {
        Image<TPixel> Load<TPixel>(Stream stream)
            where TPixel : unmanaged, IPixel<TPixel>;
    }
}