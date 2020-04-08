namespace Utils.Helper.Math
{
    using DataStructure.Models.Math;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RangeHeper
    {
        public static bool IsIntersect<T>(Range<T> one, Range<T> two) where T:IComparable
        {
            T min = one.Min.CompareTo(two.Min) > 0 ? one.Min : two.Min;
            T max = one.Max.CompareTo(two.Max) < 0 ? one.Max : two.Max;
            if (min.CompareTo(max) <= 0)
            {
                return true;
            }

            return false;
        }

        public static Range<T> Intersect<T>(Range<T> one, Range<T> two) where T : IComparable
        {
            T min = one.Min.CompareTo(two.Min) > 0 ? one.Min : two.Min;
            T max = one.Max.CompareTo(two.Max) < 0 ? one.Max : two.Max;
            if (min.CompareTo(max) <= 0)
            {
                return new Range<T>(min, max);
            }

            return null;
        }

        public static IList<Range<double>> MergeRanges(IEnumerable<Range<double>> intervals)
        {
            IList<Range<double>> mergeIntervals = new List<Range<double>>();
            var newIntervals = intervals.OrderBy(i => i.Min).ToList();

            var current = newIntervals[0];

            for (int i = 1; i < newIntervals.Count(); i++)
            {
                var next = newIntervals[i];
                if (current.Max >= next.Min)
                {
                    current = new Range<double>(current.Min, Math.Max(current.Max, next.Max));
                }
                else
                {
                    mergeIntervals.Add(current);
                    current = next;
                }
            }

            mergeIntervals.Add(current);

            return mergeIntervals;
        }
    }
}
