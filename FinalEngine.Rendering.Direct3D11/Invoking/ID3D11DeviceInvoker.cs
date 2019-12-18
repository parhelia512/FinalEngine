namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using Vortice.Direct3D11;

    /// <summary>
    ///   Defines an interface that provides a means of access to a Direct3D 11 Device.
    /// </summary>
    public interface ID3D11DeviceInvoker
    {
        /// <summary>
        ///   Create a rasterizer state object that tells the rasterizer stage how to behave.
        /// </summary>
        /// <param name="description">
        ///   Specifies a <see cref="RasterizerDescription"/> that represents the description.
        /// </param>
        /// <returns>
        ///   The newly created <see cref="ID3D11RasterizerState"/> based on the specified <paramref name="description"/>.
        /// </returns>
        ID3D11RasterizerState CreateRasterizerState(RasterizerDescription description);
    }
}