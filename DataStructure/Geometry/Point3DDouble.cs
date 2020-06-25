namespace DataStructure.Geometry
{
    using System;

    public class Point3DDouble
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public bool UsePrecision { get; set; }
        public int Precision { get; set; }

        public Point3DDouble(double x, double y, double z, int precision = 6, bool usePrecision = false)
        {
            X = usePrecision ? Math.Round(x, precision, MidpointRounding.AwayFromZero) : x;
            Y = usePrecision ? Math.Round(y, precision, MidpointRounding.AwayFromZero) : y;
            Z = usePrecision ? Math.Round(z, precision, MidpointRounding.AwayFromZero) : z;
        }

        public override string ToString()
        {
            return this.X + " " + this.Y + " " + this.Z;
        }
    }
}
