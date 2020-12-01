// <copyright file="IOpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    /// <summary>
    ///   Defines an interface that provides methods for invocation of the <see cref="GL"/> functions.
    /// </summary>
    public interface IOpenGLInvoker
    {
        /// <inheritdoc cref="GL.AttachShader(int, int)"/>
        void AttachShader(int program, int shader);

        /// <inheritdoc cref="GL.Clear(ClearBufferMask)"/>
        void Clear(ClearBufferMask mask);

        /// <inheritdoc cref="GL.ClearColor(Color)"/>
        void ClearColor(Color color);

        /// <inheritdoc cref="GL.ClearDepth(double)"/>
        void ClearDepth(float depth);

        /// <inheritdoc cref="GL.ClearStencil(int)"/>
        void ClearStencil(int s);

        /// <inheritdoc cref="GL.CompileShader(int)"/>
        void CompileShader(int shader);

        /// <inheritdoc cref="GL.CreateProgram"/>
        int CreateProgram();

        /// <inheritdoc cref="GL.CreateShader(ShaderType)"/>
        int CreateShader(ShaderType type);

        /// <inheritdoc cref="GL.CullFace(CullFaceMode)"/>
        void CullFace(CullFaceMode mode);

        /// <inheritdoc cref="GL.DeleteProgram(int)"/>
        void DeleteProgram(int program);

        /// <inheritdoc cref="GL.DeleteShader(int)"/>
        void DeleteShader(int shader);

        /// <inheritdoc cref="GL.Disable(EnableCap)"/>
        void Disable(EnableCap cap);

        /// <inheritdoc cref="GL.DrawElements(PrimitiveType, int, DrawElementsType, int)"/>
        void DrawElements(PrimitiveType mode, int count, DrawElementsType type, int indices);

        /// <inheritdoc cref="GL.Enable(EnableCap)"/>
        void Enable(EnableCap cap);

        /// <inheritdoc cref="GL.FrontFace(FrontFaceDirection)"/>
        void FrontFace(FrontFaceDirection mode);

        /// <inheritdoc cref="GL.GetProgramInfoLog(int)"/>
        string GetProgramInfoLog(int program);

        /// <inheritdoc cref="GL.GetShaderInfoLog(int)"/>
        string GetShaderInfoLog(int shader);

        /// <inheritdoc cref="GL.LinkProgram(int)"/>
        void LinkProgram(int program);

        /// <inheritdoc cref="GL.LoadBindings(IBindingsContext)"/>
        void LoadBindings(IBindingsContext context);

        /// <inheritdoc cref="GL.PolygonMode(MaterialFace, PolygonMode)"/>
        void PolygonMode(MaterialFace face, PolygonMode mode);

        /// <inheritdoc cref="GL.Scissor(int, int, int, int)"/>
        void Scissor(int x, int y, int width, int height);

        /// <inheritdoc cref="GL.ShaderSource(int, string)"/>
        [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Must Match API")]
        [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Must Much API")]
        void ShaderSource(int shader, string @string);

        /// <inheritdoc cref="GL.UseProgram(int)"/>
        void UseProgram(int program);

        /// <inheritdoc cref="GL.ValidateProgram(int)"/>
        void ValidateProgram(int program);

        /// <inheritdoc cref="GL.Viewport(Rectangle)"/>
        void Viewport(Rectangle rectangle);
    }
}