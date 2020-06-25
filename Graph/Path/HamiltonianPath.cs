namespace Graph.Path
{
    using System.Collections.Generic;

    public class HamiltonianPath
    {
        public static List<int> GetHamiltonianPath(List<int>[] graph)
        {
            int v = graph.Length;

            bool found = false;
            var childs = new int[v];
            int src = -1;

            for (int i = 0; i < v; i++)
            {
                var vs = new bool[v];
                
                for (int h = 0; h < v; h++)
                {
                    childs[h] = -1;
                }

                if (DfsPathUntil(graph, v, vs, i, 1, childs))
                {
                    found = true;
                    src = i;
                    break;
                }
            }

            if (found)
            {
                var res = new List<int>();
                res.Add(src);
                while (childs[src] != -1)
                {
                    src = childs[src];
                    res.Add(src);
                }

                return res;
            }
            else
            {
                return null;
            }
        }

        public static List<int> GetHamiltonianCircle(List<int>[] graph)
        {
            int v = graph.Length;
            var childs = new int[v];
            var vs = new bool[v];
            int src = 0;

            for (int h = 0; h < v; h++)
            {
                childs[h] = -1;
            }

            if (DfsCircleUntil(graph, v, vs, src, 1, childs))
            {
                var res = new List<int>();
                res.Add(src);
                while (childs[src] != -1)
                {
                    src = childs[src];
                    res.Add(src);
                }

                return res;
            }
            else
            {
                return null;
            }
        }

        static bool DfsPathUntil(List<int>[] graph, int v, bool[] vs, int src, int level, int[] childs)
        {
            if (level == v) return true;

            vs[src] = true;

            foreach (var c in graph[src])
            {
                if (!vs[c])
                {
                    childs[src] = c;
                    if (DfsPathUntil(graph, v, vs, c, level + 1, childs))
                    {
                        return true;
                    }

                    childs[src] = -1;
                }
            }

            return vs[src] = false;
        }

        static bool DfsCircleUntil(List<int>[] graph, int v, bool[] vs, int src, int level, int[] childs)
        {
            if (level == v && graph[src].Contains(0)) return true;

            vs[src] = true;

            foreach (var c in graph[src])
            {
                if (!vs[c])
                {
                    childs[src] = c;
                    if (DfsPathUntil(graph, v, vs, c, level + 1, childs))
                    {
                        return true;
                    }

                    childs[src] = -1;
                }
            }

            return vs[src] = false;
        }
    }
}
