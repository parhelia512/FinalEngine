// <copyright file="InputElementTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.Buffers
{
    using FinalEngine.Rendering.Buffers;
    using NUnit.Framework;

    public class InputElementTests
    {
        private InputElement element;

        [Test]
        public void ConstructorShouldSetIndexToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.Index;

            // Assert
            Assert.AreEqual(234, actual);
        }

        [Test]
        public void ConstructorShouldSetRelativeOffsetToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.RelativeOffset;

            // Assert
            Assert.AreEqual(304, actual);
        }

        [Test]
        public void ConstructorShouldSetSizeToParameterWhenInvoked()
        {
            // Act
            int actual = this.element.Size;

            // Assert
            Assert.AreEqual(432, actual);
        }

        [Test]
        public void ConstructorShouldSetTypeToParameterWhenInvoked()
        {
            // Act
            InputElementType actual = this.element.Type;

            // Assert
            Assert.AreEqual(InputElementType.Float, actual);
        }

        [SetUp]
        public void Setup()
        {
            this.element = new InputElement(234, 432, InputElementType.Float, 304);
        }
    }
}