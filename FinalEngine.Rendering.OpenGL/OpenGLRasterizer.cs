// <copyright file="OpenGLRasterizer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
    using FinalEngine.Rendering.OpenGL.Extensions;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLRasterizer : IRasterizer
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLRasterizer(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
        }

        public void SetRasterState(RasterStateDescription description)
        {
            if (description.CullEnabled)
            {
                this.invoker.Enable(EnableCap.CullFace);
            }
            else
            {
                this.invoker.Disable(EnableCap.CullFace);
            }

            if (description.ScissorEnabled)
            {
                this.invoker.Enable(EnableCap.ScissorTest);
            }
            else
            {
                this.invoker.Disable(EnableCap.ScissorTest);
            }

            this.invoker.CullFace(description.CullMode.ToOpenTK());
            this.invoker.FrontFace(description.WindingDirection.ToOpenTK());
            this.invoker.PolygonMode(MaterialFace.FrontAndBack, description.FillMode.ToOpenTK());
        }

        public void SetViewport(Rectangle rectangle)
        {
            this.invoker.Viewport(rectangle);
        }
    }
}