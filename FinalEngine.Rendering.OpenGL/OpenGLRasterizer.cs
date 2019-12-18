namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using FinalEngine.Rendering.OpenGL.Invoking;

    public sealed class OpenGLRasterizer : IRasterizer
    {
        private readonly IOpenGLInvoker invoker;

        public OpenGLRasterizer(IOpenGLInvoker invoker)
        {
            this.invoker = invoker ?? throw new ArgumentNullException(nameof(invoker), $"The specified { nameof(invoker) } parameter is null.");
        }

        public void SetViewport(int x, int y, int width, int height)
        {
            throw new System.NotImplementedException();
        }
    }
}