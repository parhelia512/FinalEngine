namespace FinalEngine.Maths
{
    using System;

    public struct Matrix4 : IEquatable<Matrix4>
    {
        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
        }

        public Vector4 Row0 { get; set; }

        public Vector4 Row1 { get; set; }

        public Vector4 Row2 { get; set; }

        public Vector4 Row3 { get; set; }

        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix4))
            {
                return false;
            }

            return Equals((Matrix4)obj);
        }

        public bool Equals(Matrix4 other)
        {
            return Row0 == other.Row0 &&
                   Row1 == other.Row1 &&
                   Row2 == other.Row2 &&
                   Row3 == other.Row3;
        }

        public override int GetHashCode()
        {
            return new { Row0, Row1, Row2, Row3 }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ Row0 }\n{ Row1 }\n{ Row2 }\n{ Row3 })";
        }
    }
}