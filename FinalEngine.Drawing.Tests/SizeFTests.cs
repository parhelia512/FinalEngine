// <copyright file="SizeFTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing.Tests
{
    using NUnit.Framework;

    public sealed class SizeFTests
    {
        [Test]
        public void Empty_ReadOnly_Field_Test()
        {
            // Arrange
            var expected = new SizeF(0, 0);

            // Act
            SizeF actual = SizeF.Empty;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Same_Values()
        {
            // Arrange
            var left = new SizeF(100, 100);
            var right = new SizeF(200, 200);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_SizeF()
        {
            // Arrange
            var point = new SizeF(0, 0);
            object obj = new object();

            // Act
            bool result = point.Equals(obj);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_True_When_Same_Values()
        {
            // Arrange
            var left = new SizeF(156, 245);
            var right = new SizeF(156, 245);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_False()
        {
            // Arrange
            var point = new SizeF(100, 140);

            // Act
            bool result = point.IsEmpty;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_True()
        {
            // Arrange
            var point = new SizeF(0, 0);

            // Act
            bool result = point.IsEmpty;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void X_Property_Test_Should_Be_45()
        {
            // Arrange
            const float Expected = 45.0f;

            // Act
            var point = new SizeF(Expected, 0);

            // Assert
            Assert.AreEqual(Expected, point.Width);
        }

        [Test]
        public void Y_Property_Test_Should_Be_68()
        {
            // Arrange
            const float Expected = 68.0f;

            // Act
            var point = new SizeF(0, Expected);

            // Assert
            Assert.AreEqual(Expected, point.Height);
        }
    }
}