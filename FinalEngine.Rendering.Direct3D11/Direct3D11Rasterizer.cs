namespace FinalEngine.Rendering.Direct3D11
{
    using System;
    using FinalEngine.Rendering.Direct3D11.Invoking;
    using Vortice.Direct3D11;

    public sealed class Direct3D11Rasterizer : IRasterizer
    {
        private readonly ID3D11DeviceInvoker device;

        private readonly ID3D11DeviceContextInvoker deviceContext;

        public Direct3D11Rasterizer(ID3D11DeviceInvoker device, ID3D11DeviceContextInvoker deviceContext)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device), $"The specified { nameof(device) } parameter is null.");
            this.deviceContext = deviceContext ?? throw new ArgumentNullException(nameof(deviceContext), $"The specified { nameof(deviceContext) } parameter is null.");

            SetRasterState(RasterStateDescription.Default);
        }

        public void SetRasterState(RasterStateDescription description)
        {
            ID3D11RasterizerState state = device.CreateRasterizerState(new RasterizerDescription()
            {
                CullMode = !description.CullEnabled ? CullMode.None : description.FaceCullMode.ToDirect3D(),
                FillMode = description.FillMode.ToDirect3D(),
                FrontCounterClockwise = description.WindingDirection == WindingDirection.Clockwise
            });

            deviceContext.RSSetState(state);

            state.Dispose();
        }

        public void SetViewport(int x, int y, int width, int height)
        {
            deviceContext.RSSetViewport(x, y, width, height);
        }
    }
}