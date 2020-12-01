// <copyright file="IRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Drawing;

    /// <summary>
    ///   Defines an interface that represents a rendering device (virtual or hardware).
    /// </summary>
    public interface IRenderDevice
    {
        /// <summary>
        ///   Gets the rasterizer.
        /// </summary>
        /// <value>
        ///   The rasterizer.
        /// </value>
        IRasterizer Rasterizer { get; }

        void Clear(Color color, float depth = 1.0f, int stencil = 0);

        void DrawIndices(PrimitiveTopology topology, int first, int count);
    }
}