/*
    Given a grid of numbers, find maximum length Snake sequence and print it. If multiple snake sequences exists with the maximum length, 
    print any one of them.

    A snake sequence is made up of adjacent numbers in the grid such that for each number, 
    the number on the right or the number below it is +1 or -1 its value. For example, 
    if you are at location (x, y) in the grid, you can either move right i.e. 
    (x, y+1) if that number is ± 1 or move down i.e. (x+1, y) if that number is ± 1.

    For example,

    9, 6, 5, 2
    8, 7, 6, 5
    7, 3, 1, 6
    1, 1, 1, 7

    In above grid, the longest snake sequence is: (9, 8, 7, 6, 5, 6, 7)
 */

namespace CSharpAlgo.Excercise.Excercises.BranchAndBounds.Simple
{
    using System;
    using System.Collections.Generic;

    public class MaximumLengthSnakeInMatrix
    {
        public static List<(int, int)> GetPath(int[,] graph)
        {
            int[,] dp = new int[graph.GetLength(0), graph.GetLength(1)];
            int max = 0;
            int[] maxPoint = new int[2];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (i > 0 || j > 0)
                    {
                        if (j > 0 && IsAjacentCell(graph[i, j - 1], graph[i, j]))
                        {
                            dp[i, j] = Math.Max(dp[i, j - 1] + 1, dp[i, j]);
                        }

                        if (i > 0 && IsAjacentCell(graph[i - 1, j], graph[i, j]))
                        {
                            dp[i, j] = Math.Max(dp[i - 1, j] + 1, dp[i, j]);
                        }
                    }

                    if (dp[i, j] == 0) dp[i, j] = 1;

                    if (dp[i, j] > max)
                    {
                        max = dp[i, j];
                        maxPoint[0] = i;
                        maxPoint[1] = j;
                    }
                }
            }

            var stack = new Stack<(int, int)>();

            int m = maxPoint[0];
            int n = maxPoint[1];

            while (max > 0)
            {
                stack.Push((m, n));
                max--;

                if (n > 0 && dp[m, n - 1] == max)
                {
                    n--;
                }
                else if (m > 0 && dp[m - 1, n] == max)
                {
                    m--;
                }
            }

            return new List<(int, int)>(stack);
        }

        static bool IsAjacentCell(int x, int y)
        {
            return Math.Abs(x - y) == 1 ? true : false;
        }
    }
}
