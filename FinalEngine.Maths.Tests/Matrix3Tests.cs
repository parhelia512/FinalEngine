namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Matrix3Tests
    {
        [Test]
        public void Equals_Operator_Test_Should_Return_False_When_Matrix3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 4), new Vector3(1, 0, 2));
            var right = new Matrix3(new Vector3(0, 1, 4), new Vector3(1, 0, 7), new Vector3(4, 5, 6));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Matrix3_Contains_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 5), new Vector3(34, 56, 76));
            var right = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 5), new Vector3(34, 56, 76));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Matrix3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 4), new Vector3(1, 0, 2));
            var right = new Matrix3(new Vector3(0, 1, 4), new Vector3(1, 0, 7), new Vector3(4, 5, 6));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Matrix3()
        {
            // Arrange
            var Matrix3 = new Matrix3();

            // Act
            bool result = Matrix3.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Matrix3_Does_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 5), new Vector3(34, 56, 76));
            var right = new Matrix3(new Vector3(1, 0, 3), new Vector3(0, 1, 5), new Vector3(34, 56, 76));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Row0_Property_Test_Should_Be_Expected_Vector3()
        {
            // Arrange
            var expected = new Vector3(1, 0, 4);

            // Act
            var matrix = new Matrix3(expected, new Vector3(0, 0, 0), new Vector3(0, 0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row0);
        }

        [Test]
        public void Row1_Property_Test_Should_Be_Vector3()
        {
            // Arrange
            var expected = new Vector3(1, 0, 4);

            // Act
            var matrix = new Matrix3(new Vector3(0, 0, 0), expected, new Vector3(0, 0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row1);
        }

        [Test]
        public void Row2_Property_Test_Should_Be_Vector3()
        {
            // Arrange
            var expected = new Vector3(1, 0, 4);

            // Act
            var matrix = new Matrix3(new Vector3(0, 0, 0), new Vector3(0, 0, 0), expected);

            // Assert
            Assert.AreEqual(expected, matrix.Row2);
        }
    }
}