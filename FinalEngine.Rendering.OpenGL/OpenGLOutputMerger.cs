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
    }
}