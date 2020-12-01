// <copyright file="IRasterizer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Drawing;

    public interface IRasterizer
    {
        void SetRasterState(RasterStateDescription description);

        void SetScissor(Rectangle rectangle);

        void SetViewport(Rectangle rectangle);
    }
}