namespace FinalEngine.Rendering
{
    public enum FaceCullMode
    {
        Front,

        Back
    }

    public enum RasterMode
    {
        Solid,

        Wireframe
    }

    public enum WindingDirection
    {
        Clockwise,

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