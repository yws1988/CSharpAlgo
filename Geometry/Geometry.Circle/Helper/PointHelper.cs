using DataStructure.Models.Geometry;
using System;

namespace Geometry.Helper
{
    public class PointHelper
    {
        public static Point<double> RotatePoint(Point<double> pointToRotate, Point<double> centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point<double>
            (
              cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X,
              sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y
            );
        }
    }
}
