namespace Maths.Geometric
{
    public class Line
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Line(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public static Line GetLineFromTwoPoint(Point p1, Point p2)
        {
            double a = p2.Y - p1.Y;
            double b = p1.X - p2.X;
            double c = -a * (p1.X) - b * (p1.Y);
            return new Line(a, b, c);
        }

        public override string ToString()
        {
            return $"{this.A}x+{this.B}y+{this.C}=0";
        }
    }
}
