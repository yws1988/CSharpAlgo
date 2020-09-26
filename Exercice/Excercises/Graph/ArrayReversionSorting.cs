/*
 * Give an array int, Sort the array from small value to big value use the following method:
 * To Sort element k, all the elements from 1 to k will be reversed. Get the minimum steps to sort
 * the given array to be an ordered array.
 * For example, for array(3, 2, 1, 4)
 * The minimum step will be 1, we can sort(3) to get ordered array (1, 2, 3, 4)
 */

namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CSharpAlgo.DataStructure.Heap;
    using Utils.Helper;

    public class ArrayReversionSorting
    {
        public static int GetMinimumSteps(int[] array)
        {
            int n = array.Length;
            var sortedArray = new int[n];
            array.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);

            var queue = new PriorityQueue<(int[], int)>((t1, t2) => t1.Item2 - t2.Item2);

            queue.Enqueue((array, 0));
            var vs = new HashSet<int>();
            int maxStep = 2 * (n - 1);

            while (queue.Count() > 0)
            {
                var (arr, step) = queue.Dequeue();
                if (step >= maxStep) return maxStep;

                if (arr.SequenceEqual(sortedArray))
                {
                    return step;
                }

                vs.Add(array.GetHashCode());

                for (int i = 1; i < n; i++)
                {
                    var next = ArrayHelper.Inverse(arr, i);
                    if (!vs.Contains(next.GetHashCode()))
                    {
                        queue.Enqueue((next, step + 1));
                    }
                }
            }

            return int.MaxValue;
        }
    }
}