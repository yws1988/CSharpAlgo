namespace Graph.Cycle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MagicalIndices
    {
        static int V;
        static bool[] Vs;
        static int[] Arr;

        public static void Count(int[] arr)
        {
            V = arr.Length;
            Vs = new bool[V];
            Arr = arr;

            for (int i = 0; i < V; i++)
            {
                if (!Vs[i])
                {
                    int next = (i + 1 + arr[i]) % V;
                    CheckCycle(next, i);
                }
            }

            Console.WriteLine(Vs.Where(s => s).Count());
        }

        static bool CheckCycle(int next, int src)
        {
            Vs[next] = true;
            if (next == src)
            {
                return true;
            }

            int nNext = (next + 1 + Arr[next]) % V;
            if (!Vs[nNext] && CheckCycle(nNext, src))
            {
                return true;
            }

            Vs[next] = false;
            return false;
        }

    }
}
