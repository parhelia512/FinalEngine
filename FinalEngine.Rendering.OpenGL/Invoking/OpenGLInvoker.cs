namespace FinalEngine.Rendering.OpenGL.Invoking
{
    using OpenTK.Graphics.OpenGL;

    /// <summary>
    ///   Provides an OpenGL implementation of an <see cref="IOpenGLInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.OpenGL.Invoking.IOpenGLInvoker"/>
    public sealed class OpenGLInvoker : IOpenGLInvoker
    {
        /// <summary>
        ///   Specifies the affine transformation of <paramref name="x"/> and <paramref name="y"/> from normalized device coordinates to window coordinates.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="int"/> that represents the X-coordinate of the viewport rectangle, in pixels.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="int"/> that represents the Y-coordinate (bottom left of the window) of the viewport rectangle, in pixels.
        /// </param>
        /// <param name="width">
        ///   Specifies a <see cref="int"/> that represents the width of the viewport rectangle, in pixels.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="int"/> that represents the height of the viewport rectangle, in pixels.
        /// </param>
        /// <remarks>
        ///   <see cref="ErrorCode.InvalidValue"/> is generated if either <paramref name="width"/> or <paramref name="height"/> is negative.
        /// </remarks>
        public void Viewport(int x, int y, int width, int height)
        {
            GL.Viewport(x, y, width, height);
        }
    }
}