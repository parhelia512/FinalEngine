﻿// <copyright file="Batcher.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Numerics;
    using FinalEngine.Rendering.Buffers;

    public class Batcher : IBatcher
    {
        private readonly IInputAssembler inputAssembler;

        private readonly IList<Vertex> vertices;

        public Batcher(IInputAssembler inputAssembler, int maxCapacity)
        {
            this.inputAssembler = inputAssembler ?? throw new ArgumentNullException(nameof(inputAssembler), $"The specified {nameof(inputAssembler)} parameter cannot be null.");
            this.MaxCapacity = maxCapacity;
            this.vertices = new List<Vertex>();
        }

        public int MaxCapacity { get; }

        public bool ShouldReset
        {
            get { return this.vertices.Count >= this.MaxCapacity * 4; }
        }

        public void Batch(float textureID, Color color, Vector2 origin, Vector2 position, float rotation, Vector2 scale)
        {
            if (this.ShouldReset)
            {
                this.Reset();
            }

            float x = position.X;
            float y = position.Y;

            float dx = -origin.X;
            float dy = -origin.Y;

            float w = scale.X;
            float h = scale.Y;

            float cos = (float)Math.Cos(rotation);
            float sin = (float)Math.Sin(rotation);

            var vecColor = new Vector4(
                color.R / 255.0f,
                color.G / 255.0f,
                color.B / 255.0f,
                color.A / 255.0f);

            // Top right
            this.vertices.Add(new Vertex()
            {
                Position = new Vector2(x + ((dx + w) * cos) - (dy * sin), y + ((dx + w) * sin) + (dy * cos)),
                Color = vecColor,
                TextureCoordinate = new Vector2(1, 1),
                TextureIdentifier = textureID,
            });

            // Top left
            this.vertices.Add(new Vertex()
            {
                Position = new Vector2(x + (dx * cos) - (dy * sin), y + (dx * sin) + (dy * cos)),
                Color = vecColor,
                TextureCoordinate = new Vector2(0, 1),
                TextureIdentifier = textureID,
            });

            // Bottom left
            this.vertices.Add(new Vertex()
            {
                Position = new Vector2(x + (dx * cos) - ((dy + h) * sin), y + (dx * sin) + ((dy + h) * cos)),
                Color = vecColor,
                TextureCoordinate = new Vector2(0, 0),
                TextureIdentifier = textureID,
            });

            // Bottom right
            this.vertices.Add(new Vertex()
            {
                Position = new Vector2(x + ((dx + w) * cos) - ((dy + h) * sin), y + ((dx + w) * sin) + ((dy + h) * cos)),
                Color = vecColor,
                TextureCoordinate = new Vector2(1, 0),
                TextureIdentifier = textureID,
            });
        }

        public void ProcessBatch(IVertexBuffer vertexBuffer)
        {
            this.inputAssembler.UpdateVertexBuffer(vertexBuffer, (IReadOnlyCollection<Vertex>)this.vertices, Vertex.SizeInBytes);
        }

        public void Reset()
        {
            this.vertices.Clear();
        }
    }
}