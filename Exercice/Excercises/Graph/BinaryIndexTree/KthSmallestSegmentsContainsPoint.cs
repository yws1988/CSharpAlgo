/*
You are given N segments [L, R]. Now, you need to answer some queries based on these segments.
Overall, you need to answer Q queries. In each query you shall be given 2 integers K and X. 
You need to find the size of the Kth smallest segment that contains point X.
If no K segments contain point X, returns -1 instead as the answer to that query.
A segment [L, R] is said to contain a point X, if  L<=X<=R. 
When we speak about the  smallest segment, we refer to the one having the smallest size. 
*/

namespace CSharpAlgo.Excercise.Excercises.Graph.BinaryIndexTree
{
    using System;
    using System.Collections.Generic;
    using CSharpAlgo.Graph.Tree;

    public class KthSmallestSegmentsContainsPoint
    {
        public static int n, q, maxn;
        public static Pair[][] al, qr;
        public static int[] size, sortedSize, datas, cnt, res;
        public static BinaryIndexedTree binaryIndexedTree;
        public static Query[] queries;
            
        /// <summary>
        /// get all the result into an array
        /// </summary>
        /// <param name="intervals">All the segments [L, R]</param>
        /// <param name="queries">All the queries (K, X)</param>
        /// <returns></returns>
        public static int[] getResult(List<Interval> intervals, List<Query> queries)
        {
            n = intervals.Count;
            size = new int[n];
            sortedSize = new int[n];

            for (int i = 0; i < n; i++)
            {
                size[i] = intervals[i].Right - intervals[i].Left + 1;
                sortedSize[i] = size[i];
            }

            var dataList = new List<int>();
            q = queries.Count;

            for (int i = 0; i < q; i++)
            {
                dataList.Add(queries[i].Point);
            }

            for (int i = 0; i < n; i++)
            {
                dataList.Add(intervals[i].Left);
                dataList.Add(intervals[i].Right);
            }

            datas = dataList.ToArray();
            Array.Sort(datas);
            Array.Sort(sortedSize);

            maxn = datas.Length + 2;
            cnt = new int[maxn];

            for (int i = 0; i < n; i++)
            {
                intervals[i].Left = Array.BinarySearch(datas, intervals[i].Left);
                intervals[i].Right = Array.BinarySearch(datas, intervals[i].Right);
                size[i] = Array.BinarySearch(sortedSize, size[i]) + 1;
                cnt[intervals[i].Left]++;
                cnt[intervals[i].Right + 1]++;
            }

            al = new Pair[maxn][];

            for (int i = 0; i < maxn; i++)
            {
                al[i] = new Pair[cnt[i]];
                cnt[i] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                int curr1 = intervals[i].Left, curr2 = intervals[i].Right + 1;

                al[curr1][cnt[curr1]++] = new Pair(size[i], 1);

                al[curr2][cnt[curr2]++] = new Pair(size[i], -1);
            }

            cnt.Fill(0);

            for (int i = 0; i < q; i++)
            {
                queries[i].Point = Array.BinarySearch(datas, queries[i].Point);

                cnt[queries[i].Point]++;
            }

            qr = new Pair[maxn][];
            for (int i = 0; i < maxn; i++)
            {
                qr[i] = new Pair[cnt[i]];
                cnt[i] = 0;
            }

            for (int i = 0; i < q; i++)
            {
                int curr = queries[i].Point;

                qr[curr][cnt[curr]++] = new Pair(i, queries[i].K);
            }

            binaryIndexedTree = new BinaryIndexedTree(n);
            
            res = new int[q];

            for (int i = 0; i < maxn; i++)
            {
                foreach (Pair pair in al[i])
                {
                    binaryIndexedTree.update(pair.Index, pair.Value);
                }

                foreach (Pair query in qr[i])
                {
                    int k = query.Value, low = 1, high = n;

                    while (low < high)
                    {
                        int mid = (low + high) >> 1;

                        if (binaryIndexedTree.query(mid) >= k)
                        {
                            high = mid;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }

                    res[query.Index] = binaryIndexedTree.query(low) >= k ? low : -1;
                }
            }

            for (int i = 0; i < q; i++)
            {
                res[i] = res[i] == -1 ? -1 : sortedSize[res[i] - 1];
            }

            return res;
        }


        public class Interval : IComparable<Interval>
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public Interval(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public int CompareTo(Interval other)
            {
                return (this.Right - this.Left) - (other.Right - other.Left);
            }
        }

        public class Query
        {
            public int K { get; set; }
            public int Point { get; set; }

            public Query(int k, int point)
            {
                K = k;
                Point = point;
            }
        }

        public class Pair
        {
            public int Index { get; set; }
            public int Value { get; set; }

            public Pair(int idx, int val)
            {
                Index = idx;
                Value = val;
            }
        }

           
    }

    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }
    }
}
