/*
You are given a string S of length N. The string contains only 'a', 'b', and 'c'.
Your task is to find the count of substrings in string S that 
the frequency of occurrence of character 'a' is strictly more than occurrence of 'c' in the string.
*/

namespace CSharpAlgo.Excercise.Excercises.Graph.BinaryIndexTree
{
    using CSharpAlgo.Graph.Tree;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumOfSortedStrings
    {
        public const int mod = (int)(1e9 + 7);

        public static int getNum(string str)
        {
            int n = str.Length;

            int[] sum = new int[n];

            sum[0] = str[0] == 'a' ? 1 : str[0] == 'c' ? -1 : 0;

            for (int i = 1; i < n; i++)
            {
                int value = str[i] == 'a' ? 1 : str[i] == 'c' ? -1 : 0;
                sum[i] += sum[i - 1] + value;
            }

            var sortedSum = new HashSet<int>(sum).ToArray();
            Array.Sort(sortedSum);
            int size = sortedSum.Length;

            BinaryIndexedTree binaryIndexedTree = new BinaryIndexedTree(size);

            int res = 0;
            for (int i = 0; i < n; i++)
            {
                int idx = Array.BinarySearch(sortedSum, sum[i]);
                int tsum = sum[i] > 0 ? 1 : 0;

                if (idx > 0)
                {
                    tsum = (tsum + binaryIndexedTree.query(idx - 1)) % mod;
                }

                res = (res + tsum) % mod;

                binaryIndexedTree.update(idx, 1);
            }

            return res;
        }
    }

}