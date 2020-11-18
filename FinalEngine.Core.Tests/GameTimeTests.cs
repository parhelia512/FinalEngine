// <copyright file="GameTimeTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Core.Tests
{
    using System;
    using FinalEngine.Core.Invoking;
    using Moq;
    using NUnit.Framework;

    public class GameTimeTests
    {
        [Test]
        public void CanProcessNextFrame_Test_Should_Access_TimeSpan_TotalMilliseconds_When_Watch_Is_Running()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            watch.SetupGet(i => i.IsRunning).Returns(true);

            var gameTime = new GameTime(watch.Object, 1.0d);

            // Act
            gameTime.CanProcessNextFrame();

            // Assert
            timeSpan.VerifyGet(i => i.TotalMilliseconds, Times.Once);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Access_Watch_IsRunning_Property()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);

            var gameTime = new GameTime(watch.Object, 1.0d);

            // Act
            gameTime.CanProcessNextFrame();

            // Assert
            watch.VerifyGet(i => i.IsRunning, Times.Once);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Invoke_Watch_Restart_When_Watch_Is_Not_Running()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            watch.SetupGet(i => i.IsRunning).Returns(false);

            var gameTime = new GameTime(watch.Object, 1.0d);

            // Act
            gameTime.CanProcessNextFrame();

            // Assert
            watch.Verify(i => i.Restart(), Times.Once);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Not_Invoke_Watch_Restart_When_Watch_Is_Running()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            watch.SetupGet(i => i.IsRunning).Returns(true);

            var gameTime = new GameTime(watch.Object, 1.0d);

            // Act
            gameTime.CanProcessNextFrame();

            // Assert
            watch.Verify(i => i.Restart(), Times.Never);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Return_False_When_CurrentTime_Is_LessThan_LastTime_Plus_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);

            gameTime.CanProcessNextFrame();

            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            // Act
            bool actual = gameTime.CanProcessNextFrame();

            // Assert
            Assert.False(actual);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Return_True_When_CurrentTime_Is_Equal_To_LastTime_Plus_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);

            gameTime.CanProcessNextFrame();

            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(100.0d);

            // Act
            bool actual = gameTime.CanProcessNextFrame();

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Return_True_When_CurrentTime_Is_Greater_Than_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(110.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);

            // Act
            bool actual = gameTime.CanProcessNextFrame();

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Return_True_When_CurrentTime_Is_GreaterThan_To_LastTime_Plus_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);

            gameTime.CanProcessNextFrame();

            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(110.0d);

            // Act
            bool actual = gameTime.CanProcessNextFrame();

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void CanProcessNextFrame_Test_Should_Return_True_When_CurrentTime_Is_The_Same_As_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(100.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);

            // Act
            bool actual = gameTime.CanProcessNextFrame();

            // Assert
            Assert.True(actual);
        }

        [Test]
        public void Constructor_Test_Should_Not_Throw_Exception()
        {
            // Arrange, act and assert.
            Assert.DoesNotThrow(() => new GameTime(new Mock<IStopwatch>().Object, 1.0d));
        }

        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNullException_When_Watch_Parameter_Is_Null()
        {
            // Arrange, act and assert.
            Assert.Throws<ArgumentNullException>(() => new GameTime(null, 1.0d));
        }

        [Test]
        public void Constructor_Test_Should_Throw_DivideByZeroException_When_FrameCap_Equals_Zero()
        {
            // Arrange, act and assert.
            Assert.Throws<DivideByZeroException>(() => new GameTime(new Mock<IStopwatch>().Object, 0.0d));
        }

        [Test]
        public void Constructor_Test_Should_Throw_DivideByZeroException_When_FrameCap_LessThan_Zero()
        {
            // Arrange, act and assert.
            Assert.Throws<DivideByZeroException>(() => new GameTime(new Mock<IStopwatch>().Object, -0.1d));
        }

        [Test]
        public void Delta_Test_Should_Return_8_Point_3__When_CurrentTime_Is_GreaterThan_LastTime_Plus_WaitTime()
        {
            // Arrange
            const double Expected = 8.3d;
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(8.4d);

            var gameTime = new GameTime(watch.Object, 120.0d);

            bool actual = gameTime.CanProcessNextFrame();

            // Act
            double delta = gameTime.Delta;

            // Assert
            Assert.AreEqual(Expected, delta, 0.1d);
        }

        [Test]
        public void Delta_Test_Should_Return_Zero_When_CurrentTime_Is_LessThan_LastTime_Plus_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);
            gameTime.CanProcessNextFrame();

            // Act
            double actual = gameTime.Delta;

            // Assert
            Assert.Zero(actual);
        }

        [Test]
        public void FPS_Test_Should_Return_120__When_CurrentTime_Is_GreaterThan_LastTime_Plus_WaitTime()
        {
            // Arrange
            const double Expected = 120.0d;
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(8.4d);

            var gameTime = new GameTime(watch.Object, 120.0d);

            bool actual = gameTime.CanProcessNextFrame();

            // Act
            double delta = gameTime.FPS;

            // Assert
            Assert.AreEqual(Expected, delta, 1.0d);
        }

        [Test]
        public void FPS_Test_Should_Return_Zero_When_CurrentTime_Is_LessThan_LastTime_Plus_WaitTime()
        {
            // Arrange
            var watch = new Mock<IStopwatch>();
            var timeSpan = new Mock<ITimeSpan>();

            watch.SetupGet(i => i.Elapsed).Returns(timeSpan.Object);
            timeSpan.SetupGet(i => i.TotalMilliseconds).Returns(50.0d);

            var gameTime = new GameTime(watch.Object, 10.0d);
            gameTime.CanProcessNextFrame();

            // Act
            double actual = gameTime.FPS;

            // Assert
            Assert.Zero(actual);
        }
    }
}