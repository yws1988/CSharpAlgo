namespace Geometric
{
    using Geometric;
    using System;
    using System.Linq;

    class FindTheClosestPathOfPoints
    {
        public static Point[] GetClosestPath(Point[] ps)
        {
            var sP = ps.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            var zeroPs = ps.Where(p=>p.X==sP.X).OrderBy(p=>p.Y).Skip(1);
            var restPs = ps.Where(p => p.X != sP.X);

            foreach (var item in restPs)
            {
                double height = item.Y - sP.Y;
                double distanceX = item.X - sP.X;
                item.Priority = height / distanceX;
            }

            var restPsPositif = restPs.Where(p=>p.Priority>=0).OrderBy(p=>p.Priority).ThenBy(p=>Math.Abs(p.X-sP.X));
            var restPsNegatif = restPs.Where(p => p.Priority < 0).OrderByDescending(p => p.Priority).ThenBy(p => Math.Abs(p.X - sP.X));

            return new Point[] { sP }.Concat(restPsPositif).Concat(zeroPs).Concat(restPsNegatif).ToArray();
        }
    }
}
