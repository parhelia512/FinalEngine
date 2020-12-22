// <copyright file="VertexTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering
{
    using System.Diagnostics.CodeAnalysis;
    using System.Numerics;
    using FinalEngine.Rendering;
    using NUnit.Framework;

    [ExcludeFromCodeCoverage]
    public class VertexTests
    {
        private Vertex vertex;

        [Test]
        public void ColorShouldReturnUnitWWhenSetToUnitW()
        {
            // Act
            this.vertex.Color = Vector4.UnitW;

            // Assert
            Assert.AreEqual(Vector4.UnitW, this.vertex.Color);
        }

        [Test]
        public void ColorShouldReturnZeroWhenDefault()
        {
            // Act
            Vector4 actual = this.vertex.Color;

            // Assert
            Assert.AreEqual(Vector4.Zero, actual);
        }

        [Test]
        public void ConstructorShouldSetColorWhenInvoked()
        {
            // Act
            this.vertex = new Vertex(Vector3.Zero, Vector4.One, Vector2.Zero);

            // Assert
            Assert.AreEqual(Vector4.One, this.vertex.Color);
        }

        [Test]
        public void ConstructorShouldSetPositionWhenInvoked()
        {
            // Act
            this.vertex = new Vertex(Vector3.One, Vector4.Zero, Vector2.Zero);

            // Assert
            Assert.AreEqual(Vector3.One, this.vertex.Position);
        }

        [Test]
        public void ConstructorShouldSetTextureCoordinateWhenInvoked()
        {
            // Act
            this.vertex = new Vertex(Vector3.Zero, Vector4.Zero, Vector2.One);

            // Assert
            Assert.AreEqual(Vector2.One, this.vertex.TextureCoordinate);
        }

        [Test]
        public void EqualityOperatorShouldReturnFalseWhenPropertiesDontMatch()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.Zero,
                TextureCoordinate = Vector2.One,
                Color = new Vector4(1, 2, 3, 4),
            };

            var right = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            // Act
            bool actual = left == right;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void EqualityOperatorShouldReturnTrueWhenPropertiesMatch()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.Zero,
                TextureCoordinate = Vector2.One,
                Color = new Vector4(1, 2, 3, 4),
            };

            var right = new Vertex()
            {
                Position = Vector3.Zero,
                TextureCoordinate = Vector2.One,
                Color = new Vector4(1, 2, 3, 4),
            };

            // Act
            bool actual = left == right;

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenObjectIsNotVertex()
        {
            // Act
            bool actual = this.vertex.Equals(new object());

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenObjectIsNull()
        {
            // Act
            bool actual = this.vertex.Equals(null);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void EqualsShouldReturnFalseWhenPropertiesDontMatch()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.Zero,
                TextureCoordinate = Vector2.One,
                Color = new Vector4(1, 2, 3, 4),
            };

            var right = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            // Act
            bool actual = left.Equals(right);

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void EqualsShouldReturnTrueWhenObjectIsVertexAndHasSameProperties()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            object right = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            // Act
            bool actual = left.Equals(right);

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void GetHashCodeShouldReturnSameAsOtherObjectWhenPropertiesAreEqual()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            var right = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            // Act
            int leftHashCode = left.GetHashCode();
            int rightHashCode = right.GetHashCode();

            // Assert
            Assert.AreEqual(leftHashCode, rightHashCode);
        }

        [Test]
        public void InEqualityOperatorShouldReturnFalseWhenPropertiesMatch()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            var right = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            // Act
            bool actual = left != right;

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void InEqualityOperatorShouldReturnTrueWhenPropertiesDontMatch()
        {
            // Arrange
            var left = new Vertex()
            {
                Position = Vector3.One,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(3, 2, 4, 1),
            };

            var right = new Vertex()
            {
                Position = Vector3.UnitX,
                TextureCoordinate = Vector2.Zero,
                Color = new Vector4(2, 6, 5, 7),
            };

            // Act
            bool actual = left != right;

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void PositionShouldReturnUnitYWhenSetToUnitY()
        {
            // Act
            this.vertex.Position = Vector3.UnitY;

            // Assert
            Assert.AreEqual(Vector3.UnitY, this.vertex.Position);
        }

        [Test]
        public void PositionShouldReturnZeroWhenDefault()
        {
            // Act
            Vector3 actual = this.vertex.Position;

            // Assert
            Assert.AreEqual(Vector3.Zero, actual);
        }

        [SetUp]
        public void Setup()
        {
            this.vertex = default;
        }

        [Test]
        public void SizeInBytesShouldReturnCorrectSize()
        {
            // Assert
            Assert.AreEqual(36, Vertex.SizeInBytes);
        }

        [Test]
        public void TextureCoordinateShouldReturnUnitXWhenSetToUnitX()
        {
            // Act
            this.vertex.TextureCoordinate = Vector2.UnitX;

            // Assert
            Assert.AreEqual(Vector2.UnitX, this.vertex.TextureCoordinate);
        }

        [Test]
        public void TextureCoordinateShouldReturnZeroWhenDefault()
        {
            // Act
            Vector2 actual = this.vertex.TextureCoordinate;

            // Assert
            Assert.AreEqual(Vector2.Zero, actual);
        }
    }
}