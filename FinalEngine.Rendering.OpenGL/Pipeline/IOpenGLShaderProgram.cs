// <copyright file="IOpenGLShaderProgram.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Pipeline
{
    public interface IOpenGLShaderProgram
    {
        void Bind();

        int GetUniformLocation(string name);
    }
}