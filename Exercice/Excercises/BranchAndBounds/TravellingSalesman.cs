/*
 * Given a set of cities and distance between every pair of cities, 
 * the problem is to find the shortest possible tour that visits every 
 * city exactly once and returns to the starting point.
 * cost
 */

namespace CSharpAlgo.Excercise.Excercises.BranchAndBounds
{
    using System;
    using System.Linq;

    public class TravellingSalesman
    {
        private static double _result = double.MaxValue;
        private static double[][] _twoMinimumCostsEdges;

        //public static void Main()
        //{
        //    double[,] cost = new double[,]{{0, 10, 15, 20},
        //                                 {10, 0, 35, 25},
        //                                 {15, 35, 0, 30},
        //                                 {20, 25, 30, 0}
        //                                };
        //    Console.WriteLine(GetShortest(cost));
        //}

        public static double GetShortest(double[,] costs)
        {
            int n = costs.GetLength(0);
            _twoMinimumCostsEdges = new double[n][];

            double cBound = 0;
            for (int i = 0; i < n; i++)
            {
                _twoMinimumCostsEdges[i] = GetMin(costs, i, n);
                cBound += _twoMinimumCostsEdges[i].Sum();
            }

            cBound = cBound / 2;

            // Contains the travelling salesman path
            int[] parents = new int[n];
            bool[] vs = new bool[n];
            vs[0] = true;
            GetShortestUtil(costs, n, parents, vs, cBound, 0, 1);

            return _result;
        }

        public static void GetShortestUtil(double[,] costs, int n, int[] parents, bool[] vs, double cBound, double cost, int level)
        {
            if (level == n)
            {
                if (costs[parents[n - 1], 0] != 0)
                {
                    double totalCost = costs[parents[n - 1], 0] + cost;
                    if (totalCost < _result)
                    {
                        _result = totalCost;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (!vs[i] && costs[parents[level - 1], i] != 0)
                {
                    int parentVetex = parents[level - 1];
                    double nextCost = cost + costs[parentVetex, i];
                    double aBound = level == 1 ? (cBound - (_twoMinimumCostsEdges[parentVetex][0] + _twoMinimumCostsEdges[i][0]) / 2) : (cBound - (_twoMinimumCostsEdges[parentVetex][1] + _twoMinimumCostsEdges[i][0]) / 2);
                    double nCBound = nextCost + aBound;

                    if (nCBound < _result)
                    {
                        vs[i] = true;
                        parents[level] = i;
                        GetShortestUtil(costs, n, parents, vs, aBound, nextCost, level + 1);
                    }

                    vs[i] = false;
                    parents[level] = 0;
                }
            }
        }

        static double[] GetMin(double[,] costs, int vertex, int n)
        {
            double min = double.MaxValue;
            double secondMin = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                if (min >= costs[vertex, i])
                {
                    min = costs[vertex, i];
                    secondMin = min;
                }
            }

            return new double[] { min, secondMin };
        }
    }

}