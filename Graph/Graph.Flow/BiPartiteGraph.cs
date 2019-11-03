namespace Graph.Flow
{
    using Graph.Base;
    using System.Collections.Generic;
    public class BiPartiteGraph
    {
        public static bool IsGraphBipartite(AdjacencyMatrix graph)
        {
            int[] color = new int[graph.N];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            color[0] = 1;

            while (queue.Count > 0)
            {
                int idx=queue.Dequeue();
                for (int i = 0; i < graph.N; i++)
                {
                    if (i == idx) continue;

                    if(graph.Value[idx, i] == 1)
                    {
                        if (color[idx] == color[i])
                        {
                            return false;
                        }

                        if (color[i] == 0)
                        {
                            color[i] = 3 - color[idx];
                            queue.Enqueue(i);
                        }
                    }
                }
            }
            return true;
        }
    }
}
