using System;
using System.Collections.Generic;
using System.Linq;

namespace Maths.Geometric
{
    public class Interval
    {
        public double Start { get; set; }
        public double End { get; set; }

        public Interval(double start, double end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{Start} : {End}";
        }
    }

    public class MergeIntervals
    {
        public static IList<Interval> IntervalsMerge(IEnumerable<Interval> intervals)
        {
            IList<Interval> mergeIntervals = new List<Interval>();
            var newIntervals = intervals.OrderBy(i=>i.Start).ToList();

            var current = newIntervals[0];

            for (int i = 1; i < newIntervals.Count(); i++)
            {
                var next = newIntervals[i];
                if (current.End >= next.Start)
                {
                    current = new Interval(current.Start, Math.Max(current.End, next.End));
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