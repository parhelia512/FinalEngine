// <copyright file="IScreenManager.cs" company="MTO Software">
// Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Platform
{
    /// <summary>
    ///   Defines an interface that provides methods for accessing and potentially changing the state of a display device.
    /// </summary>
    public interface IScreenManager
    {
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
        bool TryGetScreenByIndex(uint index, out Screen screen);
    }
}