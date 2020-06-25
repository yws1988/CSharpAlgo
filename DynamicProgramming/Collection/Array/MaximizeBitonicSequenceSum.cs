/*
 * Given an array of integers. A subsequence of arr[] is called Bitonic if 
 * it is first increasing, then decreasing.
 * Input : arr[] = {1, 15, 51, 45, 33, 100, 12, 18, 9}
 * Output : 194
 * Maximum sum Bi-tonic sub-sequence is 1 + 15 + 51 + 100 + 18 + 9 = 194
 */
namespace DynamicProgramming.Collection.Array
{
    using System;

    public class MaximizeBitonicSequenceSum
    {
        public static double GetMaxSum(double[] array)
        {
            int len = array.Length;
            // increasing and descrising
            double[] dpIncreasing = new double[len];
            double[] dpDescreasing = new double[len];

            for (int i = 0; i < len; i++)
            {
                dpIncreasing[i] = dpDescreasing[i] = array[i];
            }

            dpIncreasing[0] = array[0];
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i])
                    {
                        dpIncreasing[i] = Math.Max(dpIncreasing[i], dpIncreasing[j] + array[i]);
                    }
                }
            }

            dpDescreasing[len - 1] = array[len - 1];
            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (array[i] > array[j])
                    {
                        dpDescreasing[i] = Math.Max(dpDescreasing[i], dpDescreasing[j] + array[i]);
                    }
                }
            }

            double max = double.MinValue;
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, dpIncreasing[i] + dpDescreasing[i] - array[i]);
            }

            return max;
        }
    }
}
