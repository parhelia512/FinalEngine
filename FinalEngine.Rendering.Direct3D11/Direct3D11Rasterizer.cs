namespace FinalEngine.Rendering.Direct3D11
{
    using System;
    using FinalEngine.Rendering.Direct3D11.Invoking;
    using Vortice.Direct3D11;

    /// <summary>
    ///   Provides a Direct3D 11 implementation of an <see cref="IRasterizer"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.IRasterizer"/>
    public sealed class Direct3D11Rasterizer : IRasterizer
    {
        /// <summary>
        ///   The device invoker.
        /// </summary>
        private readonly ID3D11DeviceInvoker device;

        /// <summary>
        ///   The device context invoker.
        /// </summary>
        private readonly ID3D11DeviceContextInvoker deviceContext;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Direct3D11Rasterizer"/> class.
        /// </summary>
        /// <param name="device">
        ///   Specifies a <see cref="ID3D11DeviceInvoker"/> that represents the device invoker.
        /// </param>
        /// <param name="deviceContext">
        ///   Specifies a <see cref="ID3D11DeviceContextInvoker"/> that represents the device context invoker.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        ///   The specified <paramref name="device"/> or <paramref name="deviceContext"/> parameter(s) are null.
        /// </exception>
        public Direct3D11Rasterizer(ID3D11DeviceInvoker device, ID3D11DeviceContextInvoker deviceContext)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device), $"The specified { nameof(device) } parameter is null.");
            this.deviceContext = deviceContext ?? throw new ArgumentNullException(nameof(deviceContext), $"The specified { nameof(deviceContext) } parameter is null.");
        }

        /// <summary>
        ///   Sets the rasterization state, specified by <paramref name="description"/> to the rasterization stage of the rendering pipeline.
        /// </summary>
        /// <param name="description">
        ///   Specifies a <see cref="RasterizerDescription"/> that represents the description of the rasterization state.
        /// </param>
        public void SetRasterState(RasterStateDescription description)
        {
            ID3D11RasterizerState state = device.CreateRasterizerState(new RasterizerDescription()
            {
                CullMode = !description.CullEnabled ? CullMode.None : description.FaceCullMode.ToDirect3D(),
                FillMode = description.FillMode.ToDirect3D(),
                FrontCounterClockwise = description.WindingDirection == WindingDirection.Clockwise
            });

            deviceContext.RSSetState(state);

            state.Release();
        }

        /// <summary>
        ///   Sets the viewport, specified by the <paramref name="x"/>, <paramref name="y"/>, <paramref name="width"/> and <paramref name="height"/> parameters to the rasterization stage of the rendering pipeline.
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
        /// <remarks>
        ///   In Direct3D 11, the origin of the specified <paramref name="y"/> coordinate is located at the top left of the view.
        /// </remarks>
        public void SetViewport(int x, int y, int width, int height)
        {
            deviceContext.RSSetViewport(x, y, width, height);
        }
    }
}