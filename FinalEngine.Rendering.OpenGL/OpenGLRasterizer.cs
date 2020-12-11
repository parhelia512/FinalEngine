// <copyright file="OpenGLRasterizer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
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

            this.invoker.CullFace(description.CullMode == FaceCullMode.Back ? CullFaceMode.Back : CullFaceMode.Front);
            this.invoker.FrontFace(description.WindingDirection == WindingDirection.Clockwise ? FrontFaceDirection.Cw : FrontFaceDirection.Ccw);
            this.invoker.PolygonMode(MaterialFace.FrontAndBack, description.FillMode == RasterMode.Solid ? PolygonMode.Fill : PolygonMode.Line);
        }

        public void SetScissor(Rectangle rectangle)
        {
            this.invoker.Scissor(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public void SetViewport(Rectangle rectangle, float near = 0.0f, float far = 1.0f)
        {
            this.invoker.Viewport(rectangle);
            this.invoker.DepthRange(near, far);
        }
    }
}