/*
Given a list of the ordered the strings, for example AA BB means AA is prioritized
than string BB.

Output
A list of  describing an order with priority, if such an order does not exist, return KO.
Note: There are several solutions, you can return any.
Example
Input
5 4
club-mate pamplemousse
pamplemousse grenadine
mojito club-mate
fraise club-mate
Output
mojito < fraise < club-mate < pamplemousse < grenadine
 */

namespace Graph.Tranversal.DFS
{
    using Graph.Cycle;
    using Graph.Tranversal.DFS;
    using System.Collections.Generic;
    using System.Linq;

    public class TopologicalOrderedStrings
    {
        /// <summary>
        /// Get the topological order
        /// </summary>
        /// <param name="orderedStrings">the ordered ingredients</param>
        /// <param name="n">the number of ingredients</param>
        public static string GetTopologicalOrder(string[][] orderedStrings, int n)
        {
            var dic = new Dictionary<string, int>();
            var list = new List<string>();
            var g = CreateListArray<int>(n);

            int v = 0;
            foreach (var item in orderedStrings)
            {
                if (!dic.ContainsKey(item[0]))
                {
                    dic[item[0]] = v++;
                    list.Add(item[0]);
                }

                if (!dic.ContainsKey(item[1]))
                {
                    dic[item[1]] = v++;
                    list.Add(item[1]);
                }

                g[dic[item[0]]].Add(dic[item[1]]);
            }

            if (CycleDirectedGraph.DoesGraphContainsCycle(g))
            {
                return "KO";
            }

            var stack = TopologicalSorting.GetSortingOrder(g);

            return string.Join(" ", stack.Select(s => list[s]));
        }

        private static List<T>[] CreateListArray<T>(int n)
        {
            return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
        }
    }
}
