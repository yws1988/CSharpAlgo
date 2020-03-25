namespace graph.Flow
{
    using System.Collections.Generic;
    public class BiPartiteGraph
    {
        public static bool IsGraphBipartite(List<int>[] graph)
        {
            int n = graph.Length;
            int[] color = new int[n];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            color[0] = 1;

            while (queue.Count > 0)
            {
                int p=queue.Dequeue();
                foreach (var c in graph[p])
                {
                    if(color[c] == 0)
                    {
                        queue.Enqueue(c);
                        color[c] = color[p] == 1 ? 2 : 1;
                    }else if(color[c] == color[p])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
