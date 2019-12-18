namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using Vortice.Direct3D11;

    public interface ID3D11DeviceContextInvoker
    {
        void RSSetState(ID3D11RasterizerState state);

        void RSSetViewport(float x, float y, float width, float height);
    }
}