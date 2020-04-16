namespace BitOperation
{
    using System;
    using System.Collections.Generic;

    public class NumberOfUniqueCollections
    {
        const int MaxId = 100;
        static List<int>[] collectionIdList = new List<int>[MaxId+1];
        static int[,] dp = new int[1025, MaxId+1];
        static int allmask;

        public static int GetNumOfCollections(List<int>[] lists)
        {
            int n = lists.Length;
            for (int i = 0; i < n; i++)
            {
                foreach (var num in lists[i])
                {
                    collectionIdList[num].Add(i);
                }
            }

            //  ----------------------------------------------------
            //   All mask is used to check of all persons
            //   are included or not, set all n bits as 1
            allmask = ((1 << n) - 1);

            //   Initialize all entries in dp as -1
            for (int i = 0; i < 1025; i++)
            {
                for (int j = 0; j <= MaxId; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return countWaysUtil(allmask, MaxId);
        }

        static int countWaysUtil(int mask, int i)
        {
            if (dp[mask, i] != -1) return dp[mask, i];

            if (i == 0 && mask != 0) return dp[mask, i] = 0;

            if (mask == 0) return dp[mask, i] = 1;

            var ps = collectionIdList[i];
            int total = 0;
            foreach (var p in ps)
            {
                if((mask>>p & 1) == 1)
                {
                    total+=countWaysUtil(mask & (~(1 << p)), i - 1);
                }
            }

            return dp[mask, i]=countWaysUtil(mask, i - 1) + total;
        }
    }
}
