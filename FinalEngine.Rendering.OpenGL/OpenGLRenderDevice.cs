// <copyright file="OpenGLRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using OpenTK.Graphics.OpenGL4;
    using BlendEquationMode = FinalEngine.Rendering.BlendEquationMode;
    using TKBlendEquationMode = OpenTK.Graphics.OpenGL4.BlendEquationMode;

    public class OpenGLRenderDevice : IRenderDevice
    {
        private readonly IOpenGLInvoker invoker;

        private readonly IEnumMapper mapper;

        public OpenGLRenderDevice(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");

            var map = new Dictionary<Enum, Enum>()
            {
                { PrimitiveTopology.Line, PrimitiveType.Lines },
                { PrimitiveTopology.LineStrip, PrimitiveType.LineStrip },
                { PrimitiveTopology.Triangle, PrimitiveType.Triangles },
                { PrimitiveTopology.TriangleStrip, PrimitiveType.TriangleStrip },
                { FaceCullMode.Back, CullFaceMode.Back },
                { FaceCullMode.Front, CullFaceMode.Front },
                { WindingDirection.Clockwise, FrontFaceDirection.Cw },
                { WindingDirection.CounterClockwise, FrontFaceDirection.Ccw },
                { RasterMode.Solid, PolygonMode.Fill },
                { RasterMode.Wireframe, PolygonMode.Line },
                { InputElementType.Byte, VertexAttribType.Byte },
                { InputElementType.Double, VertexAttribType.Double },
                { InputElementType.Float, VertexAttribType.Float },
                { InputElementType.Int, VertexAttribType.Int },
                { InputElementType.Short, VertexAttribType.Short },
                { PipelineTarget.Vertex, ShaderType.VertexShader },
                { PipelineTarget.Fragment, ShaderType.FragmentShader },
                { BlendEquationMode.Add, TKBlendEquationMode.FuncAdd },
                { BlendEquationMode.Max, TKBlendEquationMode.Max },
                { BlendEquationMode.Min, TKBlendEquationMode.Min },
                { BlendEquationMode.ReverseSubstract, TKBlendEquationMode.FuncReverseSubtract },
                { BlendEquationMode.Subtract, TKBlendEquationMode.FuncSubtract },
                { BlendMode.ConstantAlpha, BlendingFactor.ConstantAlpha },
                { BlendMode.DestinationAlpha, BlendingFactor.DstAlpha },
                { BlendMode.DestinationColor, BlendingFactor.DstColor },
                { BlendMode.One, BlendingFactor.One },
                { BlendMode.OneMinusConstantAlpha, BlendingFactor.OneMinusConstantAlpha },
                { BlendMode.OneMinusConstantColor, BlendingFactor.OneMinusConstantColor },
                { BlendMode.OneMinusDestinationAlpha, BlendingFactor.OneMinusDstAlpha },
                { BlendMode.OneMinusDestinationColor, BlendingFactor.OneMinusDstColor },
                { BlendMode.OneMinusSourceAlpha, BlendingFactor.OneMinusSrcAlpha },
                { BlendMode.OneMinusSourceColor, BlendingFactor.OneMinusSrcColor },
                { BlendMode.SourceAlpha, BlendingFactor.SrcAlpha },
                { BlendMode.SourceAlphaSaturate, BlendingFactor.SrcAlphaSaturate },
                { BlendMode.SourceColor, BlendingFactor.SrcColor },
                { BlendMode.Zero, BlendingFactor.Zero },
                { ComparisonMode.Always, All.Always },
                { ComparisonMode.Equal, All.Equal },
                { ComparisonMode.Greater, All.Greater },
                { ComparisonMode.GreaterEqual, All.Gequal },
                { ComparisonMode.Less, All.Less },
                { ComparisonMode.LessEqual, All.Lequal },
                { ComparisonMode.Never, All.Never },
                { StencilOperation.Decrement, StencilOp.Decr },
                { StencilOperation.DecrementWrap, StencilOp.DecrWrap },
                { StencilOperation.Increment, StencilOp.Incr },
                { StencilOperation.IncrementWrap, StencilOp.IncrWrap },
                { StencilOperation.Invert, StencilOp.Invert },
                { StencilOperation.Keep, StencilOp.Keep },
                { StencilOperation.Replace, StencilOp.Replace },
                { StencilOperation.Zero, StencilOp.Zero },
            };

            this.mapper = new EnumMapper(map);

            this.Rasterizer = new OpenGLRasterizer(invoker, this.mapper);
            this.Pipeline = new OpenGLPipeline(invoker);
            this.InputAssembler = new OpenGLInputAssembler();
            this.OutputMerger = new OpenGLOutputMerger(invoker, this.mapper);
            this.Factory = new OpenGLGPUResourceFactory(invoker, this.mapper);
        }

        public IGPUResourceFactory Factory { get; }

        public IInputAssembler InputAssembler { get; }

        public IOutputMerger OutputMerger { get; }

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
            this.invoker.DrawElements(this.mapper.Forward<PrimitiveType>(topology), count, DrawElementsType.UnsignedInt, first);
        }
    }
}