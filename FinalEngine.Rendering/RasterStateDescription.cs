// <copyright file="RasterStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    public struct RasterStateDescription
    {
        private bool? cullEnabled;

        private FaceCullMode? cullMode;

        private RasterMode? fillMode;

        private bool? scissorEnabled;

        private WindingDirection? windingDirection;

        public bool CullEnabled
        {
            get { return this.cullEnabled ?? false; }
            set { this.cullEnabled = value; }
        }

        public FaceCullMode CullMode
        {
            get { return this.cullMode ?? FaceCullMode.Back; }
            set { this.cullMode = value; }
        }

        public RasterMode FillMode
        {
            get { return this.fillMode ?? RasterMode.Solid; }
            set { this.fillMode = value; }
        }

        public bool ScissorEnabled
        {
            get { return this.scissorEnabled ?? false; }
            set { this.scissorEnabled = value; }
        }

        public WindingDirection WindingDirection
        {
            get { return this.windingDirection ?? WindingDirection.CounterClockwise; }
            set { this.windingDirection = value; }
        }
    }
}