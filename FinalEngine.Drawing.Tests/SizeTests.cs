// <copyright file="SizeTests.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing.Tests
{
    using NUnit.Framework;

    public sealed class SizeTests
    {
        [Test]
        public void Empty_ReadOnly_Field_Test()
        {
            // Arrange
            var expected = new Size(0, 0);

            // Act
            Size actual = Size.Empty;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Same_Values()
        {
            // Arrange
            var left = new Size(100, 100);
            var right = new Size(200, 200);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Size()
        {
            // Arrange
            var point = new Size(0, 0);
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
            var left = new Size(156, 245);
            var right = new Size(156, 245);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_False()
        {
            // Arrange
            var point = new Size(100, 140);

            // Act
            bool result = point.IsEmpty;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_True()
        {
            // Arrange
            var point = new Size(0, 0);

            // Act
            bool result = point.IsEmpty;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void X_Property_Test_Should_Be_45()
        {
            // Arrange
            const int Expected = 45;

            // Act
            var point = new Size(Expected, 0);

            // Assert
            Assert.AreEqual(Expected, point.Width);
        }

        [Test]
        public void Y_Property_Test_Should_Be_68()
        {
            // Arrange
            const int Expected = 68;

            // Act
            var point = new Size(0, Expected);

            // Assert
            Assert.AreEqual(Expected, point.Height);
        }
    }
}