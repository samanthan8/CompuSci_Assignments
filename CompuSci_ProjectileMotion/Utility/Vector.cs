namespace Utility
{
    public class Vector
    {
        private double x;
        private double y;
        private double z;

        public Vector(double x = 0, double y = 0, double z = 0)
        {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsNaN(z))
                throw new ArgumentException("NaN values are not allowed.");
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double X
        {
            get => x;
            set
            {
                if (double.IsNaN(value))
                    throw new ArgumentException("NaN values are not allowed.");
                x = value;
            }
        }

        public double Y
        {
            get => y;
            set
            {
                if (double.IsNaN(value))
                    throw new ArgumentException("NaN values are not allowed.");
                y = value;
            }
        }

        public double Z
        {
            get => z;
            set
            {
                if (double.IsNaN(value))
                    throw new ArgumentException("NaN values are not allowed.");
                z = value;
            }
        }

        public double Magnitude => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));

        public Vector UnitVector => this / Magnitude;

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}, {Z}}}";
        }

        public static Vector operator *(Vector a, double scalar)
        {
            if (double.IsNaN(scalar))
                throw new ArgumentException("NaN values are not allowed.");
            return new Vector(a.X * scalar, a.Y * scalar, a.Z * scalar);
        }

        public static Vector operator *(double scalar, Vector a)
        {
            return a * scalar;
        }

        public static Vector operator -(Vector a)
        {
            return -1 * a;
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + -b;
        }

        public static Vector operator /(Vector a, double scalar)
        {
            if (scalar == 0 || double.IsNaN(scalar))
                throw new ArgumentException("Division by zero or NaN values are not allowed.");
            return a * (1 / scalar);
        }

        public static Vector operator /(double scalar, Vector a)
        {
            return a / scalar;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b);
        }

        public static double Dot(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }

        public static double Angle(Vector a, Vector b)
        {
            if (a.Magnitude == 0 || b.Magnitude == 0)
                throw new ArgumentException("Cannot compute the cross product with a zero vector.");

            return Math.Acos(Dot(a, b) / (a.Magnitude * b.Magnitude));
        }
    }
}