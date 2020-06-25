namespace Geometry
{
    using DataStructure.Geometry;
    using System;
    using System.Linq;

    class FindTheClosestPathOfPoints
    {
        public static Point<double>[] GetClosestPath(Point<double>[] points)
        {
            var startPoint = points.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            var zeroPoints = points.Where(p => p.X == startPoint.X).OrderBy(p => p.Y).Skip(1);
            var restPoints = points.Where(p => p.X != startPoint.X).ToList();

            foreach (var item in restPoints)
            {
                double height = item.Y - startPoint.Y;
                double distanceX = item.X - startPoint.X;
                item.Priority = height / distanceX;
            }

            var restPsPositif = restPoints.Where(p=>p.Priority>=0).OrderBy(p=>p.Priority).ThenBy(p=> p.X);
            var restPsNegatif = restPoints.Where(p => p.Priority < 0).OrderByDescending(p => p.Priority).ThenBy(p => Math.Abs(p.X - startPoint.X));

            return new Point<double>[] { startPoint }.Concat(restPsPositif).Concat(zeroPoints).Concat(restPsNegatif).ToArray();
        }
    }
}
