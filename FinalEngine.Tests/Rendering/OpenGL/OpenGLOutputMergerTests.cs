// <copyright file="OpenGLOutputMergerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    public class OpenGLOutputMergerTests
    {
        private DepthStateDescription description;

        private Mock<IOpenGLInvoker> invoker;

        private OpenGLOutputMerger outputMerger;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLOutputMerger(null));
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncAlwaysWhenComparisonModeIsAlways()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.Always;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Always), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncEqualWhenComparisonModeIsEqual()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.Equal;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Equal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncGequalWhenComparisonModeIsGreaterEqual()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.GreaterEqual;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Gequal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncGreaterWhenComparisonModeIsGreater()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.Greater;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Greater), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncLequalsWhenComparisonModeIsLessEqual()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.LessEqual;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Lequal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncLessWhenComparisonModeIsLess()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.Less;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Less), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncLessWhenDescriptionIsDefault()
        {
            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Less), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncNeverWhenComparisonModeIsNever()
        {
            // Arrange
            this.description.ComparisonMode = ComparisonMode.Never;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Never), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthMaskFalseWhenWriteEnabledIsFalse()
        {
            // Arrange
            this.description.WriteEnabled = false;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthMask(false), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthMaskTrueWhenWriteEnabledIsTrue()
        {
            // Arrange
            this.description.WriteEnabled = true;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.DepthMask(true), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokerDisableDepthTestWhenReadEnabledIsFalse()
        {
            // Arrange
            this.description.ReadEnabled = false;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.DepthTest), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokerEnableDepthTestWhenReadEnabledIsTrue()
        {
            // Arrange
            this.description.ReadEnabled = true;

            // Act
            this.outputMerger.SetDepthState(this.description);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.DepthTest), Times.Once);
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();
            this.outputMerger = new OpenGLOutputMerger(this.invoker.Object);
            this.description = default;
        }
    }
}