namespace FinalEngine.Rendering.Tests
{
    using NUnit.Framework;

    public class RasterStateDescriptionTests
    {
        [Test]
        public void CullEnabled_Test_Should_Equal_False_When_Default()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            bool actual = state.CullEnabled;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void CullEnabled_Test_Should_Equal_True_When_Property_Set_To_True()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.CullEnabled = true;

            // Assert
            Assert.IsTrue(state.CullEnabled);
        }

        [Test]
        public void CullEnabled_Test_Should_Equal_False_When_Property_Set_To_False()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.CullEnabled = false;

            // Assert
            Assert.IsFalse(state.CullEnabled);
        }
    }
}