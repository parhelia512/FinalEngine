// <copyright file="Program.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace TestGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.IO;
    using FinalEngine.IO.Invocation;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Loading;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Rendering.Textures;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;
    using OpenTK.Windowing.GraphicsLibraryFramework;
    using Color = System.Drawing.Color;
    using MathHelper = OpenTK.Mathematics.MathHelper;

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

            IInputAssembler inputAssembler = renderDevice.InputAssembler;
            IRasterizer rasterizer = renderDevice.Rasterizer;
            IOutputMerger outputMerger = renderDevice.OutputMerger;
            IPipeline pipeline = renderDevice.Pipeline;
            IGPUResourceFactory factory = renderDevice.Factory;

            var textureLoader = new ImageSharpTexture2DLoader(factory, fileSystem);

            outputMerger.SetDepthState(new DepthStateDescription()
            {
                ReadEnabled = true,
            });

            IEnumerable<IShader> shaders = new List<IShader>()
            {
                factory.CreateShader(PipelineTarget.Vertex, File.ReadAllText("Resources\\Shaders\\shader.vert")),
                factory.CreateShader(PipelineTarget.Fragment, File.ReadAllText("Resources\\Shaders\\shader.frag")),
            };

            IShaderProgram program = factory.CreateShaderProgram(shaders);
            pipeline.SetShaderProgram(program);

            Vertex[] vertices =
            {
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),

                new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),

                new Vertex(new Vector3(-0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f,  0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),

                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),

                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),

                new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(1.0f, 1.0f)),
                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(1.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f,  0.5f), Vector4.One, new Vector2(0.0f, 0.0f)),
                new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), Vector4.One, new Vector2(0.0f, 1.0f)),
            };

            int[] indices = Enumerable.Range(0, 36).ToArray();

            Vector3[] positions =
            {
                new Vector3(0.0f,  0.0f,  0.0f),
                new Vector3(2.0f,  5.0f, -15.0f),
                new Vector3(-1.5f, -2.2f, -2.5f),
                new Vector3(-3.8f, -2.0f, -12.3f),
                new Vector3(2.4f, -0.4f, -3.5f),
                new Vector3(-1.7f,  3.0f, -7.5f),
                new Vector3(1.3f, -2.0f, -2.5f),
                new Vector3(1.5f,  2.0f, -2.5f),
                new Vector3(1.5f,  0.2f, -1.5f),
                new Vector3(-1.3f,  1.0f, -1.5f),
            };

            var mesh = new Mesh(factory, vertices, indices);
            mesh.SetBuffers(inputAssembler);

            ITexture2D texture = textureLoader.LoadTexture2D("Resources\\Textures\\default.png");
            pipeline.SetTexture(texture, 0);

            float temp = 0.0f;
            var random = new Random();

            while (!window.IsExiting)
            {
                keyboard.Update();
                mouse.Update();

                temp += 0.02f;

                var projection = Matrix4x4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 1024 / 768, 0.1f, 100.0f);
                var view = Matrix4x4.CreateTranslation(new Vector3(0, 0, -3.0f));

                pipeline.SetUniform("u_projection", projection);
                pipeline.SetUniform("u_view", view);

                renderDevice.Clear(Color.Black);

                for (int i = 0; i < positions.Length; i++)
                {
                    float angle = 20.0f * i;
                    bool xyz = random.NextDouble() <= 1.0f;

                    Matrix4x4 model = Matrix4x4.CreateRotationZ(MathHelper.DegreesToRadians(angle * 1.0f)) *
                                      Matrix4x4.CreateRotationY(MathHelper.DegreesToRadians(xyz ? temp : angle * 0.2f)) *
                                      Matrix4x4.CreateRotationX(MathHelper.DegreesToRadians(angle * 0.5f)) *
                                      Matrix4x4.CreateTranslation(positions[i]);

                    pipeline.SetUniform("u_model", model);

                    mesh.Draw(renderDevice);
                }

                renderContext.SwapBuffers();
                window.ProcessEvents();
            }

            mesh.Dispose();
            texture.Dispose();

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