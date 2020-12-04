// <copyright file="OpenGLInputLayoutTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL.Buffers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL.Buffers;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    public class OpenGLInputLayoutTests
    {
        private readonly List<InputElement> elements = new List<InputElement>()
        {
            new InputElement(0, 3, InputElementType.Float, 0),
            new InputElement(1, 4, InputElementType.Byte, 12),
            new InputElement(2, 3, InputElementType.Short, 28),
            new InputElement(3, 3, InputElementType.Double, 22),
            new InputElement(4, 5, InputElementType.Int, 121),
        };

        private OpenGLInputLayout inputLayout;

        private Mock<IOpenGLInvoker> invoker;

        [Test]
        public void BindShouldInvokeEnableVertexAttribArrayWhenInvoked()
        {
            // Act
            this.inputLayout.Bind();

            // Assert
            this.invoker.Verify(x => x.EnableVertexAttribArray(It.IsAny<int>()), Times.Exactly(this.elements.Count));
        }

        [Test]
        public void BindShouldInvokeVertexAttribBindingWhenInvoked()
        {
            // Act
            this.inputLayout.Bind();

            // Assert
            this.invoker.Verify(x => x.VertexAttribBinding(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(this.elements.Count));
        }

        [Test]
        public void BindShouldInvokeVertexAttribFormatWhenInvoked()
        {
            // Act
            this.inputLayout.Bind();

            // Assert
            this.invoker.Verify(x => x.VertexAttribFormat(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<VertexAttribType>(), false, It.IsAny<int>()), Times.Exactly(this.elements.Count));
        }

        [Test]
        public void BindShouldThrowNotSupportedExceptionWhenInvalidEnumIsParameter()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(InputElementType), int.MaxValue));

            this.elements.Add(new InputElement()
            {
                Type = (InputElementType)int.MaxValue,
            });

            // Act and assert
            Assert.Throws<NotSupportedException>(() => this.inputLayout.Bind());
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenElementsIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLInputLayout(new Mock<IOpenGLInvoker>().Object, null));
        }

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLInputLayout(null, Enumerable.Empty<InputElement>()));
        }

        [Test]
        public void ResetShouldInvokeDisableVertexAttribArrayWhenInvoked()
        {
            // Act
            this.inputLayout.Reset();

            // Assert
            this.invoker.Verify(x => x.DisableVertexAttribArray(It.IsAny<int>()), Times.Exactly(this.elements.Count));
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.invoker = new Mock<IOpenGLInvoker>();
            this.inputLayout = new OpenGLInputLayout(this.invoker.Object, this.elements);
        }
    }
}