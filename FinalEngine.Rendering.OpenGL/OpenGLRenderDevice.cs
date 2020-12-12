// <copyright file="OpenGLRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Rendering.Textures;
    using OpenTK.Graphics.OpenGL4;
    using BlendEquationMode = FinalEngine.Rendering.BlendEquationMode;
    using TextureWrapMode = FinalEngine.Rendering.Textures.TextureWrapMode;
    using TKBlendEquationMode = OpenTK.Graphics.OpenGL4.BlendEquationMode;

    public class OpenGLRenderDevice : IRenderDevice
    {
        private readonly IGPUResourceFactory factory;

        private readonly IInputAssembler inputAssembler;

        private readonly IOpenGLInvoker invoker;

        private readonly IEnumMapper mapper;

        private readonly IOutputMerger outputMerger;

        private readonly IPipeline pipeline;

        private readonly IRasterizer rasterizer;

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
                { TextureFilterMode.Linear, All.Linear },
                { TextureFilterMode.Nearest, All.Nearest },
                { TextureWrapMode.Clamp, All.ClampToEdge },
                { TextureWrapMode.Repeat, All.Repeat },
            };

            this.mapper = new EnumMapper(map);

            this.inputAssembler = new OpenGLInputAssembler();
            this.pipeline = new OpenGLPipeline(invoker);
            this.rasterizer = new OpenGLRasterizer(invoker, this.mapper);
            this.outputMerger = new OpenGLOutputMerger(invoker, this.mapper);
            this.factory = new OpenGLGPUResourceFactory(invoker, this.mapper);
        }

        public void Clear(Color color, float depth = 1, int stencil = 0)
        {
            this.invoker.ClearColor(color);
            this.invoker.ClearDepth(depth);
            this.invoker.ClearStencil(stencil);
            this.invoker.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        }

        public IIndexBuffer CreateIndexBuffer<T>(T[] data, int sizeInBytes)
            where T : struct
        {
            return this.factory.CreateIndexBuffer(data, sizeInBytes);
        }

        public IInputLayout CreateInputLayout(IEnumerable<InputElement> elements)
        {
            return this.factory.CreateInputLayout(elements);
        }

        public IShader CreateShader(PipelineTarget target, string sourceCode)
        {
            return this.factory.CreateShader(target, sourceCode);
        }

        public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders)
        {
            return this.factory.CreateShaderProgram(shaders);
        }

        public IVertexBuffer CreateVertexBuffer<T>(T[] data, int sizeInBytes, int stride) where T : struct
        {
            return this.factory.CreateVertexBuffer(data, sizeInBytes, stride);
        }

        public void DrawIndices(PrimitiveTopology topology, int first, int count)
        {
            this.invoker.DrawElements(this.mapper.Forward<PrimitiveType>(topology), count, DrawElementsType.UnsignedInt, first);
        }

        public void SetBlendState(BlendStateDescription description)
        {
            this.outputMerger.SetBlendState(description);
        }

        public void SetDepthState(DepthStateDescription description)
        {
            this.outputMerger.SetDepthState(description);
        }

        public void SetIndexBuffer(IIndexBuffer buffer)
        {
            this.inputAssembler.SetIndexBuffer(buffer);
        }

        public void SetInputLayout(IInputLayout layout)
        {
            this.inputAssembler.SetInputLayout(layout);
        }

        public void SetRasterState(RasterStateDescription description)
        {
            this.rasterizer.SetRasterState(description);
        }

        public void SetScissor(Rectangle rectangle)
        {
            this.rasterizer.SetScissor(rectangle);
        }

        public void SetShaderProgram(IShaderProgram? program)
        {
            this.pipeline.SetShaderProgram(program);
        }

        public void SetStencilState(StencilStateDescription description)
        {
            this.outputMerger.SetStencilState(description);
        }

        public void SetUniform(string name, int value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, float value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, double value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, bool value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, Vector2 value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, Vector3 value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, Vector4 value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetUniform(string name, Matrix4x4 value)
        {
            this.pipeline.SetUniform(name, value);
        }

        public void SetVertexBuffer(IVertexBuffer buffer)
        {
            this.inputAssembler.SetVertexBuffer(buffer);
        }

        public void SetViewport(Rectangle rectangle, float near = 0, float far = 1)
        {
            this.rasterizer.SetViewport(rectangle, near, far);
        }
    }
}