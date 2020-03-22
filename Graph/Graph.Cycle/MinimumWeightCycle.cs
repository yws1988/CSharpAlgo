namespace Graph.ShortestPath
{
    using System;

    public class MinimumWeightCycle
    {
        public static int GetMinimumWeightCycle(int[,] graph)
        {
            int v = graph.GetLength(0);
            int result = int.MaxValue;
            for (int i = 0; i < v; i++)
            {
                for (int j = i+1; j < v; j++)
                {
                    if (graph[i, j] > 0)
                    {
                        int temp = graph[i, j];
                        graph[i, j] = 0;
                        result=Math.Min(result, DijsktraShortestPath.GetShortestPath(graph, i, j)+temp);
                        graph[i, j] = temp;
                    }
                }
            }

            return result;
        }
    }
}
