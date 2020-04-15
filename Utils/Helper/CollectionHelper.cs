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

        // input list {1,2,3}
        // output {1,2,3} {1,3,2} {2,1,3} {2,3,1} {3,1,2} {3,2,1}

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        // input list {{1,2}, {3,4}, {5}}
        // output list {{1,3,5},{1,4,5},{2,3,5},{2,4,5}}
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<IEnumerable<T>> lists)
        {
            var result = lists.First().Select(s => new T[] { s }.AsEnumerable<T>());
            foreach (var list in lists.Skip(1))
            {
                result = result.SelectMany(s => list, (t1, t2) => t1.Concat(new T[] { t2 }));
            }

            return result;
        }
    }
}
