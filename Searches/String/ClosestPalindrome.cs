// Given a number N.our task is to find the closest Palindrome number
// whose absolute difference with given number is minimum and absolute 
// difference must be greater than 0.

namespace Searching.String
{
    using DataStructure.Heap;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClosestPalindrome
    {
        public static string GetClosestPalindromeString(string str)
        {
            long rN = long.Parse(str);
            long len = str.Length;

            //number like 1000 expected 999
            if (len == 1 || (rN == (long)Math.Pow(10, len - 1)))
            {
                return (rN - 1).ToString();
            }

            //number like 999 expected 1001
            if (len>2 && rN == (long)Math.Pow(10, len)-1)
            {
                return (rN + 2).ToString();
            }

            var pQ = new PriorityQueue<long>((f, n) => {
                long v1 = Math.Abs(f - rN);
                long v2 = Math.Abs(n - rN);
                if (v1 == v2)
                {
                    return Math.Sign(f - n);
                }
                else
                {
                    return Math.Sign(v1 - v2);
                }
            });

            int l = str.Length / 2;
            int pl = str.Length % 2 == 0 ? l : l + 1;

            var pStr = str.Substring(0, pl);
            var list = GetPossibleValues(pStr);
            long value = long.Parse(pStr);
            list.AddRange(GetPossibleValues((value+1).ToString()));

            long valueR1 = value - 1;
            if (valueR1 == 0)
            {
                valueR1 = 9;
            }

            list.AddRange(GetPossibleValues(valueR1.ToString()));
            list.Remove(rN);

            foreach (var item in list)
            {
                pQ.Enqueue(item);
            }

            return pQ.Peek().ToString();
        }

        static List<long> GetPossibleValues(string root)
        {
            var list = new List<long>();
            int len = root.Length;
            long value = long.Parse(root);
            list.Add(value);
            long rValue = long.Parse(new string(root.Reverse().ToArray()));
            list.Add(value * (long)Math.Pow(10, len) + rValue);

            if (len > 1)
            {
                list.Add(value * (long)Math.Pow(10, len-1) + long.Parse(new string(root.Substring(0, len - 1).Reverse().ToArray())));
            }

            return list;
        }
    }
}
