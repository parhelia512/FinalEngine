// <copyright file="RectangleFTests.cs" company="Software Antics">
// Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Drawing.Tests
{
    using NUnit.Framework;

    public sealed class RectangleFTests
    {
        [Test]
        public void Equals_Test_Should_Be_False_When_Not_RectangleF()
        {
            // Arrange
            var rectangle = default(RectangleF);
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
            var left = new RectangleF(new PointF(100, 100), new SizeF(300, 300));
            var right = new RectangleF(new PointF(200, 200), new SizeF(400, 400));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Be_True_When_Same_Values()
        {
            // Arrange
            var left = new RectangleF(new PointF(100, 100), new SizeF(300, 300));
            var right = new RectangleF(new PointF(100, 100), new SizeF(300, 300));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Height_Property_Test_Should_Be_5568()
        {
            // Arrange
            const float Expected = 5568;
            var rectangle = new RectangleF(PointF.Empty, new SizeF(0, Expected));

            // Act
            float actual = rectangle.Height;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Location_Property_Test()
        {
            // Arrange
            var expected = new PointF(100, 400);

            // Act
            var rectangle = new RectangleF(expected, SizeF.Empty);

            // Assert
            Assert.AreEqual(expected, rectangle.Location);
        }

        [Test]
        public void SizeF_Property_Test()
        {
            // Arrange
            var expected = new SizeF(555, 222);

            // Act
            var rectangle = new RectangleF(PointF.Empty, expected);

            // Assert
            Assert.AreEqual(expected, rectangle.Size);
        }

        [Test]
        public void Width_Property_Test_Should_Be_1025()
        {
            // Arrange
            const float Expected = 1025;
            var rectangle = new RectangleF(PointF.Empty, new SizeF(Expected, 0));

            // Act
            float actual = rectangle.Width;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void X_Property_Test_Should_Be_245()
        {
            // Arrange
            const float Expected = 245;
            var rectangle = new RectangleF(new PointF(Expected, 0), SizeF.Empty);

            // Act
            float actual = rectangle.X;

            // Assert
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void Y_Property_Test_Should_Be_758()
        {
            // Arrange
            const float Expected = 758;
            var rectangle = new RectangleF(new PointF(0, Expected), SizeF.Empty);

            // Act
            float actual = rectangle.Y;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}