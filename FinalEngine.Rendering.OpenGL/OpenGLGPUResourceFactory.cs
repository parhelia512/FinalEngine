// <copyright file="OpenGLGPUResourceFactory.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.InteropServices;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.OpenGL.Pipeline;
    using FinalEngine.Rendering.OpenGL.Textures;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Rendering.Textures;
    using FinalEngine.Utilities;
    using OpenTK.Graphics.OpenGL4;
    using PixelFormat = FinalEngine.Rendering.Textures.PixelFormat;

    public class OpenGLGPUResourceFactory : IGPUResourceFactory
    {
        private readonly IOpenGLInvoker invoker;

        private readonly IEnumMapper mapper;

        public OpenGLGPUResourceFactory(IOpenGLInvoker invoker, IEnumMapper mapper)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
        }

        public IIndexBuffer CreateIndexBuffer<T>(T[] data, int sizeInBytes)
            where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), $"The specified {nameof(data)} parameter cannot be null.");
            }

            return new OpenGLIndexBuffer<T>(this.invoker, data, sizeInBytes);
        }

        public IInputLayout CreateInputLayout(IEnumerable<InputElement> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements), $"The specified {nameof(elements)} parameter cannot be null.");
            }

            return new OpenGLInputLayout(this.invoker, this.mapper, elements);
        }

        public IShader CreateShader(PipelineTarget target, string sourceCode)
        {
            if (string.IsNullOrWhiteSpace(sourceCode))
            {
                throw new ArgumentNullException(nameof(sourceCode), $"The specified {nameof(sourceCode)} parameter cannot be null, empty or contain only whitespace");
            }

            return new OpenGLShader(this.invoker, this.mapper, this.mapper.Forward<ShaderType>(target), sourceCode);
        }

        public IShaderProgram CreateShaderProgram(IEnumerable<IShader> shaders)
        {
            if (shaders == null)
            {
                throw new ArgumentNullException(nameof(shaders), $"The specified {nameof(shaders)} parameter cannot be null.");
            }

            return new OpenGLShaderProgram(this.invoker, shaders.Cast<IOpenGLShader>());
        }

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1011:Closing square brackets should be spaced correctly", Justification = "Conflicting with SA1018")]
        public ITexture2D CreateTexture2D<T>(Texture2DDescription description, T[]? data, PixelFormat format = PixelFormat.Rgba, SizedFormat internalFormat = SizedFormat.Rgba8)
        {
            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr ptr = data == null ? IntPtr.Zero : handle.AddrOfPinnedObject();

            var result = new OpenGLTexture2D(this.invoker, this.mapper, description, format, internalFormat, ptr);

            handle.Free();

            return result;
        }

        public IVertexBuffer CreateVertexBuffer<T>(T[] data, int sizeInBytes, int stride)
            where T : struct
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), $"The specified {nameof(data)} parameter cannot be null.");
            }

            return new OpenGLVertexBuffer<T>(this.invoker, data, sizeInBytes, stride);
        }
    }
}