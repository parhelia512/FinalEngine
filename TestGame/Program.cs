// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Numerics;
    using System.Runtime.InteropServices;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.IO;
    using FinalEngine.IO.Invocation;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Buffers;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using OpenTK.Graphics.OpenGL4;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;
    using OpenTK.Windowing.GraphicsLibraryFramework;

    internal static class Program
    {
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

                Size = new OpenTK.Mathematics.Vector2i(1024, 768),

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

            renderDevice.SetRasterState(default);
            renderDevice.SetDepthState(default);
            renderDevice.SetStencilState(default);
            renderDevice.SetBlendState(default);

            IEnumerable<IShader> shaders = new List<IShader>()
            {
                renderDevice.CreateShader(PipelineTarget.Vertex, File.ReadAllText("Resources\\Shaders\\shader.vert")),
                renderDevice.CreateShader(PipelineTarget.Fragment, File.ReadAllText("Resources\\Shaders\\shader.frag")),
            };

            IShaderProgram program = renderDevice.CreateShaderProgram(shaders);
            renderDevice.SetShaderProgram(program);

            Vertex[] vertices =
            {
                new Vertex(new Vector3(0.5f, 0.5f, 0.0f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f, 0.0f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f, 0.0f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f, 0.0f), Vector4.One, new Vector2(0.0f, 1.0f)),
            };

            int[] indices =
            {
                0, 1, 3,
                1, 2, 3,
            };

            var inputElements = new List<InputElement>()
            {
                new InputElement(0, 3, InputElementType.Float, Marshal.OffsetOf<Vertex>("position").ToInt32()),
                new InputElement(1, 4, InputElementType.Float, Marshal.OffsetOf<Vertex>("color").ToInt32()),
                new InputElement(2, 2, InputElementType.Float, Marshal.OffsetOf<Vertex>("textureCoordinate").ToInt32()),
            };

            IInputLayout inputLayout = renderDevice.CreateInputLayout(inputElements);
            renderDevice.SetInputLayout(inputLayout);

            IVertexBuffer vertexBuffer = renderDevice.CreateVertexBuffer(vertices, vertices.Length * Vertex.SizeInBytes, Vertex.SizeInBytes);
            IIndexBuffer indexBuffer = renderDevice.CreateIndexBuffer(indices, indices.Length * sizeof(int));

            renderDevice.SetVertexBuffer(vertexBuffer);
            renderDevice.SetIndexBuffer(indexBuffer);

            Console.WriteLine(GL.GetError());

            while (!window.IsExiting)
            {
                keyboard.Update();
                mouse.Update();

                renderDevice.Clear(Color.Black);
                renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, indices.Length);

                renderContext.SwapBuffers();
                window.ProcessEvents();
            }

            program.Dispose();

            foreach (IShader shader in shaders)
            {
                shader.Dispose();
            }

            renderContext.Dispose();
            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}