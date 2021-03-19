// <copyright file="ICamera.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Numerics;

    /// <summary>
    ///   Defines an interface that represents a camera.
    /// </summary>
    public interface ICamera
    {
        /// <summary>
        ///   Gets the projection matrix of the camera.
        /// </summary>
        /// <value>
        ///   The projection matrix.
        /// </value>
        Matrix4x4 Projection { get; }

        /// <summary>
        ///   Gets the view matrix of the camera.
        /// </summary>
        /// <value>
        ///   The view matrix.
        /// </value>
        Matrix4x4 View { get; }
    }
}