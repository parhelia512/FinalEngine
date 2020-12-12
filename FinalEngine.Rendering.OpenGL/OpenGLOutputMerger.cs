// <copyright file="OpenGLOutputMerger.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;
    using BlendEquationMode = FinalEngine.Rendering.BlendEquationMode;
    using TKBlendEquationMode = OpenTK.Graphics.OpenGL4.BlendEquationMode;

    public class OpenGLOutputMerger : IOutputMerger
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLOutputMerger(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        public void SetBlendState(BlendStateDescription description)
        {
            if (description.Enabled)
            {
                this.invoker.Enable(EnableCap.Blend);
            }
            else
            {
                this.invoker.Disable(EnableCap.Blend);
            }

            this.invoker.BlendColor(description.Color);
            this.invoker.BlendEquation(GetOpenGLBlendEquationMode(description.EquationMode));
            this.invoker.BlendFunc(GetOpenGLBlendingFactor(description.SourceMode), GetOpenGLBlendingFactor(description.DestinationMode));
        }

        public void SetDepthState(DepthStateDescription description)
        {
            if (description.ReadEnabled)
            {
                this.invoker.Enable(EnableCap.DepthTest);
            }
            else
            {
                this.invoker.Disable(EnableCap.DepthTest);
            }

            this.invoker.DepthMask(description.WriteEnabled);
            this.invoker.DepthFunc(GetOpenGLFunction<DepthFunction>(description.ComparisonMode));
        }

        public void SetStencilState(StencilStateDescription description)
        {
            if (description.Enabled)
            {
                this.invoker.Enable(EnableCap.StencilTest);
            }
            else
            {
                this.invoker.Disable(EnableCap.StencilTest);
            }

            this.invoker.StencilMask(description.WriteMask);
            this.invoker.StencilFunc(GetOpenGLFunction<StencilFunction>(description.ComparisonMode), description.ReferenceValue, description.ReadMask);
            this.invoker.StencilOp(GetOpenGLStencilOp(description.StencilFail), GetOpenGLStencilOp(description.DepthFail), GetOpenGLStencilOp(description.Pass));
        }

        private static TKBlendEquationMode GetOpenGLBlendEquationMode(BlendEquationMode mode)
        {
            switch (mode)
            {
                case BlendEquationMode.Add:
                    return TKBlendEquationMode.FuncAdd;

                case BlendEquationMode.Max:
                    return TKBlendEquationMode.Max;

                case BlendEquationMode.Min:
                    return TKBlendEquationMode.Min;

                case BlendEquationMode.ReverseSubstract:
                    return TKBlendEquationMode.FuncReverseSubtract;

                case BlendEquationMode.Subtract:
                    return TKBlendEquationMode.FuncSubtract;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} is not supported by the OpenGL Backend.");
            }
        }

        private static BlendingFactor GetOpenGLBlendingFactor(BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.Zero:
                    return BlendingFactor.Zero;

                case BlendMode.SourceColor:
                    return BlendingFactor.SrcColor;

                case BlendMode.SourceAlphaSaturate:
                    return BlendingFactor.SrcAlphaSaturate;

                case BlendMode.SourceAlpha:
                    return BlendingFactor.SrcAlpha;

                case BlendMode.OneMinusSourceColor:
                    return BlendingFactor.OneMinusSrcColor;

                case BlendMode.OneMinusSourceAlpha:
                    return BlendingFactor.OneMinusSrcAlpha;

                case BlendMode.OneMinusDestinationColor:
                    return BlendingFactor.OneMinusDstColor;

                case BlendMode.OneMinusDestinationAlpha:
                    return BlendingFactor.OneMinusDstAlpha;

                case BlendMode.OneMinusConstantColor:
                    return BlendingFactor.OneMinusConstantColor;

                case BlendMode.OneMinusConstantAlpha:
                    return BlendingFactor.OneMinusConstantAlpha;

                case BlendMode.One:
                    return BlendingFactor.One;

                case BlendMode.DestinationColor:
                    return BlendingFactor.DstColor;

                case BlendMode.DestinationAlpha:
                    return BlendingFactor.DstAlpha;

                case BlendMode.ConstantAlpha:
                    return BlendingFactor.ConstantAlpha;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} is not supported by the OpenGL Backend.");
            }
        }

        private static T GetOpenGLFunction<T>(ComparisonMode mode)
                            where T : Enum
        {
            switch (mode)
            {
                case ComparisonMode.Always:
                    return ParseEnum<T>(nameof(All.Always));

                case ComparisonMode.Equal:
                    return ParseEnum<T>(nameof(All.Equal));

                case ComparisonMode.Greater:
                    return ParseEnum<T>(nameof(All.Greater));

                case ComparisonMode.GreaterEqual:
                    return ParseEnum<T>(nameof(All.Gequal));

                case ComparisonMode.Less:
                    return ParseEnum<T>(nameof(All.Less));

                case ComparisonMode.LessEqual:
                    return ParseEnum<T>(nameof(All.Lequal));

                case ComparisonMode.Never:
                    return ParseEnum<T>(nameof(All.Never));

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} is not supported by the OpenGL Backend.");
            }
        }

        private static StencilOp GetOpenGLStencilOp(StencilOperation operation)
        {
            switch (operation)
            {
                case StencilOperation.Decrement:
                    return StencilOp.Decr;

                case StencilOperation.DecrementWrap:
                    return StencilOp.DecrWrap;

                case StencilOperation.Increment:
                    return StencilOp.Incr;

                case StencilOperation.IncrementWrap:
                    return StencilOp.IncrWrap;

                case StencilOperation.Invert:
                    return StencilOp.Invert;

                case StencilOperation.Keep:
                    return StencilOp.Keep;

                case StencilOperation.Replace:
                    return StencilOp.Replace;

                case StencilOperation.Zero:
                    return StencilOp.Zero;

                default:
                    throw new NotSupportedException($"The specified {nameof(operation)} is not supported by the OpenGL Backend.");
            }
        }

        private static T ParseEnum<T>(string name)
                    where T : Enum
        {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}