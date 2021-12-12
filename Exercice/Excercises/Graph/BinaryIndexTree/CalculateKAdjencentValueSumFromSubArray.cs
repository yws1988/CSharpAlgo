/*
Give an array A with n elements. 
Define S[i] will be the sum of k left adjencent numbers and A[i].

Give Q queries with 3 values, each query reprensents one operation:
For query type 1, query will contain 3 space-separated integers l, r and k.
Calculate the sum of value S[l] to S[r] with k value.
For query type 2, line will contain 2 space-separated integers i and v.
That means to change value A[i] to v.
 */

namespace CSharpAlgo.Excercise.Excercises.Graph.BinaryIndexTree
{
    using CSharpAlgo.Graph.Tree;
    using System;
    using System.Collections.Generic;

    public class CalculateKAdjencentValueSumFromSubArray
    {
        public static List<long> GetResult(int[][] queries, int[] ns)
        {
            int n = ns.Length;
            var bit = new BinaryIndexedTree(ns);
            var bitTriangleAsc = new BinaryIndexedTree(n);
            var bitTriangleDes = new BinaryIndexedTree(n);

            for (int i = 0; i < n; i++)
            {
                bitTriangleAsc.update(i, ns[i] * (i + 1));
                bitTriangleDes.update(i, ns[i] * (n - i));
            }

            var res = new List<long>();

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                var query = queries[i];

                if (query[0] == 1)
                {
                    int l = query[1] - 1;
                    int r = query[2] - 1;
                    int k = query[3];

                    int top = Math.Min(k + 1, r - l + 1);
                    int left = l - k;
                    int topLeft = left + top - 1;
                    int topRight = r - top + 1;

                    int valueZero = 0;

                    if (left < 0)
                    {
                        valueZero = -left;
                        left = 0;
                    }

                    if (topLeft < 0)
                    {
                        topLeft = 0;
                        valueZero = 0;
                    }

                    var tmpRes = bitTriangleAsc.query(topLeft - 1) - bitTriangleAsc.query(left - 1);

                    if (valueZero > 0)
                    {
                        tmpRes += (bit.query(topLeft - 1) - bit.query(left - 1)) * valueZero;
                    }
                    else
                    {
                        tmpRes -= (bit.query(topLeft - 1) - bit.query(left - 1)) * left;
                    }

                    tmpRes += (bit.query(topRight) - bit.query(topLeft - 1)) * top;
                    tmpRes += bitTriangleDes.query(r) - bitTriangleDes.query(topRight);
                    tmpRes -= (bit.query(r) - bit.query(topRight)) * (n - r - 1);
                    res.Add(tmpRes);
                }
                else
                {
                    int idx = query[1] - 1;
                    int val = query[2];

                    if (ns[idx] != val)
                    {
                        int addValue = val - ns[idx];
                        bit.update(idx, addValue);
                        bitTriangleAsc.update(idx, addValue * (idx + 1));
                        bitTriangleDes.update(idx, addValue * (n - idx));

                        ns[idx] = val;
                    }
                }
            }

            return res;
        }
    }
}
