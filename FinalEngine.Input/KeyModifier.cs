namespace FinalEngine.Input
{
    using System;

    /// <summary>
    ///   Enumerates the available modifier keys on a standard keyboard.
    /// </summary>
    [Flags]
    public enum KeyModifier
    {
        /// <summary>
        ///   Specifies the shift key.
        /// </summary>
        Shift,

        /// <summary>
        ///   Specifies the control key.
        /// </summary>
        Control,

        /// <summary>
        ///   Specifies the ALT key.
        /// </summary>
        Alt,

        /// <summary>
        ///   Specifies the OS-specific key.
        /// </summary>
        /// <remarks>
        ///   On Windows, the modifier should be a Windows key, whereas on Macintosh it would be the Command key.
        /// </remarks>
        OS
    }
}