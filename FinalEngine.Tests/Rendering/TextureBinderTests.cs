// <copyright file="TextureBinderTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Textures;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public sealed class TextureBinderTests
    {
        private TextureBinder binder;

        private Mock<IPipeline> pipeline;

        private Mock<ITexture2D> texture;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenPipelineIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new TextureBinder(null));
        }

        [Test]
        public void GetTextureIDShouldInvokeResetAndReturnZeroWhen32TexturesHaveBeenAdded()
        {
            // Arrange
            for (int i = 0; i < 32; i++)
            {
                var texture = new Mock<ITexture2D>();
                this.binder.GetTextureID(texture.Object);
            }

            // Act
            int actual = this.binder.GetTextureID(this.texture.Object);

            // Assert
            Assert.Zero(actual);
        }

        [Test]
        public void GetTextureIDShouldInvokeSetTextureWhenInvoked()
        {
            // Act
            this.binder.GetTextureID(this.texture.Object);

            // Assert
            this.pipeline.Verify(x => x.SetTexture(this.texture.Object, 0), Times.Once);
        }

        [Test]
        public void GetTextureIDShouldInvokeSetUniformWhenInvoked()
        {
            // Act
            this.binder.GetTextureID(this.texture.Object);

            // Assert
            this.pipeline.Verify(x => x.SetUniform("u_textures[0]", 0), Times.Once);
        }

        [Test]
        public void GetTextureIDShouldReturnOneWhenTwoTexturesHaveBeenAdded()
        {
            // Arrange
            this.binder.GetTextureID(this.texture.Object);

            var texture2 = new Mock<ITexture2D>();
            this.binder.GetTextureID(texture2.Object);

            // Act
            int actual = this.binder.GetTextureID(texture2.Object);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GetTextureIDShouldThrowArgumentNullExceptionWhenTextureIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.binder.GetTextureID(null));
        }

        [SetUp]
        public void Setup()
        {
            this.pipeline = new Mock<IPipeline>();
            this.texture = new Mock<ITexture2D>();

            this.pipeline.SetupGet(x => x.MaxTextureSlots).Returns(32);

            this.binder = new TextureBinder(this.pipeline.Object);
        }

        [Test]
        public void ShouldResetShouldReturnFalseWhenMaxTextureSlotsIsGreaterThanZero()
        {
            // Arrange
            this.pipeline.SetupGet(x => x.MaxTextureSlots).Returns(32);

            // Act
            bool actual = this.binder.ShouldReset;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void ShouldResetShouldReturnTrueWhenMaxTextureSlotsIsLessThanZero()
        {
            // Arrange
            this.pipeline.SetupGet(x => x.MaxTextureSlots).Returns(-1);

            // Act
            bool actual = this.binder.ShouldReset;

            // Assert
            Assert.True(actual);
        }
    }
}