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
    using FinalEngine.Input.Keyboard;
    using FinalEngine.Input.Mouse;
    using FinalEngine.IO;
    using FinalEngine.IO.Invocation;
    using FinalEngine.Platform.Desktop.OpenTK;
    using FinalEngine.Platform.Desktop.OpenTK.Invocation;
    using FinalEngine.Rendering;
    using FinalEngine.Rendering.Invocation;
    using FinalEngine.Rendering.OpenGL;
    using FinalEngine.Rendering.OpenGL.Invocation;
    using FinalEngine.Rendering.Pipeline;
    using FinalEngine.Rendering.Textures;
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

                Size = new OpenTK.Mathematics.Vector2i(1280, 720),

                StartVisible = true,
            };

            var nativeWindow = new NativeWindowInvoker(settings)
            {
                CursorGrabbed = true,
            };

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

            var image = new ImageInvoker();
            var textureLoader = new Texture2DLoader(fileSystem, factory, image);

            IShaderProgram? program = factory.CreateShaderProgram(
                new List<IShader>()
                {
                    factory.CreateShader(PipelineTarget.Vertex, File.ReadAllText("Resources\\Shaders\\shader.vert")),
                    factory.CreateShader(PipelineTarget.Fragment, File.ReadAllText("Resources\\Shaders\\shader.frag")),
                });

            pipeline.SetShaderProgram(program);

            ITexture2D texture = textureLoader.LoadTexture("Resources\\Textures\\default.png");
            ITexture2D texture2 = textureLoader.LoadTexture("Resources\\Textures\\wood.png");

            var batcher = new Batcher(inputAssembler, 1000);
            var binder = new TextureBinder(pipeline);
            var spriteBatch = new SpriteBatch(renderDevice, batcher, binder);

            float rot = 0;

            var camera = new Camera2D(Vector2.Zero, nativeWindow.ClientSize.X, nativeWindow.ClientSize.Y, 4);

            while (!window.IsExiting)
            {
                if (keyboard.IsKeyReleased(Key.Escape))
                {
                    break;
                }

                rot += 0.01f;

                if (keyboard.IsKeyDown(Key.W))
                {
                    camera.Move(-Vector2.UnitY);
                }
                else if (keyboard.IsKeyDown(Key.S))
                {
                    camera.Move(Vector2.UnitY);
                }
                else if (keyboard.IsKeyDown(Key.A))
                {
                    camera.Move(Vector2.UnitX);
                }
                else if (keyboard.IsKeyDown(Key.D))
                {
                    camera.Move(-Vector2.UnitX);
                }

                keyboard.Update();
                mouse.Update();

                renderDevice.Clear(Color.Black);

                pipeline.SetUniform("u_projection", camera.Projection);
                pipeline.SetUniform("u_view", camera.View);

                spriteBatch.Begin();

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        ITexture2D tex = (j + i) % 2 == 0 ? texture : texture2;

                        spriteBatch.Draw(tex, Color.CornflowerBlue, new Vector2(32, 32), new Vector2(i * 64, j * 64), rot, new Vector2(64, 64));
                    }
                }

                spriteBatch.End();
                spriteBatch.Flush();

                renderContext.SwapBuffers();
                window.ProcessEvents();
            }

            spriteBatch.Dispose();
            renderContext.Dispose();
            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}