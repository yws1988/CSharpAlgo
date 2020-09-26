using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class EdgyBaking
    {
        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\EdgyBaking.txt");
#endif

            int t = int.Parse(input.ReadLine());
            double[][] Ns = new double[t][];
            double[][][] nums = new double[t][][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = input.ReadLine().Split(' ').Select(double.Parse).ToArray();
                int N = (int)Ns[i][0];
                nums[i] = new double[N][];
                for (int h = 0; h < N; h++)
                {
                    nums[i][h] = input.ReadLine().Split(' ').Select(double.Parse).ToArray();
                }
            }

            for (int i = 0; i < t; i++)
            {
                Output(i + 1, Solve(Ns[i], nums[i]));
            }

            Console.Read();
        }

        public static double Solve(double[] Ns, double[][] nums)
        {
            int N = (int)Ns[0];
            double P = Ns[1];
            double PL = P - nums.Select(s => (s[0] + s[1]) * 2).Sum();
            if (PL == 0) return P;

            var intervals = new List<Interval>();
            intervals.Add(new Interval(0, 0));
            var newIntervals = new List<Interval>();

            for (int i = 0; i < N; i++)
            {
                double min = 2 * nums[i].Min();
                double max = 2 * Math.Sqrt(Math.Pow(nums[i][0], 2) + Math.Pow(nums[i][1], 2));

                foreach (var item in intervals)
                {
                    double minN = item.Start + min;
                    double maxN = item.End + max;

                    if (maxN < PL)
                    {
                        newIntervals.Add(new Interval(minN, maxN));
                    }
                    else if (PL >= minN && PL <= maxN)
                    {
                        return P;
                    }
                }

                intervals = MergeIntervals.IntervalsMerge(intervals.Concat(newIntervals).ToList());
                newIntervals.Clear();
            }

            return intervals.Last().End+P-PL;
        }



        public static void Output(double caseNum, double result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }

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
        public static List<Interval> IntervalsMerge(IEnumerable<Interval> intervals)
        {
            List<Interval> mergeIntervals = new List<Interval>();
            var newIntervals = intervals.OrderBy(i => i.Start).ToList();

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
