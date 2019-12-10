namespace FinalEngine.Maths.Tests
{
    using NUnit.Framework;

    public sealed class Vector3Tests
    {
        [Test]
        public void Equals_Operator_Test_Should_Return_True_When_Vector3_Contains_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector3(1, 2, 3);
            var vectorRight = new Vector3(1, 2, 3);

            // Act
            bool result = vectorLeft == vectorRight;

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_Test_Should_Return_Fakse_When_Vector3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector3(1, 2, 3);
            var vectorRight = new Vector3(4, 5, 6);

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Test_Should_Return_False_When_Not_Vector3()
        {
            // Act
            var vector = new Vector3();

            // Assert
            Assert.IsFalse(vector.Equals(new object()));
        }

        [Test]
        public void Equals_Test_Should_Return_True_When_Vector3_Contains_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector3(1, 2, 3);
            var vectorRight = new Vector3(1, 2, 3);

            // Act
            bool result = vectorLeft.Equals(vectorRight);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void NotEquals_Operator_Should_Return_True_When_Vector3_Does_Not_Contain_Same_Property_Values()
        {
            // Arrange
            var vectorLeft = new Vector3(1, 2, 3);
            var vectorRight = new Vector3(4, 5, 6);

            // Act
            bool result = vectorLeft != vectorRight;

            // Assert
            Assert.IsTrue(result);
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
    }
}