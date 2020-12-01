// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using System.Drawing;
    using System.IO;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.IO;
    using FinalEngine.IO.Invocation;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using OpenTK.Graphics.OpenGL4;
    using OpenTK.Mathematics;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;
    using OpenTK.Windowing.GraphicsLibraryFramework;

    /// <summary>
    ///   The main program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///   Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var settings = new NativeWindowSettings()
            {
                API = ContextAPI.OpenGL,
                APIVersion = new Version(4, 6),

                Flags = ContextFlags.ForwardCompatible,
                Profile = ContextProfile.Core,

                AutoLoadBindings = false,

                WindowBorder = WindowBorder.Fixed,
                WindowState = WindowState.Normal,

                Size = new Vector2i(1024, 768),

                StartVisible = true,
            };

            var nativeWindow = new NativeWindowInvoker(settings);
            var window = new OpenTKWindow(nativeWindow);

            var keyboardDevice = new OpenTKKeyboardDevice(nativeWindow);
            var mouseDevice = new OpenTKMouseDevice(nativeWindow);

            var keyboard = new Keyboard(keyboardDevice);
            var mouse = new Mouse(mouseDevice);

            var file = new FileInvoker();
            var directory = new DirectoryInvoker();

            var fileSystem = new FileSystem(file, directory);

            var opengl = new OpenGLInvoker();
            var bindings = new GLFWBindingsContext();

            var renderContext = new OpenGLRenderContext(opengl, bindings, nativeWindow.Context);
            var renderDevice = new OpenGLRenderDevice(opengl);

            IRasterizer rasterizer = renderDevice.Rasterizer;

            rasterizer.SetRasterState(default);

            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, File.ReadAllText("Resources\\Shaders\\shader.vert"));
            GL.CompileShader(vertexShader);

            int pixelShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(pixelShader, File.ReadAllText("Resources\\shaders\\shader.frag"));
            GL.CompileShader(pixelShader);

            int program = GL.CreateProgram();

            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, pixelShader);

            GL.LinkProgram(program);
            GL.ValidateProgram(program);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(pixelShader);

            float[] vertices =
            {
                -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f,
                0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f, 1.0f,
                0.0f,  0.5f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f,
            };

            int[] indices =
            {
                0, 1, 2,
            };

            int vao = GL.GenVertexArray();
            int vbo = GL.GenBuffer();
            int ebo = GL.GenBuffer();

            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 7 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 7 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            while (!window.IsExiting)
            {
                keyboard.Update();
                mouse.Update();

                GL.ClearColor(Color.CornflowerBlue);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.UseProgram(program);
                GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

                renderContext.SwapBuffers();
                window.ProcessEvents();
            }

            GL.DeleteBuffer(ebo);
            GL.DeleteBuffer(vbo);
            GL.DeleteBuffer(vao);

            GL.DeleteProgram(program);

            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}