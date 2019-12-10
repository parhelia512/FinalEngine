namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Vector3Tests
    {
        [Test]
        public void Back_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(0, 0, -1);

            // Act
            Vector3 actual = Vector3.Back;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Conversion_Operator_Test_Vector2_To_Vector3()
        {
            // Arrange
            var expected = new Vector3(100, 200, 0);
            var vector = new Vector2(expected.X, expected.Y);

            // Act
            var actual = (Vector3)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Conversion_Operator_Test_Vector4_To_Vector3()
        {
            // Arrange
            var expected = new Vector3(14, 30, 0);
            var vector = new Vector4(expected.X, expected.Y, 0, 0);

            // Act
            var actual = (Vector3)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Down_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(0, -1, 0);

            // Act
            Vector3 actual = Vector3.Down;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Vector3_Contains_Same_Property_Values()
        {
            // Arrange
            Vector3 vectorLeft = Vector3.Forward;
            Vector3 vectorRight = Vector3.Forward;

            // Act
            bool result = vectorLeft == vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Vector3()
        {
            // Arrange
            var vector = new Vector3();

            // Act
            bool result = vector.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Vector3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector3 vectorLeft = Vector3.Forward;
            Vector3 vectorRight = Vector3.Back;

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Vector3_Contains_Same_Property_Values()
        {
            // Arrange
            Vector3 vectorLeft = Vector3.Right;
            Vector3 vectorRight = Vector3.Right;

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Forward_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(0, 0, 1);

            // Act
            Vector3 actual = Vector3.Forward;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Left_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(-1, 0, 0);

            // Act
            Vector3 actual = Vector3.Left;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NegativeInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(float.NegativeInfinity,
                                       float.NegativeInfinity,
                                       float.NegativeInfinity);

            // Act
            Vector3 actual = Vector3.NegativeInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NotEquals_Operator_Should_Return_True_When_Vector3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector3 vectorLeft = Vector3.Up;
            Vector3 vectorRight = Vector3.Down;

            // Act
            bool result = vectorLeft != vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void One_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(1, 1, 1);

            // Act
            Vector3 actual = Vector3.One;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PositiveInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(float.PositiveInfinity,
                                       float.PositiveInfinity,
                                       float.PositiveInfinity);

            // Act
            Vector3 actual = Vector3.PositiveInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Right_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(1, 0, 0);

            // Act
            Vector3 actual = Vector3.Right;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Up_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(0, 1, 0);

            // Act
            Vector3 actual = Vector3.Up;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void X_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Arrange and act
            var vector = new Vector3(Expected, 0, 0);

            // Assert
            Assert.AreEqual(Expected, vector.X);
        }

        [Test]
        public void Y_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector3(0, Expected, 0);

            // Assert
            Assert.AreEqual(Expected, vector.Y);
        }

        [Test]
        public void Z_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector3(0, 0, Expected);

            // Assert
            Assert.AreEqual(Expected, vector.Z);
        }

        [Test]
        public void Zero_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector3(0, 0, 0);

            // Act
            Vector3 actual = Vector3.Zero;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}