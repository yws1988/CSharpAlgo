namespace Graph.Base.Helper
{
    using System.Collections.Generic;
    using System.Linq;

    public class GraphListHelper
    {
        static List<int>[] GetTransposeGraph(List<int>[] graph)
        {
            int v = graph.Length;
            var reversGraph = Enumerable.Range(0, v).Select(s => new List<int>()).ToArray();

            for (int i = 0; i < v; i++)
            {
                foreach (int des in graph[i])
                {
                    reversGraph[des].Add(i);
                }
            }

            return reversGraph;
        }
    }
}
