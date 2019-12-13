namespace FinalEngine.Platform.Windows
{
    using FinalEngine.Drawing;
    using SDPoint = System.Drawing.Point;
    using SDRectangle = System.Drawing.Rectangle;
    using SDSize = System.Drawing.Size;

    internal static class DrawingExtensions
    {
        internal static Point ToFinalEngineDrawingPoint(this SDPoint point)
        {
            return new Point(point.X, point.Y);
        }

        internal static Rectangle ToFinalEngineDrawingRectangle(this SDRectangle rectangle)
        {
            return new Rectangle(new Point(rectangle.X, rectangle.Y), new Size(rectangle.Width, rectangle.Height));
        }

        internal static Size ToFinalEngineDrawingSize(this SDSize size)
        {
            return new Size(size.Width, size.Height);
        }

        internal static SDPoint ToSystemDrawingPoint(this Point point)
        {
            return new SDPoint(point.X, point.Y);
        }

        internal static SDSize ToSystemDrawingSize(this Size size)
        {
            return new SDSize(size.Width, size.Height);
        }
    }
}