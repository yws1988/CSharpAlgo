namespace Graph.DFS.BFS.BFS
{
    using System.Collections.Generic;

    public class DFSIteration
    {
        public static IList<int> GetDFSIterationList(List<int>[] graph, int src)
        {
            var result = new List<int>();
            int v = graph.Length;
            bool[] visited = new bool[v];

            Stack<int> stack = new Stack<int>();
            stack.Push(src);

            while (stack.Count > 0)
            {
                int next = stack.Pop();
                visited[next] = true;
                result.Add(next);

                foreach (int c in graph[next])
                {
                    if (!visited[c])
                    {
                        stack.Push(c);
                    }
                }
            }

            return result;
        }
    }
}
