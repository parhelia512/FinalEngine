// <copyright file="IInputAssembler.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using FinalEngine.Rendering.Buffers;

    public interface IInputAssembler
    {
        void SetIndexBuffer(IIndexBuffer buffer);

        void SetInputLayout(IInputLayout layout);

        void SetVertexBuffer(IVertexBuffer buffer);
    }
}