// <copyright file="InputElementTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.Buffers
{
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering.Buffers;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class InputElementTests
    {
        private const int Index = 234;

        private const int RelativeOffset = 304;

        private const int Size = 432;

        private const InputElementType Type = InputElementType.Float;

        private InputElement element;

        [Test]
        public void ConstructorShouldSetIndexToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.Index;

            // Assert
            Assert.AreEqual(Index, actual);
        }

        [Test]
        public void ConstructorShouldSetRelativeOffsetToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.RelativeOffset;

            // Assert
            Assert.AreEqual(RelativeOffset, actual);
        }

        [Test]
        public void ConstructorShouldSetSizeToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.Size;

            // Assert
            Assert.AreEqual(Size, actual);
        }

        [Test]
        public void ConstructorShouldSetTypeToParameterWhenInvoked()
        {
            // Act
            InputElementType actual = this.element.Type;

            // Assert
            Assert.AreEqual(Type, actual);
        }

        [SetUp]
        public void Setup()
        {
            // Arrange
            this.element = new InputElement(Index, Size, Type, RelativeOffset);
        }
    }
}