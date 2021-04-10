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

                Flags = ContextFlags.Debug,
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
            ITexture2D jediTexture = textureLoader.LoadTexture("Resources\\Textures\\jedi.jpg");
            ITexture2D cheeseTexture = textureLoader.LoadTexture("Resources\\Textures\\cheese.jpg");

            var batcher = new Batcher(inputAssembler, 10);
            var binder = new TextureBinder(pipeline);
            var spriteBatch = new SpriteBatch(renderDevice, batcher, binder);

            float rot = 0;
            float x = 0;
            float y = 0;
            float speed = 4;

            while (!window.IsExiting)
            {
                if (keyboard.IsKeyReleased(Key.Escape))
                {
                    break;
                }

                rot += 0.01f;

                if (keyboard.IsKeyDown(Key.W))
                {
                    y -= speed;
                }
                else if (keyboard.IsKeyDown(Key.S))
                {
                    y += speed;
                }
                else if (keyboard.IsKeyDown(Key.A))
                {
                    x += speed;
                }
                else if (keyboard.IsKeyDown(Key.D))
                {
                    x -= speed;
                }

                keyboard.Update();
                mouse.Update();

                renderDevice.Clear(Color.Black);

                pipeline.SetUniform("u_projection", Matrix4x4.CreateOrthographic(nativeWindow.ClientSize.X, nativeWindow.ClientSize.Y, -1, 1));
                pipeline.SetUniform("u_view", Matrix4x4.CreateTranslation(x, y, 0));

                spriteBatch.Begin();

                for (int i = 0; i < 10; i++)
                {
                    spriteBatch.Draw(texture, Color.White, new Vector2(0, 0), new Vector2(0, 0), 0, new Vector2(512, 512));
                }

                spriteBatch.Draw(texture2, Color.White, new Vector2(0, 0), new Vector2(512, 0), 0, new Vector2(512, 512));
                spriteBatch.Draw(jediTexture, Color.White, new Vector2(0, 0), new Vector2(1024, 0), 0, new Vector2(512, 512));
                spriteBatch.Draw(cheeseTexture, Color.White, new Vector2(0, 0), new Vector2(1536, 0), 0, new Vector2(512, 512));

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