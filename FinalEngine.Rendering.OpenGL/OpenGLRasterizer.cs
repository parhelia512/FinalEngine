namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invoking;

    /// <summary>
    ///   Provides an OpenGL implementation of an <see cref="IRasterizer"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.IRasterizer"/>
    public sealed class OpenGLRasterizer : IRasterizer
    {
        /// <summary>
        ///   The OpenGL invoker.
        /// </summary>
        private readonly IOpenGLInvoker invoker;

        /// <summary>
        ///   Initializes a new instance of the <see cref="OpenGLRasterizer"/> class.
        /// </summary>
        /// <param name="invoker">
        ///   Specifies a <see cref="IOpenGLInvoker"/> that represents the OpenGL invoker.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="invoker"/> parameter is null.
        /// </exception>
        public OpenGLRasterizer(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified { nameof(invoker) } parameter is null.");
        }

        public void SetRasterState(RasterStateDescription description)
        {
        }

        /// <summary>
        ///   Binds the viewport, specified by the <paramref name="x"/>, <paramref name="y"/>, <paramref name="width"/> and <paramref name="height"/> parameters to the rasterization stage of the rendering pipeline.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="int"/> that represents the X-coordinate of the viewport, in pixels.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="int"/> that represents the Y-coordinate of the viewport, in pixels.
        /// </param>
        /// <param name="width">
        ///   Specifies a <see cref="int"/> that represents the width of the viewport, in pixels.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="int"/> that represents the height of the viewport, in pixels.
        /// </param>
        public void SetViewport(int x, int y, int width, int height)
        {
            invoker.Viewport(x, y, width, height);
        }
    }
}