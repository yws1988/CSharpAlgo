/*
There are N points in space, they are asked to form M distinct groups.
Make the distance between groups to be maximum. 
(Any two points which are from different groups should be at least D distance apart.)
Output the maximun distance.
*/

using System.Collections.Generic;

namespace CSharpAlgo.Graph.Tree
{
    public class MaximumDistanceForNGroupsWithUnionFind
    {
        static int max = 3000000;

        /// <summary>
        /// get maximum distance
        /// </summary>
        /// <param name="distances">the matrix present all the distances between points</param>
        /// <param name="m">number of Groups</param>
        /// <returns></returns>
        public static int getMaxDistance(int[,] distances, int m)
        {
            int n = distances.GetLength(0);
            var subsets = UnionFind.CreateSubsets(n);

            int min = 0;
            int d = (min + max) / 2;

            while (max >= min)
            {
                for (int k = 0; k < n; k++)
                {
                    subsets[k].Parent = k;
                    subsets[k].Rank = 0;
                }

                for (int k = 0; k < n; k++)
                {
                    for (int h = k + 1; h < n; h++)
                    {
                        if (distances[k, h] < d)
                        {
                            UnionFind.Union(subsets, k, h);
                        }
                    }
                }

                var set = new HashSet<int>();

                for (int k = 0; k < n; k++)
                {
                    set.Add(UnionFind.Find(subsets, k));
                }

                int numOfGroup = set.Count;

                if (numOfGroup >= m)
                {
                    min = d + 1;
                }
                else
                {
                    max = d - 1;
                }

                d = (min + max) / 2;
            }

            return max;
        }
    }
}
