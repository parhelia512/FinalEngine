// <copyright file="OpenGLOutputMerger.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLOutputMerger : IOutputMerger
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLOutputMerger(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
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

            DepthFunction function = DepthFunction.Less;

            switch (description.ComparisonMode)
            {
                case ComparisonMode.Less:
                    function = DepthFunction.Less;
                    break;

                case ComparisonMode.Always:
                    function = DepthFunction.Always;
                    break;

                case ComparisonMode.Equal:
                    function = DepthFunction.Equal;
                    break;

                case ComparisonMode.Greater:
                    function = DepthFunction.Greater;
                    break;

                case ComparisonMode.GreaterEqual:
                    function = DepthFunction.Gequal;
                    break;

                case ComparisonMode.LessEqual:
                    function = DepthFunction.Lequal;
                    break;

                case ComparisonMode.Never:
                    function = DepthFunction.Never;
                    break;
            }

            this.invoker.DepthFunc(function);
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

            StencilFunction function = StencilFunction.Always;

            switch (description.ComparisonMode)
            {
                case ComparisonMode.Less:
                    function = StencilFunction.Less;
                    break;

                case ComparisonMode.Always:
                    function = StencilFunction.Always;
                    break;

                case ComparisonMode.Equal:
                    function = StencilFunction.Equal;
                    break;

                case ComparisonMode.Greater:
                    function = StencilFunction.Greater;
                    break;

                case ComparisonMode.GreaterEqual:
                    function = StencilFunction.Gequal;
                    break;

                case ComparisonMode.LessEqual:
                    function = StencilFunction.Lequal;
                    break;

                case ComparisonMode.Never:
                    function = StencilFunction.Never;
                    break;
            }

            this.invoker.StencilFunc(function, description.ReferenceValue, description.ReadMask);
            this.invoker.StencilOp(GetStencilOp(description.StencilFail), GetStencilOp(description.DepthFail), GetStencilOp(description.Pass));
        }

        private static StencilOp GetStencilOp(StencilOperation operation)
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
    }
}