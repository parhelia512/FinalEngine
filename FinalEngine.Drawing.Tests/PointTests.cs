// <copyright file="PointTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing.Tests
{
    using NUnit.Framework;

    public sealed class PointTests
    {
        [Test]
        public void Empty_ReadOnly_Field_Test()
        {
            // Arrange
            var expected = new Point(0, 0);

            // Act
            Point actual = Point.Empty;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Point()
        {
            // Arrange
            var point = new Point(0, 0);
            object obj = new object();

            // Act
            bool result = point.Equals(obj);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Same_Values()
        {
            // Arrange
            var left = new Point(100, 100);
            var right = new Point(200, 200);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_True_When_Same_Values()
        {
            // Arrange
            var left = new Point(156, 245);
            var right = new Point(156, 245);

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_False()
        {
            // Arrange
            var point = new Point(100, 140);

            // Act
            bool result = point.IsEmpty;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsEmpty_Property_Test_Should_Be_True()
        {
            // Arrange
            var point = new Point(0, 0);

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
            var point = new Point(Expected, 0);

            // Assert
            Assert.AreEqual(Expected, point.X);
        }

        [Test]
        public void Y_Property_Test_Should_Be_68()
        {
            // Arrange
            const int Expected = 68;

            // Act
            var point = new Point(0, Expected);

            // Assert
            Assert.AreEqual(Expected, point.Y);
        }
    }
}