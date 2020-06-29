namespace CSharpAlgo.Geometry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumNumOfIntersectionsForRanges
    {
        /// <summary>
        /// Get the Maximum Number Of Intersections For multiple intervals
        /// </summary>
        /// <param name="intervals">(min, max)  interval</param>
        /// <returns></returns>
        public static int GetMaxNumOfIntersections(IList<(int, int)> intervals)
        {
            var array = intervals.SelectMany(s => new List<(int, int)> { (s.Item1, 1), (s.Item2, -1) })
                        .OrderBy(mergeList => mergeList.Item1).ToArray();

            int max = 0;
            int res = 0;
            foreach (var item in array)
            {
                res += item.Item2;
                max = Math.Max(max, res);
            }

            return max;
        }
    }
}
