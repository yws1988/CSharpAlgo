using System.Collections.Generic;
using System.Linq;

namespace CSharpAlgo.Graph.MinimumSpanningTree
{
    public class AnyTwoPointsDistanceFromMinimumSpanningTree
    {
        public static Dictionary<(int, int), int> GetMinimumDistance(List<Pair>[] graph)
        {
            int n = graph.Length;
            List<Pair> path;
            MinimumSpanningTree.GetMinimumSpanningTree(graph, out path);
                    
            List<Pair>[] newGraph = Enumerable.Range(0, n).Select(s => new List<Pair>()).ToArray();

            var distances = new Dictionary<(int, int), int>();

            for (int k = 0; k < n; k++)
            {
                var vs = new bool[n];
                Bfs(k, distances, newGraph, vs);
            }

            return distances;
        }

        static void Bfs(int root, Dictionary<(int, int), int> dic, List<Pair>[] graph, bool[] vs)
        {
            var queue = new Queue<int>();
            queue.Enqueue(root);
            dic[(root, root)] = 0;

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                vs[currentNode] = true;

                foreach (var pair in graph[currentNode])
                {
                    if (!vs[pair.Des])
                    {
                        dic[(root, pair.Des)] = dic[(root, pair.Src)] + pair.Weight;
                        queue.Enqueue(pair.Des);
                    }
                }
            }
        }
    }
}
