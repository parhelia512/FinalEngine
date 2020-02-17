// <copyright file="RasterStateDescription.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    /// <summary>
    ///   Enumerates the available modes used to determine which primitives will not be drawn by a rasterizer.
    /// </summary>
    public enum FaceCullMode
    {
        /// <summary>
        ///   Specifies that front facing primitives will not be drawn.
        /// </summary>
        Front,

        /// <summary>
        ///   Specifies that back facing primitives will not be drawn.
        /// </summary>
        Back,
    }

    /// <summary>
    ///   Enumerates the available modes used to determine how a rasterizer will draw polygons.
    /// </summary>
    public enum RasterMode
    {
        /// <summary>
        ///   Specifies the polygons will be drawn as solid and filled meshes.
        /// </summary>
        Solid,

        /// <summary>
        ///   Specifies the polygons will be drawn as wireframe meshes.
        /// </summary>
        Wireframe,
    }

    /// <summary>
    ///   Enumerates the available directions used to determine the front face of a primitive.
    /// </summary>
    public enum WindingDirection
    {
        /// <summary>
        ///   Specifies a clockwise winding order.
        /// </summary>
        Clockwise,

        /// <summary>
        ///   Specifies a counter clockwise winding order.
        /// </summary>
        CounterClockwise,
    }

    /// <summary>
    ///   Represents a description of the internal state of the rasterization stage of a rendering pipeline.
    /// </summary>
    public struct RasterStateDescription
    {
        /// <summary>
        ///   Gets a <see cref="RasterStateDescription"/> that represents the default state of a rasterizer.
        /// </summary>
        /// <value>
        ///   The default state of a rasterizer.
        /// </value>
        public static RasterStateDescription Default
        {
            get
            {
                return new RasterStateDescription()
                {
                    CullEnabled = false,
                    FaceCullMode = FaceCullMode.Back,
                    FillMode = RasterMode.Solid,
                    WindingDirection = WindingDirection.CounterClockwise,
                };
            }
        }

        /// <summary>
        ///   Gets or sets a value indicating whether culling is enabled for the rasterizer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if culling is enabled for the rasterizer; otherwise, <c>false</c>.
        /// </value>
        public bool CullEnabled { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="FaceCullMode"/> that represents which primitives will not be drawn by the rasterizer.
        /// </summary>
        /// <value>
        ///   Which primitives will not be drawn by the rasterizer.
        /// </value>
        public FaceCullMode FaceCullMode { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="RasterMode"/> that represents how the rasterizer will draw polygons.
        /// </summary>
        /// <value>
        ///   How the rasterizer will draw polygons.
        /// </value>
        public RasterMode FillMode { get; set; }

        /// <summary>
        ///   Gets or sets a <see cref="WindingDirection"/> that represents the front face of a primitive.
        /// </summary>
        /// <value>
        ///   The front face of a primitive.
        /// </value>
        public WindingDirection WindingDirection { get; set; }
    }
}