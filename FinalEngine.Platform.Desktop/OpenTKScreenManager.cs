namespace FinalEngine.Platform.Desktop
{
    using OpenTK;
    using Size = Drawing.Size;

    public sealed class OpenTKScreenManager : IScreenManager
    {
        private static OpenTKScreenManager instance;

        private OpenTKScreenManager()
        {
        }

        public static OpenTKScreenManager Instance
        {
            get
            {
                return instance ?? (instance = new OpenTKScreenManager());
            }
        }

        public bool TryGetScreenByIndex(uint index, out Screen screen)
        {
            var device = DisplayDevice.GetDisplay(DisplayIndex.Primary + (int)index);

            if (device == null)
            {
                screen = default;
                return false;
            }

            screen = new Screen(new Size(device.Width, device.Height));
            return true;
        }
    }
}