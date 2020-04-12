namespace GeometryTest
{
    using Geometry;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class SmallestEnclosingCircleTest
    {
        [Test]
        public void MakeCircle_Get()
        {
            var points = new List<Point>()
            {
                new Point(0, 0),
                new Point(6, 0),
                new Point(3, 6),
                new Point(9, 6),
            };

            var circle = SmallestEnclosingCircle.GetCircle(points);

            Assert.AreEqual(4.5, circle.center.x);
            Assert.AreEqual(3, circle.center.y);
        }
    }
}
