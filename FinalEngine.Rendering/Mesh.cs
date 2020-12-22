// <copyright file="Mesh.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Collections.Generic;
    using FinalEngine.Rendering.Buffers;

    public class Mesh : IMesh
    {
        private static readonly IEnumerable<InputElement> InputElements = new List<InputElement>()
        {
            new InputElement(0, 3, InputElementType.Float, Vertex.PositionRelativeOffset),
            new InputElement(1, 4, InputElementType.Float, Vertex.ColorRelativeOffset),
            new InputElement(2, 2, InputElementType.Float, Vertex.TextureCoordinateRelativeOffset),
        };

        private readonly IIndexBuffer indexBuffer;

        private readonly IInputLayout inputLayout;

        private readonly IVertexBuffer vertexBuffer;

        public Mesh(IGPUResourceFactory factory, Vertex[] vertices, int[] indices)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory), $"The specified {nameof(factory)} parameter cannot be null.");
            }

            if (vertices == null)
            {
                throw new ArgumentNullException(nameof(vertices), $"The specified {nameof(vertices)} parameter cannot be null.");
            }

            if (indices == null)
            {
                throw new ArgumentNullException(nameof(indices), $"The specified {nameof(indices)} parameter cannot be null.");
            }

            this.inputLayout = factory.CreateInputLayout(InputElements);
            this.vertexBuffer = factory.CreateVertexBuffer(vertices, vertices.Length * Vertex.SizeInBytes, Vertex.SizeInBytes);
            this.indexBuffer = factory.CreateIndexBuffer(indices, indices.Length * sizeof(int));
        }

        ~Mesh()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Draw(IRenderDevice renderDevice)
        {
            if (renderDevice == null)
            {
                throw new ArgumentNullException(nameof(renderDevice), $"The specified {nameof(renderDevice)} parameter cannot be null.");
            }

            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(Mesh));
            }

            renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, this.indexBuffer.Length);
        }

        public void SetBuffers(IInputAssembler inputAssembler)
        {
            if (inputAssembler == null)
            {
                throw new ArgumentNullException(nameof(inputAssembler), $"The specified {nameof(inputAssembler)} parameter cannot be null.");
            }

            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(Mesh));
            }

            inputAssembler.SetInputLayout(this.inputLayout);
            inputAssembler.SetVertexBuffer(this.vertexBuffer);
            inputAssembler.SetIndexBuffer(this.indexBuffer);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                this.indexBuffer.Dispose();
                this.vertexBuffer.Dispose();
            }

            this.IsDisposed = true;
        }
    }
}