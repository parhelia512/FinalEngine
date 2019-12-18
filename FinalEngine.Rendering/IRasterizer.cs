namespace FinalEngine.Rendering
{
    /// <summary>
    ///   Defines an interface that represents the rasterization stage of a rendering pipeline.
    /// </summary>
    public interface IRasterizer
    {
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
        void SetViewport(int x, int y, int width, int height);
    }
}