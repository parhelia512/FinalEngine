namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Vector2Tests
    {
        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Vector2_Contains_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector2(155, 243);
            var vectorRight = new Vector2(155, 243);

            // Act
            bool result = vectorLeft == vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_Fakse_When_Vector2_Does_Not_Contain_Same_Values()
        {
            // Arrange
            var vectorLeft = new Vector2(1, 2);
            var vectorRight = new Vector2(2, 1);

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Vector2()
        {
            // Act
            var vector = new Vector2();

            // Assert
            Assert.IsFalse(vector.Equals(new object()));
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Vector2_Contains_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector2(155, 243);
            var vectorRight = new Vector2(155, 243);

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NotEquals_Operator_Should_Return_True_When_Vector2_Does_Not_Contain_Same_Values()
        {
            // Arrange
            var vectorLeft = new Vector2(155, 243);
            var vectorRight = new Vector2(156, 244);

            // Act
            bool result = vectorLeft != vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void X_Property_Test_Should_Be_143()
        {
            // Arrange
            const int Expected = 143;

            // Arrange and act
            var vector = new Vector2(143, 0);

            // Assert
            Assert.AreEqual(Expected, vector.X);
        }

        [Test]
        public void Y_Property_Test_Should_Be_456()
        {
            // Arrange
            const int Expected = 456;

            // Act
            var vector = new Vector2(0, 456);

            // Assert
            Assert.AreEqual(Expected, vector.Y);
        }
    }
}