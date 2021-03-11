// <copyright file="ImageInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Invocation
{
    using System.IO;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;

    /// <summary>
    ///   Defines an interface that provides methods for invocation of the <see cref="Image"/> functions.
    /// </summary>
    public class ImageInvoker : IImageInvoker
    {
        /// <inheritdoc cref="Image.Load{TPixel}(Stream)"/>
        public Image<TPixel> Load<TPixel>(Stream stream)
            where TPixel : unmanaged, IPixel<TPixel>
        {
            return Image.Load<TPixel>(stream);
        }
    }
}