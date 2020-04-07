namespace DataStructure.Models.Geometry
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

        public override string ToString()
        {
            return $"{this.A}x+{this.B}y+{this.C}=0";
        }
    }
}
