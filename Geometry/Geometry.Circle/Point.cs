using System;

namespace Maths.Geometric
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Priority { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point RotatePoint2D(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            (
              cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
              sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
            );
        }

        public override string ToString()
        {
            return this.X+" "+this.Y;
        }
    }
}
