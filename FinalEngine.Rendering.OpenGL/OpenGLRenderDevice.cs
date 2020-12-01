// <copyright file="OpenGLRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
    using FinalEngine.Rendering.OpenGL.Extensions;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLRenderDevice : IRenderDevice
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLRenderDevice(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));

            this.Rasterizer = new OpenGLRasterizer(invoker);
        }

        public IRasterizer Rasterizer { get; }

        public void Clear(Color color, float depth = 1, int stencil = 0)
        {
            this.invoker.ClearColor(color);
            this.invoker.ClearDepth(depth);
            this.invoker.ClearStencil(stencil);
            this.invoker.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        }

        public void DrawIndices(PrimitiveTopology topology, int first, int count)
        {
            this.invoker.DrawElements(topology.ToOpenTK(), count, DrawElementsType.UnsignedInt, first);
        }
    }
}