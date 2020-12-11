// <copyright file="OpenGLInvoker.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.OpenGL.Invocation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using OpenTK;
    using OpenTK.Graphics.OpenGL4;

    /// <summary>
    ///   Provides an OpenTK implementation of an <see cref="IOpenGLInvoker"/>.
    /// </summary>
    /// <seealso cref="IOpenGLInvoker"/>
    [ExcludeFromCodeCoverage]
    public class OpenGLInvoker : IOpenGLInvoker
    {
        /// <inheritdoc/>
        public void AttachShader(int program, int shader)
        {
            GL.AttachShader(program, shader);
        }

        /// <inheritdoc/>
        public void BindBuffer(BufferTarget target, int buffer)
        {
            GL.BindBuffer(target, buffer);
        }

        /// <inheritdoc/>
        public void BindVertexArray(int array)
        {
            GL.BindVertexArray(array);
        }

        /// <inheritdoc/>
        public void BindVertexBuffer(int bindingindex, int buffer, IntPtr offset, int stride)
        {
            GL.BindVertexBuffer(bindingindex, buffer, offset, stride);
        }

        /// <inheritdoc/>
        public void BufferData<T2>(BufferTarget target, int size, T2[] data, BufferUsageHint usage)
            where T2 : struct
        {
            GL.BufferData(target, size, data, usage);
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
        public int CreateProgram()
        {
            return GL.CreateProgram();
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

        /// <inheritdoc/>
        public void DeleteBuffer(int buffers)
        {
            GL.DeleteBuffer(buffers);
        }

        /// <inheritdoc/>
        public void DeleteProgram(int program)
        {
            GL.DeleteProgram(program);
        }

        /// <inheritdoc/>
        public void DeleteShader(int shader)
        {
            GL.DeleteShader(shader);
        }

        /// <inheritdoc/>
        public void DeleteVertexArray(int arrays)
        {
            GL.DeleteVertexArray(arrays);
        }

        /// <inheritdoc/>
        public void DepthFunc(DepthFunction func)
        {
            GL.DepthFunc(func);
        }

        /// <inheritdoc/>
        public void DepthMask(bool flag)
        {
            GL.DepthMask(flag);
        }

        /// <inheritdoc/>
        public void DepthRange(float n, float f)
        {
            GL.DepthRange(n, f);
        }

        /// <inheritdoc/>
        public void Disable(EnableCap cap)
        {
            GL.Disable(cap);
        }

        /// <inheritdoc/>
        public void DisableVertexAttribArray(int index)
        {
            GL.DisableVertexAttribArray(index);
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
        public void EnableVertexAttribArray(int index)
        {
            GL.EnableVertexAttribArray(index);
        }

        /// <inheritdoc/>
        public void FrontFace(FrontFaceDirection mode)
        {
            GL.FrontFace(mode);
        }

        /// <inheritdoc/>
        public int GenBuffer()
        {
            return GL.GenBuffer();
        }

        /// <inheritdoc/>
        public int GenVertexArray()
        {
            return GL.GenVertexArray();
        }

        /// <inheritdoc/>
        public string GetProgramInfoLog(int program)
        {
            return GL.GetProgramInfoLog(program);
        }

        /// <inheritdoc/>
        public string GetShaderInfoLog(int shader)
        {
            return GL.GetShaderInfoLog(shader);
        }

        /// <inheritdoc/>
        public int GetUniformLocation(int program, string name)
        {
            return GL.GetUniformLocation(program, name);
        }

        /// <inheritdoc/>
        public void LinkProgram(int program)
        {
            GL.LinkProgram(program);
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
        public void StencilFunc(StencilFunction func, int @ref, int mask)
        {
            GL.StencilFunc(func, @ref, mask);
        }

        /// <inheritdoc/>
        public void StencilMask(int mask)
        {
            GL.StencilMask(mask);
        }

        /// <inheritdoc/>
        public void StencilOp(StencilOp fail, StencilOp zfail, StencilOp zpass)
        {
            GL.StencilOp(fail, zfail, zpass);
        }

        /// <inheritdoc/>
        public void Uniform1(int location, int x)
        {
            GL.Uniform1(location, x);
        }

        /// <inheritdoc/>
        public void Uniform1(int location, float v0)
        {
            GL.Uniform1(location, v0);
        }

        /// <inheritdoc/>
        public void Uniform1(int location, double x)
        {
            GL.Uniform1(location, x);
        }

        /// <inheritdoc/>
        public void Uniform2(int location, float v0, float v1)
        {
            GL.Uniform2(location, v0, v1);
        }

        /// <inheritdoc/>
        public void Uniform3(int location, float v0, float v1, float v2)
        {
            GL.Uniform3(location, v0, v1, v2);
        }

        /// <inheritdoc/>
        public void Uniform4(int location, float v0, float v1, float v2, float v3)
        {
            GL.Uniform4(location, v0, v1, v2, v3);
        }

        /// <inheritdoc/>
        public void UniformMatrix4(int location, int count, bool transpose, float[] value)
        {
            GL.UniformMatrix4(location, count, transpose, value);
        }

        /// <inheritdoc/>
        public void UseProgram(int program)
        {
            GL.UseProgram(program);
        }

        /// <inheritdoc/>
        public void ValidateProgram(int program)
        {
            GL.ValidateProgram(program);
        }

        /// <inheritdoc/>
        public void VertexAttribBinding(int attribindex, int bindingindex)
        {
            GL.VertexAttribBinding(attribindex, bindingindex);
        }

        /// <inheritdoc/>
        public void VertexAttribFormat(int attribindex, int size, VertexAttribType type, bool normalized, int relativeoffset)
        {
            GL.VertexAttribFormat(attribindex, size, type, normalized, relativeoffset);
        }

        /// <inheritdoc/>
        public void Viewport(Rectangle rectangle)
        {
            GL.Viewport(rectangle);
        }
    }
}