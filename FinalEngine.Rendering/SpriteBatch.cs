// <copyright file="SpriteBatch.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.Textures;

    public class SpriteBatch : ISpriteBatch, IDisposable
    {
        private readonly IBatcher batcher;

        private readonly ITextureBinder binder;

        private readonly IInputLayout inputLayout;

        private readonly IRenderDevice renderDevice;

        private IIndexBuffer? indexBuffer;

        private IVertexBuffer? vertexBuffer;

        public SpriteBatch(IRenderDevice renderDevice, IBatcher batcher, ITextureBinder binder)
        {
            this.renderDevice = renderDevice ?? throw new ArgumentNullException(nameof(renderDevice), $"The specified {nameof(renderDevice)} parameter cannot be null.");
            this.batcher = batcher ?? throw new ArgumentNullException(nameof(batcher), $"The specified {nameof(batcher)} parameter cannot be null.");
            this.binder = binder ?? throw new ArgumentNullException(nameof(binder), $"The specified {nameof(binder)} parameter cannot be null.");

            this.inputLayout = renderDevice.Factory.CreateInputLayout(
                new InputElement[]
                {
                    new InputElement(0, 2, InputElementType.Float, 0),
                    new InputElement(1, 4, InputElementType.Float, 2 * sizeof(float)),
                    new InputElement(2, 2, InputElementType.Float, 6 * sizeof(float)),
                    new InputElement(3, 1, InputElementType.Float, 8 * sizeof(float)),
                });

            this.vertexBuffer = renderDevice.Factory.CreateVertexBuffer(
                BufferUsageType.Dynamic,
                Array.Empty<Vertex>(),
                batcher.MaxVertexCount * Vertex.SizeInBytes,
                Vertex.SizeInBytes);

            int[] indices = new int[batcher.MaxIndexCount];

            int offset = 0;

            for (int i = 0; i < batcher.MaxIndexCount; i += 6)
            {
                indices[i] = offset;
                indices[i + 1] = 1 + offset;
                indices[i + 2] = 2 + offset;

                indices[i + 3] = 2 + offset;
                indices[i + 4] = 3 + offset;
                indices[i + 5] = 0 + offset;

                offset += 4;
            }

            this.indexBuffer = renderDevice.Factory.CreateIndexBuffer(
                BufferUsageType.Static,
                indices,
                indices.Length * sizeof(int));
        }

        ~SpriteBatch()
        {
            this.Dispose(false);
        }

        protected bool IsDisposed { get; private set; }

        public void Begin()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(SpriteBatch));
            }

            this.batcher.Reset();
            this.binder.Reset();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Draw(ITexture2D texture, Color color, Vector2 origin, Vector2 position, float rotation, Vector2 scale)
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(nameof(SpriteBatch));
            }

            if (texture == null)
            {
                throw new ArgumentNullException(nameof(texture), $"The specified {nameof(texture)} parameter cannot be null.");
            }

            if (this.batcher.ShouldReset || this.binder.ShouldReset)
            {
                this.End();
                this.Flush();
                this.Begin();
            }

            float textureID = this.binder.GetTextureID(texture);
            this.batcher.Batch(textureID, color, origin, position, rotation, scale);
        }

        public void End()
        {
            if (this.IsDisposed || this.vertexBuffer == null)
            {
                throw new ObjectDisposedException(nameof(SpriteBatch));
            }

            this.batcher.ProcessBatch(this.vertexBuffer);
        }

        public void Flush()
        {
            if (this.IsDisposed || this.indexBuffer == null)
            {
                throw new ObjectDisposedException(nameof(SpriteBatch));
            }

            this.renderDevice.InputAssembler.SetInputLayout(this.inputLayout);
            this.renderDevice.InputAssembler.SetVertexBuffer(this.vertexBuffer);
            this.renderDevice.InputAssembler.SetIndexBuffer(this.indexBuffer);

            this.renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, this.indexBuffer.Length);
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