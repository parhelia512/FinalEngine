// <copyright file="IBatcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering.Buffers;

    /// <summary>
    ///   Defines an interface that provides a way to batch rendering calls.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.IResetable"/>
    public interface IBatcher : IResetable
    {
        int MaxIndexCount { get; }

        int MaxVertexCount { get; }

        /// <summary>
        ///   Batches a rendering call.
        /// </summary>
        /// <param name="textureID">
        ///   The texture identifier to batch.
        /// </param>
        /// <param name="color">
        ///   The color of the texture.
        /// </param>
        /// <param name="origin">
        ///   The origin of the texture.
        /// </param>
        /// <param name="position">
        ///   The position of the texture.
        /// </param>
        /// <param name="rotation">
        ///   The rotation of the texture.
        /// </param>
        /// <param name="scale">
        ///   The scale of the texture.
        /// </param>
        void Batch(float textureID, Color color, Vector2 origin, Vector2 position, float rotation, Vector2 scale);

        /// <summary>
        ///   Processes the batch, by updating the contents of the vertex buffer.
        /// </summary>
        /// <param name="vertexBuffer">
        ///   The vertex buffer to update the contents of.
        /// </param>
        void ProcessBatch(IVertexBuffer vertexBuffer);
    }
}