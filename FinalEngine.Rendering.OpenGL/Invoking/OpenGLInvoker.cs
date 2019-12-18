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
        ///   Specifies whether front or back facing facets are culled.
        /// </summary>
        /// <param name="mode">
        ///   Specifies a <see cref="CullFaceMode"/> that represents the faces that will be culled.
        /// </param>
        public void CullFace(CullFaceMode mode)
        {
            GL.CullFace(mode);
        }

        /// <summary>
        ///   Disables the specified graphics library server-side capibility, <paramref name="cap"/>.
        /// </summary>
        /// <param name="cap">
        ///   Specifies a <see cref="EnableCap"/> that represents a symbolic constant indicating a graphics library capability..
        /// </param>
        public void Disable(EnableCap cap)
        {
            GL.Disable(cap);
        }

        /// <summary>
        ///   Enables the specified graphics library server-side capibility, <paramref name="cap"/>.
        /// </summary>
        /// <param name="cap">
        ///   Specifies a <see cref="EnableCap"/> that represents a symbolic constant indicating a graphics library capability.
        /// </param>
        public void Enable(EnableCap cap)
        {
            GL.Enable(cap);
        }

        /// <summary>
        ///   Defines front and back facing primitives by their winding direction.
        /// </summary>
        /// <param name="direction">
        ///   Specifies a <see cref="FrontFaceDirection"/> that represents the orientation of front-facing polygons.
        /// </param>
        public void FrontFace(FrontFaceDirection direction)
        {
            GL.FrontFace(direction);
        }

        /// <summary>
        ///   Controls the interpretation of polygons for rasterization.
        /// </summary>
        /// <param name="face">
        ///   Specifies a <see cref="MaterialFace"/> that represents the face of a polygon that the specified <paramref name="mode"/> applies too.
        /// </param>
        /// <param name="mode">
        ///   Specifies a <see cref="PolygonMode"/> that represents how polygons will be rasterized.
        /// </param>
        public void PolygonMode(MaterialFace face, PolygonMode mode)
        {
            GL.PolygonMode(face, mode);
        }

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