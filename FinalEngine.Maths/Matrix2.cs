namespace FinalEngine.Maths
{
    using System;

    public struct Matrix2 : IEquatable<Matrix2>
    {
        public Matrix2(Vector2 row0, Vector2 row1)
        {
            Row0 = row0;
            Row1 = row1;
        }

        public Vector2 Row0 { get; set; }

        public Vector2 Row1 { get; set; }

        public static bool operator !=(Matrix2 left, Matrix2 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Matrix2 left, Matrix2 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix2))
            {
                return false;
            }

            return Equals((Matrix2)obj);
        }

        public bool Equals(Matrix2 other)
        {
            return Row0 == other.Row0 &&
                   Row1 == other.Row1;
        }

        public override int GetHashCode()
        {
            return new { Row0, Row1 }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ Row0 }\n{ Row1 })";
        }
    }
}