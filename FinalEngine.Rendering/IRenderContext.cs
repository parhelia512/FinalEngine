// <copyright file="IRenderContext.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;

    public interface IRenderContext : IDisposable
    {
        void SwapBuffers();
    }
}