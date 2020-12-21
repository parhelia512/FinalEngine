// <copyright file="ImageSharpTexture2DLoaderTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.Loading
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using FinalEngine.IO;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Loading;
    using Moq;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "This is done in TearDown.")]
    public class ImageSharpTexture2DLoaderTests
    {
        // This is a real and physical location on disk.
        private const string Path = "Resources\\Textures\\default.png";

        private Mock<IGPUResourceFactory> factory;

        private Mock<IFileSystem> fileSystem;

        private ImageSharpTexture2DLoader loader;

        private Stream stream;

        [Test]
        public void ConstructorShouldThrowArgumentNulLExceptionWhenFactoryIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new ImageSharpTexture2DLoader(null, this.fileSystem.Object));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenFileSystemIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new ImageSharpTexture2DLoader(this.factory.Object, null));
        }

        [Test]
        public void LoadTexture2DShouldInvokeOpenFileReadAccessWhenInvoked()
        {
            // Act
            this.loader.LoadTexture2D(Path);

            // Assert
            this.fileSystem.Verify(x => x.OpenFile(Path, FileAccessMode.Read), Times.Once);
        }

        [Test]
        public void LoadTexture2DShouldThrowArgumentNullExceptionWhenPathIsEmpty()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.loader.LoadTexture2D(string.Empty));
        }

        [Test]
        public void LoadTexture2DShouldThrowArgumentNullExceptionWhenPathIsNull()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.loader.LoadTexture2D(null));
        }

        [Test]
        public void LoadTexture2DShouldThrowArgumentNullExceptionWhenPathIsWhitespace()
        {
            // Act and assert
            Assert.Throws<ArgumentNullException>(() => this.loader.LoadTexture2D("\r\t\n"));
        }

        [Test]
        public void LoadTexture2DShouldThrowFileNotFoundExceptionWhenFileDoesntExist()
        {
            // Arrange
            this.fileSystem.Setup(x => x.FileExists(Path)).Returns(false);

            // Act and assert
            Assert.Throws<FileNotFoundException>(() => this.loader.LoadTexture2D(Path));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.factory = new Mock<IGPUResourceFactory>();
            this.fileSystem = new Mock<IFileSystem>();

            this.stream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read);

            this.fileSystem.Setup(x => x.FileExists(Path)).Returns(true);
            this.fileSystem.Setup(x => x.OpenFile(Path, FileAccessMode.Read)).Returns(this.stream);

            this.loader = new ImageSharpTexture2DLoader(this.factory.Object, this.fileSystem.Object);
        }

        [TearDown]
        public void Teardown()
        {
            this.stream.Dispose();
        }
    }
}