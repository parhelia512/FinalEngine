// <copyright file="RasterStateDescriptionTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

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

        [Test]
        public void FaceCullMode_Test_Should_Return_Back_When_Default()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            FaceCullMode actual = state.FaceCullMode;

            // Assert
            Assert.AreEqual(FaceCullMode.Back, actual);
        }

        [Test]
        public void FaceCullMode_Test_Should_Return_Front_When_Property_Set_To_Front()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.FaceCullMode = FaceCullMode.Front;

            // Assert
            Assert.AreEqual(FaceCullMode.Front, state.FaceCullMode);
        }

        [Test]
        public void FaceCullMode_Test_Should_Return_Back_When_Property_Set_To_Back()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.FaceCullMode = FaceCullMode.Back;

            // Assert
            Assert.AreEqual(FaceCullMode.Back, state.FaceCullMode);
        }

        [Test]
        public void FillMode_Test_Should_Return_Solid_When_Default()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            RasterMode actual = state.FillMode;

            // Assert
            Assert.AreEqual(RasterMode.Solid, actual);
        }

        [Test]
        public void FillMode_Test_Should_Return_Wireframe_When_Property_Set_To_Wireframe()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.FillMode = RasterMode.Wireframe;

            // Assert
            Assert.AreEqual(RasterMode.Wireframe, state.FillMode);
        }

        [Test]
        public void FillMode_Test_Should_Return_Solid_When_Property_Set_To_Solid()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.FillMode = RasterMode.Solid;

            // Assert
            Assert.AreEqual(RasterMode.Solid, state.FillMode);
        }

        [Test]
        public void WindingDirection_Test_Should_Return_CounterClockwise_When_Default()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            WindingDirection actual = state.WindingDirection;

            // Assert
            Assert.AreEqual(WindingDirection.CounterClockwise, actual);
        }

        [Test]
        public void WindingDirection_Test_Should_Return_CounterClockwise_When_Property_Set_To_CounterClockwise()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.WindingDirection = WindingDirection.CounterClockwise;

            // Assert
            Assert.AreEqual(WindingDirection.CounterClockwise, state.WindingDirection);
        }

        [Test]
        public void WindingDirection_Test_Should_Return_Clockwise_When_Property_Set_To_Clockwise()
        {
            // Arrange
            RasterStateDescription state = default;

            // Act
            state.WindingDirection = WindingDirection.Clockwise;

            // Assert
            Assert.AreEqual(WindingDirection.Clockwise, state.WindingDirection);
        }
    }
}