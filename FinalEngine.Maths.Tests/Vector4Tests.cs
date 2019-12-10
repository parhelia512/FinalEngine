namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Vector4Tests
    {
        [Test]
        public void Conversion_Operator_Test_Vector2_To_Vector4()
        {
            // Arrange
            var expected = new Vector4(44, 22, 0, 0);
            var vector = new Vector2(expected.X, expected.Y);

            // Act
            var actual = (Vector4)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Conversion_Operator_Test_Vector3_To_Vector4()
        {
            // Arrange
            var expected = new Vector4(44, 22, 55, 0);
            var vector = new Vector3(expected.X, expected.Y, expected.Z);

            // Act
            var actual = (Vector4)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Vector4_Contains_Same_Property_Values()
        {
            // Arrange
            Vector4 vectorLeft = Vector4.PositiveInfinity;
            Vector4 vectorRight = Vector4.PositiveInfinity;

            // Act
            bool result = vectorLeft == vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Vector4()
        {
            // Arrange
            var vector = new Vector4();

            // Act
            bool result = vector.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Vector4_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector4 vectorLeft = Vector4.PositiveInfinity;
            Vector4 vectorRight = Vector4.Zero;

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Vector4_Contains_Same_Property_Values()
        {
            // Arrange
            Vector4 vectorLeft = Vector4.NegativeInfinity;
            Vector4 vectorRight = Vector4.NegativeInfinity;

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NegativeInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector4(float.NegativeInfinity,
                                       float.NegativeInfinity,
                                       float.NegativeInfinity,
                                       float.NegativeInfinity);

            // Act
            Vector4 actual = Vector4.NegativeInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NotEquals_Operator_Should_Return_True_When_Vector4_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector4 vectorLeft = Vector4.PositiveInfinity;
            Vector4 vectorRight = Vector4.One;

            // Act
            bool result = vectorLeft != vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void One_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector4(1, 1, 1, 1);

            // Act
            Vector4 actual = Vector4.One;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PositiveInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector4(float.PositiveInfinity,
                                       float.PositiveInfinity,
                                       float.PositiveInfinity,
                                       float.PositiveInfinity);

            // Act
            Vector4 actual = Vector4.PositiveInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void W_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector4(0, 0, 0, Expected);

            // Assert
            Assert.AreEqual(Expected, vector.W);
        }

        [Test]
        public void X_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Arrange and act
            var vector = new Vector4(Expected, 0, 0, 0);

            // Assert
            Assert.AreEqual(Expected, vector.X);
        }

        [Test]
        public void Y_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector4(0, Expected, 0, 0);

            // Assert
            Assert.AreEqual(Expected, vector.Y);
        }

        [Test]
        public void Z_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector4(0, 0, Expected, 0);

            // Assert
            Assert.AreEqual(Expected, vector.Z);
        }

        [Test]
        public void Zero_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector4(0, 0, 0, 0);

            // Act
            Vector4 actual = Vector4.Zero;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}