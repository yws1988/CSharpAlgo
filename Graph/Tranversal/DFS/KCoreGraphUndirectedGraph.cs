namespace Graph.Tranversal.DFS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KCoreGraphUndirectedGraph
    {
        //Given a graph G and an integer K, K-cores of the graph are connected components that 
        //are left after all vertices of degree less than k have been removed (Source wiki)

        public static List<int> GetKCoreVertex(List<int>[] graph, int k)
        {
            int v = graph.Length;
            int startPoint = 0;
            bool hasKeyCore = false;
            int[] degrees = new int[v];

            int min = Int32.MaxValue;
            for (int i = 0; i < v; i++)
            {
                degrees[i] = graph[i].Count;
                if (degrees[i] < min)
                {
                    min = degrees[i];
                    startPoint = i;
                }
            }

            bool[] vs = new bool[v];
            if (degrees[startPoint] < k)
            {
                DFSUtil(graph, startPoint, degrees, k, vs);
            }

            for (int i = 0; i < v; i++)
            {
                if (!vs[i])
                {
                    DFSUtil(graph, i, degrees, k, vs);
                }
            }

            hasKeyCore = degrees.Any(s => s >= k);

            if (hasKeyCore)
            {
                return degrees.Select((val, idx) => (val, idx)).ToArray().Where(item => item.val >= k).Select(item => item.idx).ToList();
            }

            return null;
        }

        public static bool DFSUtil(List<int>[] graph, int s, int[] degrees, int k, bool[] vs)
        {
            vs[s] = true;

            foreach (int c in graph[s])
            {
                if (degrees[s] < k)
                {
                    degrees[c]--;
                }

                if (!vs[c] && DFSUtil(graph, c, degrees, k, vs))
                {
                    degrees[s]--;
                }
            }

            return degrees[s] < k ? true : false;
        }

        
    }
}
