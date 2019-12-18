namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using Vortice.Direct3D11;

    /// <summary>
    ///   Defines an interface that provide a means of access to a Direct3D 11 Device Context.
    /// </summary>
    public interface ID3D11DeviceContextInvoker
    {
        /// <summary>
        ///   Sets the rasterizer state for the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="state">
        ///   Specifies a <see cref="ID3D11RasterizerState"/> that represents the state.
        /// </param>
        void RSSetState(ID3D11RasterizerState state);

        /// <summary>
        ///   Binds an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="Single"/> that represents the X coordinate, in pixels.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="Single"/> that represents the Y coordinate, in pixels.
        /// </param>
        /// <param name="width">
        ///   Specifies a <see cref="Single"/> that represents the width, in pixels.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="Single"/> that represents the height, in pixels.
        /// </param>
        void RSSetViewport(float x, float y, float width, float height);
    }
}