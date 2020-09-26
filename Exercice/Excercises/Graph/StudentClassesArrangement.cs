namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using input = System.Console;


    public class StudentClassesArrangement
    {
        static int n;
        static int[][] ps;

        public static void Start(string[] args)
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"IOFiles\StudentClassesArrangementInput.txt");
#endif
            n = int.Parse(input.ReadLine());
            ps = new int[n * 2][];
            for (int i = 0; i < n; i++)
            {
                var temp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                ps[i * 2] = new int[] { temp[0], i * 2 };
                ps[i * 2 + 1] = new int[] { temp[1], i * 2 + 1 };
            }

            ps = ps.OrderBy(s => s[0]).ToArray();

            List<int>[] g = new List<int>[n * 2];

            for (int i = 0; i < 2 * n; ++i)
            {
                g[i] = new List<int>();
            }

            int b = 0;
            for (int i = 1; i < 2 * n; ++i)
            {
                while (ps[b][0] + 60 < ps[i][0])
                {
                    ++b;
                }

                for (int j = b; j < i; ++j)
                {
                    g[ps[j][1]].Add(ps[i][1] % 2 == 1 ? ps[i][1] - 1 : ps[i][1] + 1);
                    g[ps[i][1]].Add(ps[j][1] % 2 == 1 ? ps[j][1] - 1 : ps[j][1] + 1);
                }
            }

            int[] connectedComponents = Scc(g);
            int len = connectedComponents.Count();

            List<int>[] connectedComponentById = Enumerable.Range(0, len).Select(s=>new List<int>()).ToArray();
            for (int i = 0; i < n; ++i)
            {
                if (connectedComponents[2 * i] == connectedComponents[2 * i + 1])
                {
                    Console.WriteLine("KO");
                    return;
                }
                connectedComponentById[connectedComponents[2 * i]].Add(2 * i);
                connectedComponentById[connectedComponents[2 * i + 1]].Add(2 * i + 1);
            }

            List<int>[] graphForTopologicalSorting = Enumerable.Range(0, len).Select(s => new List<int>()).ToArray();
            for (int i = 0; i < len; ++i)
            {
                graphForTopologicalSorting[i].Add(connectedComponents[i]);
                foreach (var connectedComponentElement in connectedComponentById[i])
                    foreach (var c in g[connectedComponentElement])
                        graphForTopologicalSorting[i].Add(connectedComponents[c]);
            }


            bool[] vs = Enumerable.Repeat(false, len).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                if (!vs[i])
                {
                    Dfs(i, graphForTopologicalSorting, vs, stack);
                }
            }

            int[] cv = Enumerable.Repeat(0, n).ToArray();

            foreach (int i in stack.Reverse())
            {
                if (cv[i / 2] != 0) continue;

                cv[i / 2] = i % 2 == 0 ? 1 : 2;
                foreach (int m in connectedComponentById[i])
                {
                    cv[m / 2] = m % 2 == 0 ? 1 : 2;
                }
            }

            foreach (var item in cv)
            {
                Console.WriteLine(item);
            }
        }

        static int[] Scc(List<int>[] g)
        {
            int len = g.Length;

            bool[] vs = new bool[len];

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                if (!vs[i])
                {
                    Dfs(i, g, vs, stack);
                }
            }

            List<int>[] reverseG = new List<int>[len];
            for (int i = 0; i < len; i++)
            {
                reverseG[i] = new List<int>();
            }

            for (int i = 0; i < len; i++)
            {
                foreach (var c in g[i])
                {
                    reverseG[c].Add(i);
                }
            }

            int[] cc = Enumerable.Range(0, len).Select(s => -1).ToArray();

            while (stack.Count > 0)
            {
                int i = stack.Pop();
                if (cc[i] == -1)
                {
                    Dfs(i, i, reverseG, cc);
                }
            }

            return cc;
        }


        static void Dfs(int s, List<int>[] g, bool[] vs, Stack<int> stack)
        {
            vs[s] = true;
            foreach (var c in g[s])
            {
                if (!vs[c])
                {
                    Dfs(c, g, vs, stack);
                }
            }
            stack.Push(s);
        }

        static void Dfs(int s, int root, List<int>[] g, int[] cc)
        {
            cc[s] = root;
            foreach (var c in g[s])
            {
                if (cc[c] == -1)
                {
                    Dfs(c, root, g, cc);
                }
            }
        }
    }
}
