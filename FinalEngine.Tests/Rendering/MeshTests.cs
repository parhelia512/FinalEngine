// <copyright file="MeshTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Buffers;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class MeshTests
    {
        private const int Length = 465;

        private readonly IEnumerable<InputElement> inputElements = new List<InputElement>()
            {
                new InputElement(0, 3, InputElementType.Float, Marshal.OffsetOf<Vertex>("position").ToInt32()),
                new InputElement(1, 4, InputElementType.Float, Marshal.OffsetOf<Vertex>("color").ToInt32()),
                new InputElement(2, 2, InputElementType.Float, Marshal.OffsetOf<Vertex>("textureCoordinate").ToInt32()),
            };

        private Mock<IGPUResourceFactory> factory;

        private Mock<IIndexBuffer> indexBuffer;

        private int[] indices;

        private Mock<IInputAssembler> inputAssembler;

        private Mock<IInputLayout> inputLayout;

        private Mesh mesh;

        private Mock<IRenderDevice> renderDevice;

        private Mock<IVertexBuffer> vertexBuffer;

        private Vertex[] vertices;

        [Test]
        public void ConstructorShouldInvokeCreateIndexBufferWhenInvoked()
        {
            // Assert
            this.factory.Verify(x => x.CreateIndexBuffer(this.indices, this.indices.Length * sizeof(int)), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeCreateInputLayoutWhenInvoked()
        {
            // Assert
            this.factory.Verify(x => x.CreateInputLayout(this.inputElements), Times.Once);
        }

        [Test]
        public void ConstructorShouldInvokeCreateVertexBufferWhenInvoked()
        {
            // Assert
            this.factory.Verify(x => x.CreateVertexBuffer(this.vertices, this.vertices.Length * Vertex.SizeInBytes, Vertex.SizeInBytes), Times.Once);
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenFactoryIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new Mesh(null, Array.Empty<Vertex>(), Array.Empty<int>()));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenIndicesIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new Mesh(this.factory.Object, Array.Empty<Vertex>(), null));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenVerticesIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new Mesh(this.factory.Object, null, Array.Empty<int>()));
        }

        [Test]
        public void DisposeShouldInvokeIndexBufferDisposeWhenNotDisposed()
        {
            // Act
            this.mesh.Dispose();

            // Assert
            this.indexBuffer.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void DisposeShouldInvokeVertexBufferDisposeWhenNotDisposed()
        {
            // Act
            this.mesh.Dispose();

            // Assert
            this.vertexBuffer.Verify(x => x.Dispose(), Times.Once);
        }

        [Test]
        public void DrawShouldInvokeDrawIndicesWhenInvoked()
        {
            // Act
            this.mesh.Draw(this.renderDevice.Object);

            // Assert
            this.renderDevice.Verify(x => x.DrawIndices(PrimitiveTopology.Triangle, 0, this.indexBuffer.Object.Length), Times.Once);
        }

        [Test]
        public void DrawShouldThrowArgumentNullExceptionWhenRenderDeviceIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.mesh.Draw(null));
        }

        [Test]
        public void DrawShouldThrowObjectDisposedExceptionWhenMeshIsDisposed()
        {
            // Arrange
            this.mesh.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.mesh.Draw(this.renderDevice.Object));
        }

        [Test]
        public void SetBuffersShouldInvokeSetIndexBufferWhenInvoked()
        {
            // Act
            this.mesh.SetBuffers(this.inputAssembler.Object);

            // Assert
            this.inputAssembler.Verify(x => x.SetIndexBuffer(this.indexBuffer.Object), Times.Once);
        }

        [Test]
        public void SetBuffersShouldInvokeSetInputLayoutWhenInvoked()
        {
            // Act
            this.mesh.SetBuffers(this.inputAssembler.Object);

            // Assert
            this.inputAssembler.Verify(x => x.SetInputLayout(this.inputLayout.Object), Times.Once);
        }

        [Test]
        public void SetBuffersShouldInvokeSetVertexBufferWhenInvoked()
        {
            // Act
            this.mesh.SetBuffers(this.inputAssembler.Object);

            // Assert
            this.inputAssembler.Verify(x => x.SetVertexBuffer(this.vertexBuffer.Object), Times.Once);
        }

        [Test]
        public void SetBuffersShouldThrowArgumentNullExceptionWhenInputAssemblerIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.mesh.SetBuffers(null));
        }

        [Test]
        public void SetBuffersShouldThrowObjectDisposedExceptionWhenMeshIsDisposed()
        {
            // Arrange
            this.mesh.Dispose();

            // Act and assert
            Assert.Throws<ObjectDisposedException>(() => this.mesh.SetBuffers(this.inputAssembler.Object));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.factory = new Mock<IGPUResourceFactory>();

            this.vertices = Array.Empty<Vertex>();
            this.indices = Array.Empty<int>();

            this.vertexBuffer = new Mock<IVertexBuffer>();

            this.indexBuffer = new Mock<IIndexBuffer>();
            this.indexBuffer.SetupGet(x => x.Length).Returns(Length);

            this.renderDevice = new Mock<IRenderDevice>();
            this.inputAssembler = new Mock<IInputAssembler>();

            this.inputLayout = new Mock<IInputLayout>();

            this.factory.Setup(x => x.CreateVertexBuffer(this.vertices, this.vertices.Length * Vertex.SizeInBytes, Vertex.SizeInBytes)).Returns(this.vertexBuffer.Object);
            this.factory.Setup(x => x.CreateIndexBuffer(this.indices, this.indices.Length * sizeof(int))).Returns(this.indexBuffer.Object);
            this.factory.Setup(x => x.CreateInputLayout(this.inputElements)).Returns(this.inputLayout.Object);

            this.mesh = new Mesh(this.factory.Object, this.vertices, this.indices);
        }

        [TearDown]
        public void Teardown()
        {
            this.mesh.Dispose();
        }
    }
}