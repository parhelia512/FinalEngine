// <copyright file="SpriteBatchTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.Textures;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class SpriteBatchTests
    {
        private Mock<IBatcher> batcher;

        private Mock<ITextureBinder> binder;

        private Mock<IGPUResourceFactory> factory;

        private Mock<IIndexBuffer> indexBuffer;

        private Mock<IInputAssembler> inputAssembler;

        private Mock<IInputLayout> inputLayout;

        private Mock<IRenderDevice> renderDevice;

        private SpriteBatch spriteBatch;

        private Mock<ITexture2D> texture;

        private Mock<IVertexBuffer> vertexBuffer;

        [Test]
        public void BeginShouldInvokeBatcherResetWhenInvoked()
        {
            // Act
            this.spriteBatch.Begin();

            // Assert
            this.batcher.Verify(x => x.Reset(), Times.Once);
        }

        [Test]
        public void BeginShouldInvokeBinderResetWhenInvoked()
        {
            // Act
            this.spriteBatch.Begin();

            // Assert
            this.binder.Verify(x => x.Reset(), Times.Once);
        }

        [Test]
        public void BeginShouldThrowObjectDisposedExceptionWhenDisposed()
        {
            // Arrange
            this.spriteBatch.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.spriteBatch.Begin());
        }

        [Test]
        public void ConstructorShouldInvokeCreateIndexBufferWhenInvoked()
        {
            // Arrange
            int[] indices = new int[this.batcher.Object.MaxIndexCount];

            int offset = 0;

            for (int i = 0; i < this.batcher.Object.MaxIndexCount; i += 6)
            {
                indices[i] = offset;
                indices[i + 1] = 1 + offset;
                indices[i + 2] = 2 + offset;

                indices[i + 3] = 2 + offset;
                indices[i + 4] = 3 + offset;
                indices[i + 5] = 0 + offset;

                offset += 4;
            }

            // Assert
            this.factory.Verify(x => x.CreateIndexBuffer(BufferUsageType.Static, indices, indices.Length * sizeof(int)));
        }

        [Test]
        public void ConstructorShouldInvokeCreateInputLayoutWhenInvoked()
        {
            // Assert
            this.factory.Verify(x => x.CreateInputLayout(
                new InputElement[]
                {
                    new InputElement(0, 2, InputElementType.Float, 0),
                    new InputElement(1, 4, InputElementType.Float, 2 * sizeof(float)),
                    new InputElement(2, 2, InputElementType.Float, 6 * sizeof(float)),
                    new InputElement(3, 1, InputElementType.Float, 8 * sizeof(float)),
                }));
        }

        [Test]
        public void ConstructorShouldInvokeCreateVertexBufferWhenInvoked()
        {
            // Assert
            this.factory.Verify(x => x.CreateVertexBuffer(BufferUsageType.Dynamic, Array.Empty<Vertex>(), 12 * Vertex.SizeInBytes, Vertex.SizeInBytes));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenBatcherIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new SpriteBatch(this.renderDevice.Object, null, this.binder.Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenBinderIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new SpriteBatch(this.renderDevice.Object, this.batcher.Object, null));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenRenderDeviceIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new SpriteBatch(null, this.batcher.Object, this.binder.Object));
        }

        [Test]
        public void DrawShouldInvokeBatcherWhenBatcherShouldReset()
        {
            // Arrange
            this.batcher.SetupGet(x => x.ShouldReset).Returns(true);

            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.batcher.Verify(x => x.Batch(34, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeBatcherWhenBinderShouldReset()
        {
            // Arrange
            this.binder.SetupGet(x => x.ShouldReset).Returns(true);

            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.batcher.Verify(x => x.Batch(34, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeBatchWhenInvoked()
        {
            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.batcher.Verify(x => x.Batch(34, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeBinderWhenBatcherShouldReset()
        {
            // Arrange
            this.batcher.SetupGet(x => x.ShouldReset).Returns(true);

            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.binder.Verify(x => x.GetTextureID(this.texture.Object), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeBinderWhenBinderShouldReset()
        {
            // Arrange
            this.binder.SetupGet(x => x.ShouldReset).Returns(true);

            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.binder.Verify(x => x.GetTextureID(this.texture.Object), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeGetTextureIDWhenInvoked()
        {
            // Act
            this.spriteBatch.Draw(this.texture.Object, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Assert
            this.binder.Verify(x => x.GetTextureID(this.texture.Object), Times.Once);
        }

        [Test]
        public void DrawShouldThrowArgumentNullExceptionWhenTextureIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.spriteBatch.Draw(null, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero));
        }

        [Test]
        public void DrawShouldThrowObjectDisposedExceptionWhenDisposed()
        {
            // Arrange
            this.spriteBatch.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.spriteBatch.Draw(Mock.Of<ITexture2D>(), Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero));
        }

        [Test]
        public void EndShouldInvokeProcessBatchWhenInvoked()
        {
            // Act
            this.spriteBatch.End();

            // Assert
            this.batcher.Verify(x => x.ProcessBatch(this.vertexBuffer.Object));
        }

        [Test]
        public void EndShouldThrowObjectDisposedExceptionWhenDisposed()
        {
            // Arrange
            this.spriteBatch.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.spriteBatch.End());
        }

        [Test]
        public void FlushShouldInvokeDrawIndicesWhenInvoked()
        {
            // Act
            this.spriteBatch.Flush();

            // Assert
            this.renderDevice.Verify(x => x.DrawIndices(PrimitiveTopology.Triangle, 0, this.indexBuffer.Object.Length));
        }

        [Test]
        public void FlushShouldInvokeSetIndexBufferWhenInvoked()
        {
            // Act
            this.spriteBatch.Flush();

            // Assert
            this.inputAssembler.Verify(x => x.SetIndexBuffer(this.indexBuffer.Object), Times.Once);
        }

        [Test]
        public void FlushShouldInvokeSetInputLayoutWhenInvoked()
        {
            // Act
            this.spriteBatch.Flush();

            // Assert
            this.inputAssembler.Verify(x => x.SetInputLayout(this.inputLayout.Object), Times.Once);
        }

        [Test]
        public void FlushShouldInvokeSetVertexBufferWhenInvoked()
        {
            // Act
            this.spriteBatch.Flush();

            // Assert
            this.inputAssembler.Verify(x => x.SetVertexBuffer(this.vertexBuffer.Object), Times.Once);
        }

        [Test]
        public void FlushShouldThrowObjectDisposedExceptionWhenDisposed()
        {
            // Arrange
            this.spriteBatch.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.spriteBatch.Flush());
        }

        [SetUp]
        public void Setup()
        {
            this.renderDevice = new Mock<IRenderDevice>();

            this.factory = new Mock<IGPUResourceFactory>();

            this.vertexBuffer = new Mock<IVertexBuffer>();
            this.indexBuffer = new Mock<IIndexBuffer>();
            this.inputLayout = new Mock<IInputLayout>();

            this.factory.Setup(x => x.CreateVertexBuffer(BufferUsageType.Dynamic, Array.Empty<Vertex>(), It.IsAny<int>(), It.IsAny<int>())).Returns(this.vertexBuffer.Object);
            this.factory.Setup(x => x.CreateIndexBuffer(BufferUsageType.Static, It.IsAny<int[]>(), It.IsAny<int>())).Returns(this.indexBuffer.Object);
            this.factory.Setup(x => x.CreateInputLayout(It.IsAny<InputElement[]>())).Returns(this.inputLayout.Object);

            this.renderDevice.SetupGet(x => x.Factory).Returns(this.factory.Object);

            this.inputAssembler = new Mock<IInputAssembler>();

            this.renderDevice.SetupGet(x => x.InputAssembler).Returns(this.inputAssembler.Object);

            this.batcher = new Mock<IBatcher>();
            this.batcher.SetupGet(x => x.MaxVertexCount).Returns(12);
            this.batcher.SetupGet(x => x.MaxIndexCount).Returns(18);

            this.binder = new Mock<ITextureBinder>();
            this.binder.Setup(x => x.GetTextureID(It.IsAny<ITexture2D>())).Returns(34);

            this.texture = new Mock<ITexture2D>();

            this.spriteBatch = new SpriteBatch(this.renderDevice.Object, this.batcher.Object, this.binder.Object);
        }

        [TearDown]
        public void Teardown()
        {
            this.spriteBatch.Dispose();
        }
    }
}