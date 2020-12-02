// <copyright file="OpenGLRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLRenderDevice : IRenderDevice
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLRenderDevice(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            this.Rasterizer = new OpenGLRasterizer(invoker);
            this.Pipeline = new OpenGLPipeline(invoker);
            this.InputAssembler = new OpenGLInputAssembler();
            this.Factory = new OpenGLGPUResourceFactory(invoker);
        }

        public IGPUResourceFactory Factory { get; }

        public IInputAssembler InputAssembler { get; }

        public IPipeline Pipeline { get; }

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
            PrimitiveType type = PrimitiveType.Triangles;

            switch (topology)
            {
                case PrimitiveTopology.Line:
                    type = PrimitiveType.Lines;
                    break;

                case PrimitiveTopology.LineStrip:
                    type = PrimitiveType.LineStrip;
                    break;

                case PrimitiveTopology.Triangle:
                    type = PrimitiveType.Triangles;
                    break;

                case PrimitiveTopology.TriangleStrip:
                    type = PrimitiveType.TriangleStrip;
                    break;
            }

            this.invoker.DrawElements(type, count, DrawElementsType.UnsignedInt, first);
        }
    }
}