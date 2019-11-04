namespace Graph.Base
{
    using System.Collections.Generic;

    public class GraphHelper<T>
    {
        public static T[,] ConvertListToGraphMatrix(IList<(int, int, T)> list, int V, bool isDirected = false)
        {
            T[,] graph = new T[V, V];
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

        public static int[,] ConvertListToGraphMatrix(IList<(int, int)> list, int V, bool isDirected = false)
        {
            int[,] graph = new int[V, V];
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
