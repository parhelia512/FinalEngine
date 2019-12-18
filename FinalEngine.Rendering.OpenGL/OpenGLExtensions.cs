namespace FinalEngine.Rendering.OpenGL
{
    using System;
    using OpenTK.Graphics.OpenGL;
    using GLFaceCullMode = OpenTK.Graphics.OpenGL.CullFaceMode;

    public static class OpenGLExtensions
    {
        public static FrontFaceDirection ToOpenGL(this WindingDirection direction)
        {
            switch (direction)
            {
                case WindingDirection.Clockwise:
                    return FrontFaceDirection.Cw;

                case WindingDirection.CounterClockwise:
                    return FrontFaceDirection.Ccw;

                default:
                    throw new NotSupportedException($"The specified { nameof(direction) } parameter is not supported in the OpenGL backend.");
            }
        }

        public static GLFaceCullMode ToOpenGL(this FaceCullMode mode)
        {
            switch (mode)
            {
                case FaceCullMode.Back:
                    return GLFaceCullMode.Back;

                case FaceCullMode.Front:
                    return GLFaceCullMode.Front;

                default:
                    throw new NotSupportedException($"The specified { nameof(mode) } parameter is not supported in the OpenGL backend.");
            }
        }

        public static PolygonMode ToOpenGL(this RasterMode mode)
        {
            switch (mode)
            {
                case RasterMode.Solid:
                    return PolygonMode.Fill;

                case RasterMode.Wireframe:
                    return PolygonMode.Line;

                default:
                    throw new NotSupportedException($"The specified { nameof(mode) } parameter is not supported in the OpenGL backend.");
            }
        }
    }
}