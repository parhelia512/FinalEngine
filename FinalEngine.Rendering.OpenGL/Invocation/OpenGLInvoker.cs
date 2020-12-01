// <copyright file="OpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IOpenGLInvoker"/>.
    /// </summary>
    /// <seealso cref="FinalEngine.Rendering.OpenGL.Invocation.IOpenGLInvoker"/>
    [ExcludeFromCodeCoverage]
    public class OpenGLInvoker : IOpenGLInvoker
    {
        /// <inheritdoc/>
        public void AttachShader(int program, int shader)
        {
            GL.AttachShader(program, shader);
        }

        /// <inheritdoc/>
        public void Clear(ClearBufferMask mask)
        {
            GL.Clear(mask);
        }

        /// <inheritdoc/>
        public void ClearColor(Color color)
        {
            GL.ClearColor(color);
        }

        /// <inheritdoc/>
        public void ClearDepth(float depth)
        {
            GL.ClearDepth(depth);
        }

        /// <inheritdoc/>
        public void ClearStencil(int s)
        {
            GL.ClearStencil(s);
        }

        /// <inheritdoc/>
        public void CompileShader(int shader)
        {
            GL.CompileShader(shader);
        }

        /// <inheritdoc/>
        public int CreateShader(ShaderType type)
        {
            return GL.CreateShader(type);
        }

        /// <inheritdoc/>
        public void CullFace(CullFaceMode mode)
        {
            GL.CullFace(mode);
        }

        public void DeleteShader(int shader)
        {
            GL.DeleteShader(shader);
        }

        /// <inheritdoc/>
        public void Disable(EnableCap cap)
        {
            GL.Disable(cap);
        }

        /// <inheritdoc/>
        public void DrawElements(PrimitiveType mode, int count, DrawElementsType type, int indices)
        {
            GL.DrawElements(mode, count, type, indices);
        }

        /// <inheritdoc/>
        public void Enable(EnableCap cap)
        {
            GL.Enable(cap);
        }

        /// <inheritdoc/>
        public void FrontFace(FrontFaceDirection mode)
        {
            GL.FrontFace(mode);
        }

        public string GetShaderInfoLog(int shader)
        {
            return GL.GetShaderInfoLog(shader);
        }

        /// <inheritdoc/>
        public void LoadBindings(IBindingsContext context)
        {
            GL.LoadBindings(context);
        }

        /// <inheritdoc/>
        public void PolygonMode(MaterialFace face, PolygonMode mode)
        {
            GL.PolygonMode(face, mode);
        }

        /// <inheritdoc/>
        public void Scissor(int x, int y, int width, int height)
        {
            GL.Scissor(x, y, width, height);
        }

        /// <inheritdoc/>
        public void ShaderSource(int shader, string @string)
        {
            GL.ShaderSource(shader, @string);
        }

        /// <inheritdoc/>
        public void Viewport(Rectangle rectangle)
        {
            GL.Viewport(rectangle);
        }
    }
}