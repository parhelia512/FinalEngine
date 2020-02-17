// <copyright file="D3D11DeviceContextInvoker.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using System;
    using Vortice.Direct3D11;

    /// <summary>
    ///   Provides a Direct3D 11 implementation of an <see cref="ID3D11DeviceContextInvoker"/>.
    /// </summary>
    /// <seealso cref="ID3D11DeviceContextInvoker"/>
    public sealed class D3D11DeviceContextInvoker : ID3D11DeviceContextInvoker
    {
        /// <summary>
        ///   The device context.
        /// </summary>
        private readonly ID3D11DeviceContext deviceContext;

        /// <summary>
        ///   Initializes a new instance of the <see cref="D3D11DeviceContextInvoker"/> class.
        /// </summary>
        /// <param name="deviceContext">
        ///   Specifies a <see cref="ID3D11DeviceContext"/> that represents the device context.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="deviceContext"/> parameter is null.
        /// </exception>
        public D3D11DeviceContextInvoker(ID3D11DeviceContext deviceContext)
        {
            this.deviceContext = deviceContext ?? throw new ArgumentNullException(nameof(deviceContext), $"The specified {nameof(deviceContext)} parameter is null.");
        }

        /// <summary>
        ///   Sets the rasterizer state for the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="state">
        ///   Specifies a <see cref="ID3D11RasterizerState"/> that represents the state.
        /// </param>
        public void RSSetState(ID3D11RasterizerState state)
        {
            this.deviceContext.RSSetState(state);
        }

        /// <summary>
        ///   Binds an array of viewports to the rasterizer stage of the pipeline.
        /// </summary>
        /// <param name="x">
        ///   Specifies a <see cref="float"/> that represents the X coordinate, in pixels.
        /// </param>
        /// <param name="y">
        ///   Specifies a <see cref="float"/> that represents the Y coordinate, in pixels.
        /// </param>
        /// <param name="width">
        ///   Specifies a <see cref="float"/> that represents the width, in pixels.
        /// </param>
        /// <param name="height">
        ///   Specifies a <see cref="float"/> that represents the height, in pixels.
        /// </param>
        public void RSSetViewport(float x, float y, float width, float height)
        {
            this.deviceContext.RSSetViewport(x, y, width, height);
        }
    }
}