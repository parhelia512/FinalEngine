namespace FinalEngine.Input.Tests
{
    using System;
    using FinalEngine.Input.Events;
    using NUnit.Framework;

    public sealed class MouseButtonEventArgsTests
    {
        [Test]
        public void MouseButton_Property_Test()
        {
            // Arrange
            Array values = Enum.GetValues(typeof(MouseButton));
            var Expected = (MouseButton)values.GetValue(new Random().Next(values.Length));

            var mouseButtonEventArgs = new MouseButtonEventArgs(Expected);

            // Act
            MouseButton actual = mouseButtonEventArgs.Button;

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}