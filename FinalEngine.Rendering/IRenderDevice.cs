// <copyright file="IRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    public interface IRenderDevice
    {
        IRasterizer Rasterizer { get; }

        //// TODO: Scissor Testing here
    }
}