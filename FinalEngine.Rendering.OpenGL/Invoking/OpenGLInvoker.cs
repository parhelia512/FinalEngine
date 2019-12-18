namespace FinalEngine.Rendering.OpenGL.Invoking
{
    using OpenTK.Graphics.OpenGL;

    public sealed class OpenGLInvoker : IOpenGLInvoker
    {
        public void Viewport(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }
    }
}