namespace Collection.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionHelper
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Shuffle<T>(T[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }

        public static List<T> MergeTwoOrderedLists<T>(List<T> la, List<T> lb) where T : IComparable
        {
            List<T> res = new List<T>();
            int lfs = la.Count();
            int lss = lb.Count();

            int i = 0, j = 0;

            while (i < lfs && j < lss)
            {
                if (la[i].CompareTo(lb[j]) > 0)
                {
                    res.Add(lb[j]);
                    j++;
                }
                else
                {
                    res.Add(la[i]);
                    i++;
                }
            }

            while (i < lfs)
            {
                res.Add(la[i]);
                i++;
            }

            while (j < lss)
            {
                res.Add(lb[j]);
                j++;
            }

            return res;
        }
    }
}
