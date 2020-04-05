using Maths.Geometric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ps = new Point[] { new Point(-1, 1), new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(3, 1) };
            //Console.WriteLine(MaximunPointsInOneLine.GetMax(ps));

            var ps = new IntPoint[] { new IntPoint(1, 1), new IntPoint(3, 2), new IntPoint(5, 3), new IntPoint(4, 1) , new IntPoint(2, 3), new IntPoint(1, 4) };
            Console.WriteLine(MaximunPointsInOneLine.GetMax(ps));

            //var ps = new Point[] {
            //    new Point(0, 3), new Point(1, 1),
            //    new Point(2, 2), new Point(4, 4),
            //    new Point(0, 0), new Point(1, 2),
            //    new Point(3, 1), new Point(3, 3),
            //};
            //foreach(var item in FindTheClosestPathOfPoints.GetClosestPath(ps))
            //{
            //    Console.WriteLine(item.ToString());
            //}

            //var ps = new Point[] {
            //    new Point(2, 3), new Point(12, 30),
            //    new Point(40, 50), new Point(5, 1),
            //    new Point(12, 10), new Point(3, 4),
            //};

            //Console.WriteLine(FindTheClosestDistanceOfPoints.GetClosestPoints(ps));


            Console.Read();
        }
    }
}
