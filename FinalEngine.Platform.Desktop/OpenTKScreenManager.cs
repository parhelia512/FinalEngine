namespace FinalEngine.Platform.Desktop
{
    using OpenTK;
    using Size = Drawing.Size;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IScreenManager"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Platform.IScreenManager"/>
    public sealed class OpenTKScreenManager : IScreenManager
    {
        /// <summary>
        ///   The instance.
        /// </summary>
        private static IScreenManager instance;

        /// <summary>
        ///   Prevents a default instance of the <see cref="OpenTKScreenManager"/> class from being created.
        /// </summary>
        private OpenTKScreenManager()
        {
        }

        /// <summary>
        ///   Gets a <see cref="IScreenManager"/> that represents the instance of this <see cref="OpenTKScreenManager"/>.
        /// </summary>
        /// <value>
        ///   The instance of this <see cref="OpenTKScreenManager"/>.
        /// </value>
        public static IScreenManager Instance
        {
            get
            {
                return instance ?? (instance = new OpenTKScreenManager());
            }
        }

        /// <summary>
        ///   Tries to get a <see cref="Screen"/> represented by the specified <paramref name="index"/> location.
        /// </summary>
        /// <param name="index">
        ///   Specifies a <see cref="uint"/> that represents the index.
        /// </param>
        /// <param name="screen">
        ///   Specifies a <see cref="Screen"/> that represents the screen.
        /// </param>
        /// <remarks>
        ///   On all platforms, you should be able to set the specified <paramref name="index"/> parameter to 0 to access the primary screen on the underlying platform.
        /// </remarks>
        /// <returns>
        ///   <c>true</c> if a <see cref="Screen"/> located at the specified <paramref name="index"/> could be found; otherwise, <c>false</c>.
        /// </returns>
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