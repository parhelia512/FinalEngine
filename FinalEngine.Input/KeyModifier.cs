namespace FinalEngine.Input
{
    using System;

    /// <summary>
    ///   Enumerates the available modifier keys on a standard US-keyboard.
    /// </summary>
    [Flags]
    public enum KeyModifier
    {
        /// <summary>
        ///   Specifies the shift key (left or right).
        /// </summary>
        Shift,

        /// <summary>
        ///   Specifies the control key (left or right).
        /// </summary>
        Control,

        /// <summary>
        ///   Specifies the ALT key (left or right).
        /// </summary>
        Alt
    }
}