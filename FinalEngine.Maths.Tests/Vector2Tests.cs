namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Vector2Tests
    {
        [Test]
        public void Conversion_Operator_Test_Vector3_To_Vector2()
        {
            // Arrange
            var expected = new Vector2(34, 56);
            var vector = new Vector3(34, 56, 12);

            // Act
            var actual = (Vector2)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Conversion_Operator_Test_Vector4_To_Vector2()
        {
            // Arrange
            var expected = new Vector2(34, 56);
            var vector = new Vector4(34, 56, 12, 23);

            // Act
            var actual = (Vector2)vector;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Down_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(0, -1);

            // Act
            Vector2 actual = Vector2.Down;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Vector2_Contains_Same_Property_Values()
        {
            // Arrange
            Vector2 left = Vector2.Left;
            Vector2 right = Vector2.Left;

            // Act
            bool result = left == right;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Vector2()
        {
            // Arrange
            var vector = new Vector2();

            // Act
            bool result = vector.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Vector2_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector2 left = Vector2.Left;
            Vector2 right = Vector2.Right;

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Vector2_Contains_Same_Property_Values()
        {
            // Arrange
            Vector2 left = Vector2.Right;
            Vector2 right = Vector2.Right;

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Left_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(-1, 0);

            // Act
            Vector2 actual = Vector2.Left;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NegativeInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

            // Act
            Vector2 actual = Vector2.NegativeInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NotEquals_Operator_Should_Return_True_When_Vector2_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            Vector2 left = Vector2.Left;
            Vector2 right = Vector2.One;

            // Act
            bool result = left != right;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void One_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(1, 1);

            // Act
            Vector2 actual = Vector2.One;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PositiveInfinity_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

            // Act
            Vector2 actual = Vector2.PositiveInfinity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Right_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(1, 0);

            // Act
            Vector2 actual = Vector2.Right;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Up_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(0, 1);

            // Act
            Vector2 actual = Vector2.Up;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void X_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Arrange and act
            var vector = new Vector2(Expected, 0);

            // Assert
            Assert.AreEqual(Expected, vector.X);
        }

        [Test]
        public void Y_Property_Test_Should_Be_1()
        {
            // Arrange
            const int Expected = 1;

            // Act
            var vector = new Vector2(0, Expected);

            // Assert
            Assert.AreEqual(Expected, vector.Y);
        }

        [Test]
        public void Zero_Readonly_Field_Test()
        {
            // Arrange
            var expected = new Vector2(0, 0);

            // Act
            Vector2 actual = Vector2.Zero;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}