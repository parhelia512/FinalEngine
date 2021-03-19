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
    using FinalEngine.Rendering.Buffers;
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

            ITexture2D texture = textureLoader.LoadTexture("Resources\\Textures\\default.png");

            IShaderProgram? program = factory.CreateShaderProgram(
                new List<IShader>()
                {
                    factory.CreateShader(PipelineTarget.Vertex, File.ReadAllText("Resources\\Shaders\\shader.vert")),
                    factory.CreateShader(PipelineTarget.Fragment, File.ReadAllText("Resources\\Shaders\\shader.frag")),
                });

            pipeline.SetShaderProgram(program);
            pipeline.SetTexture(texture);

            IInputLayout? inputLayout = factory.CreateInputLayout(
                new List<InputElement>()
                {
                    new InputElement(0, 3, InputElementType.Float, 0),
                    new InputElement(1, 4, InputElementType.Float, 3 * sizeof(float)),
                    new InputElement(2, 2, InputElementType.Float, 7 * sizeof(float)),
                });

            inputAssembler.SetInputLayout(inputLayout);

            IVertexBuffer vertexBuffer = factory.CreateVertexBuffer(BufferUsageType.Dynamic, Array.Empty<float>(), 1000 * sizeof(float), 9 * sizeof(float));
            IIndexBuffer indexBuffer = factory.CreateIndexBuffer(BufferUsageType.Dynamic, Array.Empty<int>(), 3 * sizeof(int));

            inputAssembler.SetVertexBuffer(vertexBuffer);
            inputAssembler.SetIndexBuffer(indexBuffer);

            var camera = new Camera(
                new Vector3(0, 0, -3.0f),
                Vector3.Zero,
                OpenTK.Mathematics.MathHelper.DegreesToRadians(70.0f),
                nativeWindow.ClientSize.X / nativeWindow.ClientSize.Y);

            while (!window.IsExiting)
            {
                if (keyboard.IsKeyReleased(Key.Escape))
                {
                    break;
                }

                if (keyboard.IsKeyDown(Key.W))
                {
                    camera.Move(0, 1, 0);
                }
                else if (keyboard.IsKeyDown(Key.S))
                {
                    camera.Move(0, -1, 0);
                }
                else if (keyboard.IsKeyDown(Key.A))
                {
                    camera.Move(-1, 0, 0);
                }
                else if (keyboard.IsKeyDown(Key.D))
                {
                    camera.Move(1, 0, 0);
                }
                else if (keyboard.IsKeyDown(Key.Q))
                {
                    camera.Move(0, 0, 1);
                }
                else if (keyboard.IsKeyDown(Key.E))
                {
                    camera.Move(0, 0, -1);
                }

                keyboard.Update();
                mouse.Update();

                camera.Rotate(-mouse.Delta.X, -mouse.Delta.Y);

                pipeline.SetUniform("u_projection", camera.Projection);
                pipeline.SetUniform("u_view", camera.View);
                pipeline.SetUniform("u_model", Matrix4x4.CreateTranslation(Vector3.Zero));

                float[] vertices =
                {
                    -0.5f, -0.5f, 0.0f, 1, 1, 1, 1, 0, 0,
                    0.5f, -0.5f, 0.0f, 1, 1, 1, 1, 1, 0,
                    0.0f, 0.5f, 0.0f, 1, 1, 1, 1, 0.5f, 1,
                };

                int[] indices =
                {
                    0, 1, 2,
                };

                inputAssembler.UpdateVertexBuffer(vertexBuffer, vertices, 9 * sizeof(float));
                inputAssembler.UpdateIndexBuffer(indexBuffer, indices);

                renderDevice.Clear(Color.CornflowerBlue);
                renderDevice.DrawIndices(PrimitiveTopology.Triangle, 0, indexBuffer.Length);

                renderContext.SwapBuffers();
                window.ProcessEvents();
            }

            renderContext.Dispose();
            window.Dispose();
            nativeWindow.Dispose();
        }
    }
}