namespace FinalEngine.Rendering
{
    /// <summary>
    ///   Enumerates the available modes that determine which primitives will not be drawn by a rasterizer.
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
        Back
    }

    /// <summary>
    ///   Enumerates the available modes that determine how a rasterizer will draw polygons.
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
        Wireframe
    }

    /// <summary>
    ///   Enumerates the available directions used to determine the front face of a primitve.
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
        CounterClockwise
    }

    public struct RasterStateDescription
    {
        public bool CullEnabled { get; set; }

        public FaceCullMode FaceCullMode { get; set; }

        public RasterMode FillMode { get; set; }

        public WindingDirection WindingDirection { get; set; }
    }
}