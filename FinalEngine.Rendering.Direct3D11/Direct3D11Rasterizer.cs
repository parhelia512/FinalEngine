namespace FinalEngine.Rendering.Direct3D11
{
    using System;
    using FinalEngine.Rendering.Direct3D11.Invoking;

    public sealed class Direct3D11Rasterizer : IRasterizer
    {
        private readonly ID3D11DeviceContextInvoker deviceContext;

        public Direct3D11Rasterizer(ID3D11DeviceContextInvoker deviceContext)
        {
            this.deviceContext = deviceContext ?? throw new ArgumentNullException(nameof(deviceContext), $"The specified { nameof(deviceContext) } parameter is null.");

            SetRasterState(RasterStateDescription.Default);
        }

        public void SetRasterState(RasterStateDescription description)
        {
            throw new System.NotImplementedException();
        }

        public void SetViewport(int x, int y, int width, int height)
        {
            deviceContext.RSSetViewport(x, y, width, height);
        }
    }
}