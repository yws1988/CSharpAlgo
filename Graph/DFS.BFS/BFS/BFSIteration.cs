namespace Graph.DFS.BFS.BFS
{
    using System.Collections.Generic;

    public class BFSIteration
    {
        public static IList<int> GetBFSIterationList(List<int>[] graph, int src)
        {
            var result = new List<int>();
            int v = graph.Length;
            bool[] visited = new bool[v];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                visited[next] = true;
                result.Add(next);

                foreach (int c in graph[next])
                {
                    if (!visited[c])
                    {
                        queue.Enqueue(c);
                    }
                }
            }

            return result;
        }
    }
}
