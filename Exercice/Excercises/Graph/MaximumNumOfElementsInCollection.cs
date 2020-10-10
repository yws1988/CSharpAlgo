/*
  Give n lines represent n collections id from 0 to n-1, each line contains a few numbers, the first number
  represents the number of the elements in this collection. The other numbers reprensents the id of
  the subcollections, there is no cycle dependency in the collection relations. Ouput the maxinum number of
  elements contained in one collection.
  For example:
    10 1 2
    10
    10 3
    2 1

    Output 32
 */

namespace CSharpContestProject
{
    using System.Collections.Generic;
    using System.Linq;
    using CSharpAlgo.Graph.Traversal.DFS;

    public class MaximumNumOfElementsInCollection
    {
        public static int GetMaximumNumOfElements(List<int>[] subCollections, int[] numOfElements, int n)
        {
            var orderedCollectionIds = TopologicalSorting.GetSortingOrder(subCollections).Reverse().ToArray();
            var setOfCollections = Enumerable.Range(0, n).Select(s => new HashSet<int>()).ToArray();

            for (int m = 0; m < n; m++)
            {
                int id = orderedCollectionIds[m];
                setOfCollections[id].Add(id);

                foreach (var subId in subCollections[id])
                {
                    setOfCollections[id] = setOfCollections[id].Concat(setOfCollections[subId]).ToHashSet();
                }
            }

            var result = new int[n];
            for (int h = 0; h < n; h++)
            {
                 result[h] = setOfCollections[h].Select(d => numOfElements[d]).Sum();
            }

            return result.Max();
        }
    }
}