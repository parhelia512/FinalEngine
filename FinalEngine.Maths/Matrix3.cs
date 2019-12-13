namespace FinalEngine.Maths
{
    using System;

    public struct Matrix3 : IEquatable<Matrix3>
    {
        public static readonly Matrix3 Identity = new Matrix3(new Vector3(1, 0, 0),
                                                              new Vector3(0, 1, 0),
                                                              new Vector3(0, 0, 1));

        public static readonly Matrix3 One = new Matrix3(Vector3.One, Vector3.One, Vector3.One);

        public static readonly Matrix3 Zero = new Matrix3(Vector3.Zero, Vector3.Zero, Vector3.Zero);

        public Matrix3(Vector3 row0, Vector3 row1, Vector3 row2)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
        }

        public Vector3 Row0 { get; set; }

        public Vector3 Row1 { get; set; }

        public Vector3 Row2 { get; set; }

        public static bool operator !=(Matrix3 left, Matrix3 right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Matrix3 left, Matrix3 right)
        {
            return left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3))
            {
                return false;
            }

            return Equals((Matrix3)obj);
        }

        public bool Equals(Matrix3 other)
        {
            return Row0 == other.Row0 &&
                   Row1 == other.Row1 &&
                   Row2 == other.Row2;
        }

        public override int GetHashCode()
        {
            return new { Row0, Row1, Row2 }.GetHashCode();
        }

        public override string ToString()
        {
            return $"({ Row0 }\n{ Row1 }\n{ Row2 })";
        }
    }
}