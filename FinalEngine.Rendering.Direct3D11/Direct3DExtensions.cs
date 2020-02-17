// <copyright file="Direct3DExtensions.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Direct3D11
{
    using System;
    using Vortice.Direct3D11;

    internal static class Direct3DExtensions
    {
        public static CullMode ToDirect3D(this FaceCullMode mode)
        {
            switch (mode)
            {
                case FaceCullMode.Back:
                    return CullMode.Back;

                case FaceCullMode.Front:
                    return CullMode.Front;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} parameter is not supported in the Direct3D 11 backend.");
            }
        }

        public static FillMode ToDirect3D(this RasterMode mode)
        {
            switch (mode)
            {
                case RasterMode.Solid:
                    return FillMode.Solid;

                case RasterMode.Wireframe:
                    return FillMode.Wireframe;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} parameter is not supported in the Direct3D 11 backend.");
            }
        }
    }
}