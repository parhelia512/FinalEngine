// <copyright file="OpenGLRenderDevice.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invocation;

    public class OpenGLRenderDevice : IRenderDevice
    {
        public OpenGLRenderDevice(IOpenGLInvoker invoker)
        {
            if (invoker == null)
            {
                throw new ArgumentNullException(nameof(invoker));
            }

            this.Rasterizer = new OpenGLRasterizer(invoker);
        }

        public IRasterizer Rasterizer { get; }
    }
}