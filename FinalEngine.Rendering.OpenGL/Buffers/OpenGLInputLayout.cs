// <copyright file="OpenGLInputLayout.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Buffers
{
    using System;
    using System.Collections.Generic;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Utilities;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLInputLayout : IOpenGLInputLayout
    {
        private readonly IOpenGLInvoker invoker;

        private readonly IEnumMapper mapper;

        public OpenGLInputLayout(IOpenGLInvoker invoker, IEnumMapper mapper, IReadOnlyCollection<InputElement> elements)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified {nameof(invoker)} parameter cannot be null.");
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), $"The specified {nameof(mapper)} parameter cannot be null.");
            this.Elements = elements ?? throw new ArgumentNullException(nameof(elements), $"The specified {nameof(elements)} parameter cannot be null.");
        }

        public IEnumerable<InputElement> Elements { get; }

        public void Bind()
        {
            foreach (InputElement element in this.Elements)
            {
                this.invoker.VertexAttribFormat(element.Index, element.Size, this.mapper.Forward<VertexAttribType>(element.Type), false, element.RelativeOffset);
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
    }
}