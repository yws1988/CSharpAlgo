/*
 You are given an array of n elements and an integer. 
 You must perform the following types of operations on the array:

 Find the index of the kth occurrence of x in the range l to r (both inclusive). 
 If there are no indexes that satisfy the condition, then print -1.
 Update the value that is present at the given index.
 For each query of type 1, print the index of the kth occurrence of x.
 If type is equal to 2, then element with index and value
 */
namespace CSharpAlgo.Excercise.Excercises.Graph.BinaryIndexTree
{
    using CSharpAlgo.Graph.Tree;
    using System.Collections.Generic;

    public class KthOccurrenceOfElementInArrays
    {
        public static List<int> getResult(int[] ns, int x, int[][] queries)
        { 
            int n = ns.Length;

            BinaryIndexedTree binaryIndexedTree = new BinaryIndexedTree(n);

            for (int i = 0; i < n; i++)
            {
                if (ns[i] == x)
                {
                    binaryIndexedTree.update(i, 1);
                }
            }

            List<int> res = new List<int>();

            for (int i = 0; i < queries.Length; i++)
            {
                int[] tmp = queries[i];
                int type = tmp[0];
                if (type == 1)
                {
                    int l = tmp[1];
                    int r = tmp[2];
                    int k = tmp[3];
                    int numL = binaryIndexedTree.query(l-1);
                    int numR = binaryIndexedTree.query(r);

                    if (numR >= numL + k)
                    {
                        int low = l;
                        int high = r;

                        int sum = numL + k;

                        int mid=0;

                        while (low < high)
                        {
                            mid = (low + high) >> 1;

                            if (binaryIndexedTree.query(mid) >= sum)
                            {
                                high = mid;
                            }
                            else
                            {
                                low = mid + 1;
                            }
                        }

                        res.Add(low);
                    }
                    else
                    {
                        res.Add(-1);
                    }
                }
                else
                {
                    int index = tmp[1] - 1;
                    int value = tmp[2];

                    if (ns[index] == x && value != x)
                    {
                        binaryIndexedTree.update(index, -1);
                    }

                    if (ns[index] != x && value == x)
                    {
                        binaryIndexedTree.update(index, 1);
                    }

                    ns[index] = value;
                }
            }

            return res;
        }
    }
}
