namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Matrix2Tests
    {
        [Test]
        public void Equals_Operator_Test_Should_Return_False_When_Matrix2_Parameter_Does_Not_Contain_Same_Values()
        {
            // Arrange
            var left = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));
            var right = new Matrix2(new Vector2(0, 1), new Vector2(1, 0));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Matrix2_Parameter_Does_Contain_Same_Values()
        {
            // Arrange
            var left = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));
            var right = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Matrix2_Parameter_Does_Not_Contain_Same_Values()
        {
            // Arrange
            var left = new Matrix2(new Vector2(0, 1), new Vector2(1, 0));
            var right = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Matrix2_Parameter_Is_Not_Matrix2()
        {
            // Arrange
            var matrix2 = new Matrix2();

            // Act
            bool result = matrix2.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Matrix2_Parameter_Does_Contain_Same_Values()
        {
            // Arrange
            var left = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));
            var right = new Matrix2(new Vector2(1, 0), new Vector2(0, 1));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Row0_Property_Test_Should_Return_Expected_Vector2()
        {
            // Arrange
            var expected = new Vector2(1, 0);

            // Act
            var matrix = new Matrix2(expected, new Vector2(0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row0);
        }

        [Test]
        public void Row1_Property_Test_Should_Return_Expected_Vector2()
        {
            // Arrange
            var expected = new Vector2(1, 0);

            // Act
            var matrix = new Matrix2(new Vector2(0, 0), expected);

            // Assert
            Assert.AreEqual(expected, matrix.Row1);
        }
    }
}