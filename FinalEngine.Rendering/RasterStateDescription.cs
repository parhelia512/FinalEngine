// <copyright file="RasterStateDescription.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering
{
    public struct RasterStateDescription
    {
        private FaceCullMode? cullMode;

        private RasterMode? fillMode;

        private WindingDirection? windingDirection;

        public bool CullEnabled { get; set; }

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

        public bool ScissorEnabled { get; set; }

        public WindingDirection WindingDirection
        {
            get { return this.windingDirection ?? WindingDirection.CounterClockwise; }
            set { this.windingDirection = value; }
        }
    }
}