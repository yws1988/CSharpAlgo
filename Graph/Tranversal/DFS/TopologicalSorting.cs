namespace Graph.Tranversal.DFS
{
    using System.Collections.Generic;

    public class TopologicalSorting
    {
        public static Stack<int> GetSortingOrder(List<int>[] graph)
        {
            Stack<int> stack = new Stack<int>();
            int n = graph.Length;
            var vs = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!vs[i])
                {
                    TopologicalSortingUtil(graph, i, vs, stack);
                }
            }

            return stack;
        }

        static void TopologicalSortingUtil(List<int>[] graph, int i, bool[] vs, Stack<int> stack)
        {
            vs[i] = true;

            foreach (int c in graph[i])
            {
                if (!vs[c])
                {
                    TopologicalSortingUtil(graph, c, vs, stack);
                }
            }

            stack.Push(i);
        }
    }
}
