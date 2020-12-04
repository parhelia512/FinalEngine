// <copyright file="InputElement.cs" company="Software Antics">
//     Copyright (c) Software Antics. All rights reserved.
// </copyright>

namespace FinalEngine.Rendering.Buffers
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Required for API")]
    public enum InputElementType
    {
        Int,

        Byte,

        Short,

        Float,

        Double,
    }

    public struct InputElement
    {
        public InputElement(int index, int size, InputElementType type, int relativeOffset)
        {
            this.Index = index;
            this.Size = size;
            this.Type = type;
            this.RelativeOffset = relativeOffset;
        }

        public int Index { get; set; }

        public int RelativeOffset { get; set; }

        public int Size { get; set; }

        public InputElementType Type { get; set; }
    }
}