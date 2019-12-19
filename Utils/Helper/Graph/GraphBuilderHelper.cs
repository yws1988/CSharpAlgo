namespace Utils.Graph.Helper
{
    using System.Collections.Generic;
    using System.Linq;

    public static class GraphBuilderHelper
    {
        public List<int>[] CreateListArray(int n)
        {
            return Enumerable.Range(0, n).Select(s => new List<int>()).ToArray();
        }

        public static List<int>[] CreateListArray(int n, int[][] arr, bool isDirected = false)
        {
            var graph = Enumerable.Range(0, n).Select(s => new List<int>()).ToArray();
            foreach (var item in arr)
            {
                int src = item[0];
                int des = item[1];
                graph[src].Add(des);

                if (!isDirected)
                {
                    graph[des].Add(src);
                }
            }

            return graph;
        }
    }
}
