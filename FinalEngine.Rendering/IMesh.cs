// <copyright file="IMesh.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    public interface IMesh : IDisposable
    {
        void Draw(IRenderDevice renderDevice);

        void Set(IInputAssembler inputAssembler);
    }
}