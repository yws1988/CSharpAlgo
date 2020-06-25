using DataStructure.Models.Geometry;
using System;

namespace Geometry.Helper
{
    public class Point3DHeper
    {
        /// <summary>
        /// 3D rotation matrix
        /// </summary>
        /// <param name="pointToRotate"></param>
        /// <param name="centerPoint"></param>
        /// <param name="dir">The ratation direction, 0 is Z axis, 1 is x axis, 2 is y axis </param>
        /// <param name="angleInDegrees"></param>
        /// <returns>3D point after rotation</returns>
        public static Point3DDouble RotatePoint3D(Point3DDouble pointToRotate, Point3DDouble centerPoint, int dir, double angleInDegrees, bool isAngle = false)
        {
            double angleInRadians = isAngle ? angleInDegrees * (Math.PI / 180) : angleInDegrees;
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            double x = pointToRotate.X - centerPoint.X;
            double y = pointToRotate.Y - centerPoint.Y;
            double z = pointToRotate.Z - centerPoint.Z;
            double x1, y1, z1;

            if (dir == 0)
            {
                x1 = cosTheta * x - sinTheta * y + centerPoint.X;
                y1 = sinTheta * x + cosTheta * y + centerPoint.Y;
                z1 = pointToRotate.Z + centerPoint.Z;
            }
            else if (dir == 1)
            {
                y1 = cosTheta * y - sinTheta * z + centerPoint.Y;
                z1 = sinTheta * y + cosTheta * z + centerPoint.Z;
                x1 = pointToRotate.X + centerPoint.X;
            }
            else
            {
                z1 = cosTheta * z - sinTheta * x + centerPoint.Z;
                x1 = sinTheta * z + cosTheta * x + centerPoint.X;
                y1 = pointToRotate.Z + centerPoint.Z;
            }

            return new Point3DDouble(x1, y1, z1);
        }
    }
}
