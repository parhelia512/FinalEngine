// <copyright file="D3D11DeviceInvoker.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Direct3D11.Invoking
{
    using System;
    using Vortice.Direct3D11;

    /// <summary>
    ///   Provides a Direct3D 11 implementation of an <see cref="ID3D11DeviceInvoker"/>.
    /// </summary>
    /// <seealso cref="ID3D11DeviceInvoker"/>
    public sealed class D3D11DeviceInvoker : ID3D11DeviceInvoker
    {
        /// <summary>
        ///   The device.
        /// </summary>
        private readonly ID3D11Device device;

        /// <summary>
        ///   Initializes a new instance of the <see cref="D3D11DeviceInvoker"/> class.
        /// </summary>
        /// <param name="device">
        ///   Specifies a <see cref="ID3D11Device"/> that represents the device.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///   The specified <paramref name="device"/> parameter is null.
        /// </exception>
        public D3D11DeviceInvoker(ID3D11Device device)
        {
            this.device = device ?? throw new ArgumentNullException(nameof(device), $"The specified {nameof(device)} parameter is null.");
        }

        /// <summary>
        ///   Create a rasterizer state object that tells the rasterizer stage how to behave.
        /// </summary>
        /// <param name="description">
        ///   Specifies a <see cref="RasterizerDescription"/> that represents the description.
        /// </param>
        /// <returns>
        ///   The newly created <see cref="ID3D11RasterizerState"/> based on the specified <paramref name="description"/>.
        /// </returns>
        public ID3D11RasterizerState CreateRasterizerState(RasterizerDescription description)
        {
            return this.device.CreateRasterizerState(description);
        }
    }
}