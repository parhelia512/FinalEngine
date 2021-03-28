// <copyright file="IResetable.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    /// <summary>
    ///   Defines an interface that provides a method for reseting its self.
    /// </summary>
    public interface IResetable
    {
        /// <summary>
        ///   Gets a value indicating whether <see cref="Reset"/> should be called.
        /// </summary>
        /// <value>
        ///   <c>true</c> if <see cref="Reset"/> should be called; otherwise, <c>false</c>.
        /// </value>
        bool ShouldReset { get; }

        /// <summary>
        ///   Resets this instance.
        /// </summary>
        void Reset();
    }
}