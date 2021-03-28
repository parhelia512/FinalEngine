// <copyright file="Camera2D.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System.Numerics;

    public class Camera2D : ICamera
    {
        private readonly int height;

        private readonly float speed;

        private readonly int width;

        private Vector2 position;

        public Camera2D(Vector2 position, int width, int height, float speed)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.speed = speed;
        }

        public Matrix4x4 Projection
        {
            get { return Matrix4x4.CreateOrthographic(this.width, this.height, -1, 1); }
        }

        public Matrix4x4 View
        {
            get { return Matrix4x4.CreateTranslation(new Vector3(this.position, 0)); }
        }

        public void Move(Vector2 direction)
        {
            this.position += direction * this.speed;
        }
    }
}