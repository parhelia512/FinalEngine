namespace FinalEngine.Platform
{
    using FinalEngine.Drawing;

    public struct Screen
    {
        public Screen(Size size)
        {
            Size = size;
        }

        public Size Size { get; }
    }
}