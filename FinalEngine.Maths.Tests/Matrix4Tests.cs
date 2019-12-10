namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Matrix4Tests
    {
        [Test]
        public void Equals_Operator_Test_Should_Return_False_When_Matrix4_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 4, 3),
                                   new Vector4(1, 0, 2, 1),
                                   new Vector4(0, 3, 4, 5));

            var right = new Matrix4(new Vector4(0, 1, 4, 5),
                                    new Vector4(1, 0, 7, 3),
                                    new Vector4(4, 5, 6, 1),
                                    new Vector4(4, 5, 6, 7));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Matrix4_Contains_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 5, 55),
                                   new Vector4(34, 56, 76, 29),
                                   new Vector4(45, 66, 123, 4573));

            var right = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 5, 55),
                                   new Vector4(34, 56, 76, 29),
                                   new Vector4(45, 66, 123, 4573));

            // Act
            bool result = left == right;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Matrix4_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 4, 3),
                                   new Vector4(1, 0, 2, 1),
                                   new Vector4(0, 3, 4, 5));

            var right = new Matrix4(new Vector4(0, 1, 4, 5),
                                    new Vector4(1, 0, 7, 3),
                                    new Vector4(4, 5, 6, 1),
                                    new Vector4(4, 5, 6, 7));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Matrix4()
        {
            // Arrange
            var matrix = new Matrix4();

            // Act
            bool result = matrix.Equals(new object());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Matrix4_Does_Contain_Same_Property_Values()
        {
            // Arrange
            var left = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 5, 55),
                                   new Vector4(34, 56, 76, 29),
                                   new Vector4(45, 66, 123, 4573));

            var right = new Matrix4(new Vector4(1, 0, 3, 4),
                                   new Vector4(0, 1, 5, 55),
                                   new Vector4(34, 56, 76, 29),
                                   new Vector4(45, 66, 123, 4573));

            // Act
            bool result = left.Equals(right);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Row0_Property_Test_Should_Be_Expected_Vector4()
        {
            // Arrange
            var expected = new Vector4(1, 0, 4, 4);

            // Act
            var matrix = new Matrix4(expected,
                                     new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row0);
        }

        [Test]
        public void Row1_Property_Test_Should_Be_Vector4()
        {
            // Arrange
            var expected = new Vector4(1, 0, 4, 1);

            // Act
            var matrix = new Matrix4(new Vector4(0, 0, 0, 0),
                                     expected,
                                     new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row1);
        }

        [Test]
        public void Row2_Property_Test_Should_Be_Vector4()
        {
            // Arrange
            var expected = new Vector4(1, 0, 4, 455);

            // Act
            var matrix = new Matrix4(new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0),
                                     expected,
                                     new Vector4(0, 0, 0, 0));

            // Assert
            Assert.AreEqual(expected, matrix.Row2);
        }

        [Test]
        public void Row3_Property_Test_Should_Be_Vector4()
        {
            // Arrange
            var expected = new Vector4(1, 0, 4, 455);

            // Act
            var matrix = new Matrix4(new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0),
                                     new Vector4(0, 0, 0, 0),
                                     expected);

            // Assert
            Assert.AreEqual(expected, matrix.Row3);
        }
    }
}