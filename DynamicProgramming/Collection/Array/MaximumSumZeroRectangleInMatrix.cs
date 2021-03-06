﻿/*
 *  Given a 2D array, find the maximum sum subarray in it. For example
 *  {{1, 2, -1, -4, -20},  
 *  {-8, -3, 4, 2, 1},  
 *  {3, 8, -8, 1, 3},  
 *  {-4, -1, 1, 7, -6}}
 *  Result:
 *  (Top, Left) (0, 1)
 *  (Bottom, Right) (3, 2)
 *  sum is: 0
 */
namespace CSharpAlgo.DynamicProgramming.Collection.Array
{
    using System;
    using System.Collections.Generic;

    public class MaximumSumZeroRectangle
    {
        static int mL, mR, mT, mB;
        static int Max = -1;

        public static void Calculate(double[,] arr)
        {
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);

            for (int left = 0; left < col; left++)
            {
                double[] temp = new double[row];

                for (int right = left; right < col; right++)
                {
                    for (int i = 0; i < row; i++)
                    {
                        temp[i] += arr[i, right];
                    }
                    MaximumSubArraySumZero(temp, left, right);
                }
            }

            Console.WriteLine($"Left top {mL}:{mT} Right bottom {mR}:{mB}");

            for (int r = mT; r <= mB; r++)
            {
                for (int c = mL; c <= mR; c++)
                {
                    Console.Write(arr[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void MaximumSubArraySumZero(double[] temp, int left, int right)
        {
            double sum = 0;
            int start = 0;
            int end = 0;
            int max = 0;

            Dictionary<double, int> dic = new Dictionary<double, int>();

            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i];

                if (temp[i]==0 && max==0)
                {
                    max = 1;
                    start = i;
                    end = i;
                }
                else if (sum == 0)
                {
                    start = 0;
                    end = i;
                    max = i + 1;
                }
                else
                {
                    if (dic.ContainsKey(sum))
                    {
                        int len = i - dic[sum];
                        if (len > max)
                        {
                            max = len;
                            start = dic[sum]+1;
                            end = i;
                        }
                    }
                    else
                    {
                        dic.Add(sum, i);
                    }
                }
            }

            if (Max < max*(right-left+1))
            {
                Max = max * (right - left + 1);
                mL = left;
                mR = right;
                mT = start;
                mB = end;
            }
        }
    }
}
