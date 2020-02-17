// <copyright file="LockableKeyState.cs" company="MTO Software">
//     Copyright (c) MTO Software. All rights reserved.
// </copyright>

namespace FinalEngine.Input
{
    /// <summary>
    ///   Enumerates the available states of a lockable key.
    /// </summary>
    public enum LockableKeyState
    {
        /// <summary>
        ///   Specifies the key is in an unknown state.
        /// </summary>
        Unknown,

        /// <summary>
        ///   Specifies the key is in a locked state.
        /// </summary>
        Locked,

        /// <summary>
        ///   Specifies the key is in an unlocked state.
        /// </summary>
        Unlocked,
    }
}