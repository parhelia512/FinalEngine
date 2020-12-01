// <copyright file="OpenTKExtensions.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OpenTK.Graphics.OpenGL4;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:Elements should be documented", Justification = "Pointless")]
    public static class OpenTKExtensions
    {
        public static PrimitiveType ToOpenTK(this PrimitiveTopology topology)
        {
            switch (topology)
            {
                case PrimitiveTopology.Line:
                    return PrimitiveType.Lines;

                case PrimitiveTopology.LineStrip:
                    return PrimitiveType.LineStrip;

                case PrimitiveTopology.Triangle:
                    return PrimitiveType.Triangles;

                case PrimitiveTopology.TriangleStrip:
                    return PrimitiveType.TriangleStrip;

                default:
                    throw new NotSupportedException($"The specified {nameof(topology)} parameter is not supported in the OpenTK backend.");
            }
        }

        public static PolygonMode ToOpenTK(this RasterMode mode)
        {
            switch (mode)
            {
                case RasterMode.Solid:
                    return PolygonMode.Fill;

                case RasterMode.Wireframe:
                    return PolygonMode.Line;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} parameter is not supported in the OpenTK backend.");
            }
        }

        public static FrontFaceDirection ToOpenTK(this WindingDirection direction)
        {
            switch (direction)
            {
                case WindingDirection.Clockwise:
                    return FrontFaceDirection.Cw;

                case WindingDirection.CounterClockwise:
                    return FrontFaceDirection.Ccw;

                default:
                    throw new NotSupportedException($"The specified {nameof(direction)} parameter is not supported in the OpenTK backend.");
            }
        }

        public static CullFaceMode ToOpenTK(this FaceCullMode mode)
        {
            switch (mode)
            {
                case FaceCullMode.Back:
                    return CullFaceMode.Back;

                case FaceCullMode.Front:
                    return CullFaceMode.Front;

                default:
                    throw new NotSupportedException($"The specified {nameof(mode)} parameter is not supported in the OpenTK backend.");
            }
        }
    }
}