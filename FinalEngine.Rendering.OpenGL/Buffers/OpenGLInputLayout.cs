// <copyright file="OpenGLInputLayout.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System;
    using System.Collections.Generic;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLInputLayout : IOpenGLInputLayout
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLInputLayout(IOpenGLInvoker invoker, IEnumerable<InputElement> elements)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
            this.Elements = elements ?? throw new ArgumentNullException(nameof(elements));
        }

        public IEnumerable<InputElement> Elements { get; }

        public void Bind()
        {
            foreach (InputElement element in this.Elements)
            {
                this.invoker.VertexAttribFormat(element.Index, element.Size, GetVertexAttribType(element.Type), false, element.RelativeOffset);
                this.invoker.VertexAttribBinding(element.Index, 0);
                this.invoker.EnableVertexAttribArray(element.Index);
            }
        }

        public void Reset()
        {
            foreach (InputElement element in this.Elements)
            {
                this.invoker.DisableVertexAttribArray(element.Index);
            }
        }

        private static VertexAttribType GetVertexAttribType(InputElementType type)
        {
            switch (type)
            {
                case InputElementType.Byte:
                    return VertexAttribType.Byte;

                case InputElementType.Double:
                    return VertexAttribType.Double;

                case InputElementType.Float:
                    return VertexAttribType.Float;

                case InputElementType.Int:
                    return VertexAttribType.Int;

                case InputElementType.Short:
                    return VertexAttribType.Short;

                default:
                    throw new NotSupportedException($"The specified {nameof(type)} is not supported by the OpenGL Backend.");
            }
        }
    }
}