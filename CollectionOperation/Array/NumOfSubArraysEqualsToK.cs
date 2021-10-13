/*
Given an array of integers nums and an integer k, 
return the total number of continuous subarrays whose sum equals to k.

For example array: 2 1 1 1 -2 1
if k = 3
The number of subarray is 3
*/

namespace CSharpAlgo.CollectionOperation.Array
{
    using static Utils.Helper.DictionaryHelper;

    public class NumOfSubArraysEqualsToK
    {
        public static int GetNumOfSubArrays(int[] array, int k)
        {
            int sum = 0;
            var dic = new VDictionary<int, int>();
            dic[0] = 1;

            int num = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                num += dic[sum - k];
                dic[sum]++;
            }

            return num;
        }
    }
}
