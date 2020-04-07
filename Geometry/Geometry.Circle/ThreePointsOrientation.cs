namespace Geometric
{
    using DataStructure.Models.Geometry;

    public class ThreePointsOrientation
    {
        public static int Orientation(Point<double> p1, Point<double> p2, Point<double> p3)
        {
            double val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);

            if (val == 0) return 0;  // colinear

            // clock or counterclock wise
            return (val > 0) ? 1 : 2;
        }
    }
}
