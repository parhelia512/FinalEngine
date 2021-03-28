// <copyright file="Camera.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    using System;
    using System.Numerics;

    public class Camera3D : ICamera
    {
        private readonly float aspectRatio;

        private readonly float fov;

        private readonly float sensitivity;

        private readonly float speed;

        private Vector3 orientation;

        private Vector3 position;

        public Camera3D(Vector3 position, Vector3 orientation, float fov, float aspectRatio, float speed = 0.002f, float sensitivity = 0.0010f)
        {
            this.position = position;
            this.orientation = orientation;

            this.fov = fov;
            this.aspectRatio = aspectRatio;

            this.speed = speed;
            this.sensitivity = sensitivity;
        }

        public Matrix4x4 Projection
        {
            get { return Matrix4x4.CreatePerspectiveFieldOfView(this.fov, this.aspectRatio, 0.1f, 1000.0f); }
        }

        public Matrix4x4 View
        {
            get
            {
                var lookAt = new Vector3()
                {
                    X = (float)(Math.Sin(this.orientation.X) * Math.Cos(this.orientation.Y)),
                    Y = (float)Math.Sin(this.orientation.Y),
                    Z = (float)(Math.Cos(this.orientation.X) * Math.Cos(this.orientation.Y)),
                };

                return Matrix4x4.CreateLookAt(this.position, this.position + lookAt, Vector3.UnitY);
            }
        }

        public void Move(float x, float y, float z)
        {
            var offset = default(Vector3);

            var forward = new Vector3((float)Math.Sin(this.orientation.X), 0, (float)Math.Cos(this.orientation.X));
            var right = new Vector3(-forward.Z, 0, forward.X);

            offset += x * right;
            offset += y * forward;
            offset.Y += z;

            offset = Vector3.Normalize(offset);
            offset = Vector3.Multiply(offset, this.speed);

            this.position += offset;
        }

        public void Rotate(float x, float y)
        {
            x *= this.sensitivity;
            y *= this.sensitivity;

            this.orientation.X = (this.orientation.X + x) % ((float)Math.PI * 2.0f);
            this.orientation.Y = Math.Max(Math.Min(this.orientation.Y + y, ((float)Math.PI / 2.0f) - 0.1f), ((float)-Math.PI / 2.0f) + 0.1f);
        }
    }
}