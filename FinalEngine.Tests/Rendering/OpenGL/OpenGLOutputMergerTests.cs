// <copyright file="OpenGLOutputMergerTests.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Tests.Rendering.OpenGL
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using Moq;
    using NUnit.Framework;
    using OpenTK.Graphics.OpenGL4;
    using BlendEquationMode = FinalEngine.Rendering.BlendEquationMode;
    using TKBlendEquationMode = OpenTK.Graphics.OpenGL4.BlendEquationMode;

    [ExcludeFromCodeCoverage]
    public class OpenGLOutputMergerTests
    {
        private BlendStateDescription blendState;

        private DepthStateDescription depthState;

        private Mock<IOpenGLInvoker> invoker;

        private OpenGLOutputMerger outputMerger;

        private StencilStateDescription stencilState;

        [Test]
        public void ConstructorShouldThrowArgumentNullExceptionWhenInvokerIsNull()
        {
            // Arrange, act and assert
            Assert.Throws<ArgumentNullException>(() => new OpenGLOutputMerger(null));
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendColorWhenInvoked()
        {
            // Arrange
            Color color = Color.CornflowerBlue;
            this.blendState.Color = color;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendColor(color), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendEquationFuncAddWhenEquationModeIsAdd()
        {
            // Arrange
            this.blendState.EquationMode = BlendEquationMode.Add;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendEquation(TKBlendEquationMode.FuncAdd), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendEquationFuncReverseSubtractWhenEquationModeIsReverseSubtract()
        {
            // Arrange
            this.blendState.EquationMode = BlendEquationMode.ReverseSubstract;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendEquation(TKBlendEquationMode.FuncReverseSubtract), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendEquationFuncSubtractWhenEquationModeIsSubtract()
        {
            // Arrange
            this.blendState.EquationMode = BlendEquationMode.Subtract;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendEquation(TKBlendEquationMode.FuncSubtract), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendEquationMaxWhenEquationModeIsMax()
        {
            // Arrange
            this.blendState.EquationMode = BlendEquationMode.Max;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendEquation(TKBlendEquationMode.Max), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendEquationMinWhenEquationModeIsMin()
        {
            // Arrange
            this.blendState.EquationMode = BlendEquationMode.Min;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendEquation(TKBlendEquationMode.Min), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncDstAlphaAndConstantAlphaWhenSourceModeIsDestinationAlphaAndDestinationModeIsConstantAlpha()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.DestinationAlpha;
            this.blendState.DestinationMode = BlendMode.ConstantAlpha;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.DstAlpha, BlendingFactor.ConstantAlpha), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncOneAndDstColorWhenSourceModeIsOneAndDestinationModeIsDestinationColor()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.One;
            this.blendState.DestinationMode = BlendMode.DestinationColor;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.One, BlendingFactor.DstColor), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncOneMinusConstantColorAndOneMinusConstantAlphaWhenSourceModeIsOneMinusConstantColorAndDestinationModeIsOneMinusConstantAlpha()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.OneMinusConstantColor;
            this.blendState.DestinationMode = BlendMode.OneMinusConstantAlpha;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.OneMinusConstantColor, BlendingFactor.OneMinusConstantAlpha), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncOneMinusDstColorAndOneMinusDstAlphaWhenSourceModeIsOneMinusDestinationColorAndDestinationModeIsOneMinusDestinationAlpha()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.OneMinusDestinationColor;
            this.blendState.DestinationMode = BlendMode.OneMinusDestinationAlpha;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.OneMinusDstColor, BlendingFactor.OneMinusDstAlpha), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncOneMinusSrcColorAndOneMinusSrcAlphaWhenSourceModeIsOneMinusSourceColorAndDestinationModeIsOneMinusSourceAlpha()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.OneMinusSourceColor;
            this.blendState.DestinationMode = BlendMode.OneMinusSourceAlpha;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.OneMinusSrcColor, BlendingFactor.OneMinusSrcAlpha), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncSrcAlphaSaturateAndSrcAlphaWhenSourceModeIsSourceAlphaSaturateAndDestinationModeIsSourceAlpha()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.SourceAlphaSaturate;
            this.blendState.DestinationMode = BlendMode.SourceAlpha;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.SrcAlphaSaturate, BlendingFactor.SrcAlpha), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeBlendFuncZeroAndSrcColorWhenSourceModeIsZeroAndDestinationModeIsSourceColor()
        {
            // Arrange
            this.blendState.SourceMode = BlendMode.Zero;
            this.blendState.DestinationMode = BlendMode.SourceColor;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.BlendFunc(BlendingFactor.Zero, BlendingFactor.SrcColor), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeDisableBlendWhenBlendStateIsDisabled()
        {
            // Arrange
            this.blendState.Enabled = false;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.Blend), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldInvokeEnableBlendWhenBlendStateIsEnabled()
        {
            // Arrange
            this.blendState.Enabled = true;

            // Act
            this.outputMerger.SetBlendState(this.blendState);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.Blend), Times.Once);
        }

        [Test]
        public void SetBlendStateShouldThrowNotSupportedExceptionWhenBlendEquationIsInvalidEnum()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(BlendEquationMode), int.MaxValue));

            this.blendState.EquationMode = (BlendEquationMode)int.MaxValue;

            // Act and assert
            Assert.Throws<NotSupportedException>(() => this.outputMerger.SetBlendState(this.blendState));
        }

        [Test]
        public void SetBlendStateShouldThrowNotSupportedExceptionWhenDestinationModeIsInvalidEnum()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(BlendMode), int.MaxValue));

            this.blendState.DestinationMode = (BlendMode)int.MaxValue;

            // Assert
            Assert.Throws<NotSupportedException>(() => this.outputMerger.SetBlendState(this.blendState));
        }

        [Test]
        public void SetBlendStateShouldThrowNotSupportedExceptionWhenSourceModeIsInvalidEnum()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(BlendMode), int.MaxValue));

            this.blendState.SourceMode = (BlendMode)int.MaxValue;

            // Assert
            Assert.Throws<NotSupportedException>(() => this.outputMerger.SetBlendState(this.blendState));
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncAlwaysWhenComparisonModeIsAlways()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.Always;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Always), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncEqualWhenComparisonModeIsEqual()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.Equal;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Equal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncGequalWhenComparisonModeIsGreaterEqual()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.GreaterEqual;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Gequal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncGreaterWhenComparisonModeIsGreater()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.Greater;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Greater), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncLequalWhenComparisonModeIsLessEqual()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.LessEqual;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Lequal), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncLessWhenComparisonModeIsLess()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.Less;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Less), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthFuncNeverWhenComparisonModeIsNever()
        {
            // Arrange
            this.depthState.ComparisonMode = ComparisonMode.Never;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthFunc(DepthFunction.Never), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthMaskFalseWhenWriteEnabledIsFalse()
        {
            // Arrange
            this.depthState.WriteEnabled = false;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthMask(false), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDepthMaskTrueWhenWriteEnabledIsTrue()
        {
            // Arrange
            this.depthState.WriteEnabled = true;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.DepthMask(true), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeDisableDepthTestWhenReadEnabledIsFalse()
        {
            // Arrange
            this.depthState.ReadEnabled = false;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.DepthTest), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldInvokeEnableDepthTestWhenReadEnabledIsTrue()
        {
            // Arrange
            this.depthState.ReadEnabled = true;

            // Act
            this.outputMerger.SetDepthState(this.depthState);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.DepthTest), Times.Once);
        }

        [Test]
        public void SetDepthStateShouldThrowNotSupportedExceptionWhenComparisonModeIsInvalidEnum()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(ComparisonMode), int.MaxValue));

            this.depthState.ComparisonMode = (ComparisonMode)int.MaxValue;

            // Act and assert
            Assert.Throws<NotSupportedException>(() => this.outputMerger.SetDepthState(this.depthState));
        }

        [Test]
        public void SetStencilStateShouldInvokeDisableStencilTestWhenStencilStateIsDisabled()
        {
            // Arrange
            this.stencilState.Enabled = false;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.Disable(EnableCap.StencilTest), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeEnableStencilTestWhenStencilStateIsEnabled()
        {
            // Arrange
            this.stencilState.Enabled = true;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.Enable(EnableCap.StencilTest), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeStencilFuncWhenInvoked()
        {
            // Arrange
            this.stencilState.ComparisonMode = ComparisonMode.Greater;
            this.stencilState.ReferenceValue = 304;
            this.stencilState.ReadMask = 10;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.StencilFunc(StencilFunction.Greater, 304, 10), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeStencilMaskSevenWhenStencilStateWriteMaskIsSeven()
        {
            // Arrange
            this.stencilState.WriteMask = 7;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.StencilMask(7), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeStencilOpDecrDecrWrapIncrWhenStencilFailIsDecrementAndDepthFailIsDecrementWrapAndPassIsIncrement()
        {
            // Arrange
            this.stencilState.StencilFail = StencilOperation.Decrement;
            this.stencilState.DepthFail = StencilOperation.DecrementWrap;
            this.stencilState.Pass = StencilOperation.Increment;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.StencilOp(StencilOp.Decr, StencilOp.DecrWrap, StencilOp.Incr), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeStencilOpIncrWrapInvertKeepWhenStencilFailIsIncrementWrapAndDepthFailIsInvertAndPassIsKeep()
        {
            // Arrange
            this.stencilState.StencilFail = StencilOperation.IncrementWrap;
            this.stencilState.DepthFail = StencilOperation.Invert;
            this.stencilState.Pass = StencilOperation.Keep;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.StencilOp(StencilOp.IncrWrap, StencilOp.Invert, StencilOp.Keep), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldInvokeStencilOpKeepReplaceZeroWhenStencilFailIsKeepAndDepthFailIsReplaceAndPassIsZero()
        {
            // Arrange
            this.stencilState.StencilFail = StencilOperation.Keep;
            this.stencilState.DepthFail = StencilOperation.Replace;
            this.stencilState.Pass = StencilOperation.Zero;

            // Act
            this.outputMerger.SetStencilState(this.stencilState);

            // Assert
            this.invoker.Verify(x => x.StencilOp(StencilOp.Keep, StencilOp.Replace, StencilOp.Zero), Times.Once);
        }

        [Test]
        public void SetStencilStateShouldThrowNotSupportedExceptionWhenStencilOperationIsInvalidEnum()
        {
            // Arrange
            Assert.IsFalse(Enum.IsDefined(typeof(StencilOperation), int.MaxValue));

            this.stencilState.StencilFail = (StencilOperation)int.MaxValue;

            // Act and assert
            Assert.Throws<NotSupportedException>(() => this.outputMerger.SetStencilState(this.stencilState));
        }

        [SetUp]
        public void Setup()
        {
            this.invoker = new Mock<IOpenGLInvoker>();
            this.outputMerger = new OpenGLOutputMerger(this.invoker.Object);

            this.blendState = default;
            this.depthState = default;
            this.stencilState = default;
        }
    }
}