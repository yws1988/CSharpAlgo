namespace Graph.Base.Helper
{
    using System.Collections.Generic;

    public static class BuilderHelper
    {
        public static List<T>[] Build<T>(int v)
        {

            return new AdjacencyList<T>(v);
        }

        public static void AddEdge<T>(this AdjacencyList<T> graph, int index, T value)
        {
            graph[index].Add(value);
        }
    }
}
