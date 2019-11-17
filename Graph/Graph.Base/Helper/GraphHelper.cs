namespace Graph.Base
{
    using System.Collections.Generic;

    public class GraphHelper
    {
        public static int[,] ConvertListToGraphMatrix(IList<(int, int, int)> list, int v, bool isDirected = false)
        {
            int[,] graph = new int[v, v];
            foreach (var item in list)
            {
                graph[item.Item1, item.Item2] = item.Item3;

                if (!isDirected)
                {
                    graph[item.Item2, item.Item1] = item.Item3;
                }
            }

            return graph;
        }

        public static int[,] ConvertListToGraphMatrix(IList<(int, int)> list, int v, bool isDirected = false)
        {
            int[,] graph = new int[v, v];
            foreach (var item in list)
            {
                graph[item.Item1, item.Item2] = 1;

                if (!isDirected)
                {
                    graph[item.Item2, item.Item1] = 1;
                }
            }

            return graph;
        }
    }
}
