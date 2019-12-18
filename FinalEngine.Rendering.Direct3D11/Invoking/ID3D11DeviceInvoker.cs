namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using Vortice.Direct3D11;

    public interface ID3D11DeviceInvoker
    {
        ID3D11RasterizerState CreateRasterizerState(RasterizerDescription description);
    }
}