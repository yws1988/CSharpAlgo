/*
Give an array A with n elments, each element is unique, two elements A[i] and A[j] from array A,
if i<j and A[i]>A[j], this is called valid inversion count. Calculate how many pair of inversion
count in a given array.
For example:
3 2 4 6 1

there are 5 pairs of inversion count
 */

namespace CSharpAlgo.Graph.Tree.BinaryIndexTree
{
    using System;

    public class NumOfPairsElementAIsGreaterThanBInArray
    {
        public static long GetNum(int[] ns)
        {
            int n = ns.Length;

            var sortedNs = new int[n];

            for (int j = 0; j < n; j++)
            {
                sortedNs[j] = ns[j];
            }

            Array.Sort(sortedNs);

            for (int j = 0; j < n; j++)
            {
                ns[j] = Array.BinarySearch(sortedNs, ns[j]);
            }

            Array.Reverse(ns);

            var bit = new BinaryIndexedTree(n);

            long total = 0;
            bit.update(ns[0], 1);

            for (int j = 1; j < n; j++)
            {
                total += bit.query(ns[j] - 1);
                bit.update(ns[j], 1);
            }

            return total;
        }
    }
}
