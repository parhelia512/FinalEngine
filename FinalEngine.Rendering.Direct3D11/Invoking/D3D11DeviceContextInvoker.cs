namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using System;
    using Vortice.Direct3D11;

    public sealed class D3D11DeviceContextInvoker : ID3D11DeviceContextInvoker
    {
        private readonly ID3D11DeviceContext deviceContext;

        public D3D11DeviceContextInvoker(ID3D11DeviceContext deviceContext)
        {
            this.deviceContext = deviceContext ?? throw new ArgumentNullException(nameof(deviceContext), $"The specified { nameof(deviceContext) } parameter is null.");
        }

        public void RSSetViewport(float x, float y, float width, float height)
        {
            deviceContext.RSSetViewport(x, y, width, height);
        }
    }
}