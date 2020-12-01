// <copyright file="OpenGLRasterizer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
    using FinalEngine.Rendering.OpenGL.Invocation;

    public class OpenGLRasterizer : IRasterizer
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLRasterizer(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        public void SetRasterState(RasterStateDescription description)
        {
            throw new System.NotImplementedException();
        }

        public void SetViewport(Rectangle rectangle)
        {
            this.invoker.Viewport(rectangle);
        }
    }
}