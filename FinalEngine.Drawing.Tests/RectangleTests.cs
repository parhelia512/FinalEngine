// <copyright file="RectangleTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing.Tests
{
    using NUnit.Framework;

    public sealed class RectangleTests
    {
        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Rectangle()
        {
            // Arrange
            var rectangle = default(Rectangle);
            object obj = new object();

            // Act
            bool result = rectangle.Equals(obj);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_False_When_Not_Same_Values()
        {
            // Arrange
            var left = new Rectangle(new Point(100, 100), new Size(300, 300));
            var right = new Rectangle(new Point(200, 200), new Size(400, 400));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_True_When_Same_Values()
        {
            // Arrange
            var left = new Rectangle(new Point(100, 100), new Size(300, 300));
            var right = new Rectangle(new Point(100, 100), new Size(300, 300));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Height_Property_Test_Should_Be_5568()
        {
            // Arrange
            const int Expected = 5568;
            var rectangle = new Rectangle(Point.Empty, new Size(0, Expected));

            // Act
            int actual = rectangle.Height;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Location_Property_Test()
        {
            // Arrange
            var expected = new Point(100, 400);

            // Act
            var rectangle = new Rectangle(expected, Size.Empty);

            // Assert
            Assert.AreEqual(expected, rectangle.Location);
        }

        [Test]
        public void Size_Property_Test()
        {
            // Arrange
            var expected = new Size(555, 222);

            // Act
            var rectangle = new Rectangle(Point.Empty, expected);

            // Assert
            Assert.AreEqual(expected, rectangle.Size);
        }

        [Test]
        public void Width_Property_Test_Should_Be_1025()
        {
            // Arrange
            const int Expected = 1025;
            var rectangle = new Rectangle(Point.Empty, new Size(Expected, 0));

            // Act
            int actual = rectangle.Width;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void X_Property_Test_Should_Be_245()
        {
            // Arrange
            const int Expected = 245;
            var rectangle = new Rectangle(new Point(Expected, 0), Size.Empty);

            // Act
            int actual = rectangle.X;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Y_Property_Test_Should_Be_758()
        {
            // Arrange
            const int Expected = 758;
            var rectangle = new Rectangle(new Point(0, Expected), Size.Empty);

            // Act
            int actual = rectangle.Y;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}