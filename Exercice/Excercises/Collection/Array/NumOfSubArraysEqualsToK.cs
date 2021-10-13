/*
Given an array of integers nums and an integer k, 
return the total number of continuous segments whose sum equals to k.
if the length of segment[l, r] is even:
sum = Cl*C(l+1)+  C(l+2)*C(l+3)+......+C(r-1)*C(r)
if the length of segment[l, r] is odd:
sum = Cl*C(l+1)+  C(l+2)*C(l+3)+......+C(r-1)*1

For example array: 5 0 5 0
if k = 0
The number of segments is 7
*/

namespace CSharpAlgo.Excercise.Excercises.Collection.Array
{
    using static Utils.Helper.DictionaryHelper;

    public class NumOfSubArraysEqualsToK
    {
        public static long GetNum(long[] array, int k)
        {
            var dic1 = new VDictionary<long, long>();
            var dic2 = new VDictionary<long, long>();

            dic1[0] = 1;
            dic2[0] = 1;

            long sum1 = 0;
            long sum2 = 0;
            long res = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (i % 2 == 1)
                {
                    sum1 += array[i] * array[i - 1];
                    res += dic1[sum1 - k];
                    dic1[sum1]++;
                }
                else
                {
                    sum2 += array[i] * array[i - 1];
                    res += dic2[sum2 - k];
                    dic2[sum2]++;
                }
            }

            sum1 = 0;
            sum2 = 0;
            dic1.Clear();
            dic2.Clear();

            dic1[0] = 1;
            dic2[0] = 1;

            if (array[0] == k) res++;
            if (array[1] == k) res++;

            for (int i = 2; i < array.Length; i++)
            {
                if (i % 2 == 1)
                {
                    sum1 += array[i - 1] * array[i - 2];
                    dic1[sum1]++;
                    res += dic1[sum1 + array[i] - k];

                }
                else
                {
                    sum2 += array[i - 1] * array[i - 2];
                    dic2[sum2]++;
                    res += dic2[sum2 + array[i] - k];
                }
            }

            return res;
        }
    }
}
