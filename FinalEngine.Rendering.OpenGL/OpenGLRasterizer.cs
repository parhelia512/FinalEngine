// <copyright file="OpenGLRasterizer.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using System.Drawing;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Utilities;
    using OpenTK.Graphics.OpenGL4;

    public class OpenGLRasterizer : IRasterizer
    {
        private readonly IOpenGLInvoker invoker;

        private readonly IEnumMapper mapper;

        public OpenGLRasterizer(IOpenGLInvoker invoker, IEnumMapper mapper)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void SetRasterState(RasterStateDescription description)
        {
            this.invoker.Switch(EnableCap.CullFace, description.CullEnabled);
            this.invoker.Switch(EnableCap.ScissorTest, description.ScissorEnabled);
            this.invoker.CullFace(this.mapper.Forward<CullFaceMode>(description.CullMode));
            this.invoker.FrontFace(this.mapper.Forward<FrontFaceDirection>(description.WindingDirection));
            this.invoker.PolygonMode(MaterialFace.FrontAndBack, this.mapper.Forward<PolygonMode>(description.FillMode));
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