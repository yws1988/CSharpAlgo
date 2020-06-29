namespace GeometryTest
{
    using CSharpAlgo.Geometry;
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Linq;
    using Utils;

    [TestFixture]
    public class MaximumNumOfIntersectionsForRangesTest
    {
        [Test]
        public void Returns_Max_Number_Of_Intersections_With_Many_Intervals()
        {
            // Arrange
            IO.Reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/IOFiles/MaximumNumOfIntersectionsForRangesInput.txt");
            int n = IO.ReadInt();
            var intervals = IO.ReadIntMatrix(n).Select(s => (s[0], s[1])).ToList();

            // Act
            var result = MaximumNumOfIntersectionsForRanges.GetMaxNumOfIntersections(intervals);

            // Assert
            Assert.AreEqual(50012, result);
        }
    }
}
