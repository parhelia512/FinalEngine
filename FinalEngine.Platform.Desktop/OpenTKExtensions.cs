namespace FinalEngine.Platform.Desktop
{
    using FinalEngine.Drawing;
    using TKPoint = OpenTK.Point;
    using TKPointF = OpenTK.PointF;
    using TKRectangle = OpenTK.Rectangle;
    using TKRectangleF = OpenTK.RectangleF;
    using TKSize = OpenTK.Size;
    using TKSizeF = OpenTK.SizeF;

    public static class OpenTKExtensions
    {
        public static Point ToPoint(this TKPoint point)
        {
            return new Point(point.X, point.Y);
        }

        public static PointF ToPointF(this TKPointF point)
        {
            return new PointF(point.X, point.Y);
        }

        public static Rectangle ToRectangle(this TKRectangle rectangle)
        {
            return new Rectangle(rectangle.Location.ToPoint(), rectangle.Size.ToSize());
        }

        public static RectangleF ToRectangleF(this TKRectangleF rectangle)
        {
            return new RectangleF(rectangle.Location.ToPointF(), rectangle.Size.ToSizeF());
        }

        public static Size ToSize(this TKSize size)
        {
            return new Size(size.Width, size.Height);
        }

        public static SizeF ToSizeF(this TKSizeF size)
        {
            return new SizeF(size.Width, size.Height);
        }

        public static TKPoint ToTKPoint(this Point point)
        {
            return new TKPoint(point.X, point.Y);
        }

        public static TKPointF ToTKPointF(this PointF point)
        {
            return new TKPointF(point.X, point.Y);
        }

        public static TKRectangle ToTKRectangle(this Rectangle rectangle)
        {
            return new TKRectangle(rectangle.Location.ToTKPoint(), rectangle.Size.ToTKSize());
        }

        public static TKRectangleF ToTKRectangleF(this RectangleF rectangle)
        {
            return new TKRectangleF(rectangle.Location.ToTKPointF(), rectangle.Size.ToTKSizeF());
        }

        public static TKSize ToTKSize(this Size size)
        {
            return new TKSize(size.Width, size.Height);
        }

        public static TKSizeF ToTKSizeF(this SizeF size)
        {
            return new TKSizeF(size.Width, size.Height);
        }
    }
}