namespace FinalEngine.Rendering.OpenGL.Invoking
{
    using OpenTK.Graphics.OpenGL;

    /// <summary>
    ///   Defines an interface that provides a means of access to OpenGL functions.
    /// </summary>
    public interface IOpenGLInvoker
    {
        /// <summary>
        ///   Disables the specified graphics library server-side capibility, <paramref name="cap"/>.
        /// </summary>
        /// <param name="cap">
        ///   Specifies a <see cref="EnableCap"/> that represents a symbolic constant indicating a graphics library capability..
        /// </param>
        void Disable(EnableCap cap);

        /// <summary>
        ///   Enables the specified graphics library server-side capibility, <paramref name="cap"/>.
        /// </summary>
        /// <param name="cap">
        ///   Specifies a <see cref="EnableCap"/> that represents a symbolic constant indicating a graphics library capability.
        /// </param>
        void Enable(EnableCap cap);

        /// <summary>
        ///   Controls the interpretation of polygons for rasterization.
        /// </summary>
        /// <param name="face">
        ///   Specifies a <see cref="MaterialFace"/> that represents the face of a polygon that the specified <paramref name="mode"/> applies too.
        /// </param>
        /// <param name="mode">
        ///   Specifies a <see cref="PolygonMode"/> that represents how polygons will be rasterized.
        /// </param>
        void PolygonMode(MaterialFace face, PolygonMode mode);

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
        void Viewport(int x, int y, int width, int height);
    }
}