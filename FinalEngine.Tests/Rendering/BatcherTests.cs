// <copyright file="BatcherTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Buffers;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class BatcherTests
    {
        private Batcher batcher;

        private Mock<IInputAssembler> inputAssembler;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInputAssemblerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new Batcher(null, 1));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenMaxCapacityIsEqualToZero()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Batcher(Mock.Of<IInputAssembler>(), 0));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenMaxCapacityIsLessThanZero()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Batcher(Mock.Of<IInputAssembler>(), -1));
        }

        [Test]
        public void ProcessBatchShouldInvokeUpdateVertexBufferWhenInvoked()
        {
            // Arrange
            var vertexBuffer = new Mock<IVertexBuffer>();

            // Act
            this.batcher.ProcessBatch(vertexBuffer.Object);

            // Assert
            this.inputAssembler.Verify(x => x.UpdateVertexBuffer(vertexBuffer.Object, It.IsAny<IReadOnlyCollection<Vertex>>(), Vertex.SizeInBytes));
        }

        [Test]
        public void ProcessBatchShouldThrowArgumentNullExceptionWhenVertexBufferIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.batcher.ProcessBatch(null));
        }

        [SetUp]
        public void Setup()
        {
            this.inputAssembler = new Mock<IInputAssembler>();
            this.batcher = new Batcher(this.inputAssembler.Object, 12);
        }

        [Test]
        public void ShouldResetShouldReturnFalseWhenBatchCalledMoreThanTwelveTimes()
        {
            // Arrange
            for (int i = 0; i < 12; i++)
            {
                this.batcher.Batch(0, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);
            }

            // Act
            this.batcher.Batch(0, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);

            // Yuck
            Assert.False(this.batcher.ShouldReset);
        }

        [Test]
        public void ShouldResetShouldReturnFalseWhenBatchIsNotCalled()
        {
            // Act
            bool actual = this.batcher.ShouldReset;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void ShouldResetShouldReturnTrueWhenBatchIsCalledTwelveTimes()
        {
            // Arrange
            for (int i = 0; i < 12; i++)
            {
                this.batcher.Batch(0, Color.White, Vector2.Zero, Vector2.Zero, 0, Vector2.Zero);
            }

            // Act
            bool actual = this.batcher.ShouldReset;

            // Assert
            Assert.True(actual);
        }
    }
}