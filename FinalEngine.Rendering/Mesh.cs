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
        private readonly IInputLayout inputLayout;

        private readonly IMaterial material;

        private IIndexBuffer? indexBuffer;

        private IVertexBuffer? vertexBuffer;

        public Mesh(IGPUResourceFactory factory, IReadOnlyCollection<Vertex> vertices, IReadOnlyCollection<int> indices, IMaterial material)
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

            this.material = material ?? throw new ArgumentNullException(nameof(material), $"The specified {nameof(material)} parameter cannot be null.");

            this.inputLayout = factory.CreateInputLayout(
                new InputElement[]
                {
                    new InputElement(0, 3, InputElementType.Float, 0),
                    new InputElement(1, 4, InputElementType.Float, 3 * sizeof(float)),
                    new InputElement(2, 2, InputElementType.Float, 7 * sizeof(float)),
                });

            this.vertexBuffer = factory.CreateVertexBuffer(
                BufferUsageType.Static,
                vertices,
                vertices.Count * Vertex.SizeInBytes,
                Vertex.SizeInBytes);

            this.indexBuffer = factory.CreateIndexBuffer(
                BufferUsageType.Static,
                indices,
                indices.Count * sizeof(int));
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
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(Mesh));
            }

            if (renderDevice == null)
            {
                throw new ArgumentNullException(nameof(renderDevice), $"The specified {nameof(renderDevice)} parameter cannot be null.");
            }

            this.material.Set(renderDevice.Pipeline);

            renderDevice.InputAssembler.SetInputLayout(this.inputLayout);
            renderDevice.InputAssembler.SetVertexBuffer(this.vertexBuffer);
            renderDevice.InputAssembler.SetIndexBuffer(this.indexBuffer);

            renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, this.indexBuffer?.Length ?? 0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (this.indexBuffer != null)
                {
                    this.indexBuffer.Dispose();
                    this.indexBuffer = null;
                }

                if (this.vertexBuffer != null)
                {
                    this.vertexBuffer.Dispose();
                    this.vertexBuffer = null;
                }
            }

            this.IsDisposed = true;
        }
    }
}