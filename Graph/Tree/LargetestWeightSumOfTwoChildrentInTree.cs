/*
 * Given a directional tree, the tree node is numbered 0 to n, 0 is the root node of the tree,
 * each node of tree has a weight and each node just has one parent.
 * Get the largest sum of the weights for at most two direct child nodes in the tree. 
 */

namespace CSharpAlgo.Graph.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LargetestWeightSumOfTwoChildrentInTree
    {
        // (int, int) first is node number, second is weight
        public static int GetLargestSum(List<(int, int)>[] graph)
        {
            int n = graph.Length;
            var dp = new int[n];
            CalMax(graph, 0, dp);

            var dpmax = new int[n];
            CalMaxDifferent(graph, 0, dpmax, dp);

            return dpmax.Max();
        }
        static int CalMax(List<(int, int)>[] graph, int root, int[] dp)
        {
            if (graph[root].Count == 0)
            {
                return dp[root] = 0;
            }

            foreach (var child in graph[root])
            {
                dp[root] = Math.Max(dp[root], CalMax(graph, child.Item1, dp) + Math.Abs(child.Item2));
            }

            return dp[root];
        }

        static void CalMaxDifferent(List<(int, int)>[] graph, int root, int[] dpmax, int[] dp)
        {
            int max = 0;
            int smax = 0;

            foreach (var child in graph[root])
            {
                CalMaxDifferent(graph, child.Item1, dpmax, dp);

                int childSum = dp[child.Item1] + Math.Abs(child.Item2);
                if (max <= childSum)
                {
                    smax = max;
                    max = childSum;
                }
            }

            dpmax[root] = max + smax;
        }
    }


}
