using graph.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph.Other
{
    public class MColoring
    {
        public static AdjacencyMatrix G;
        public static int ColorNum;
        public static int[] Colors;

        public static void Solve(AdjacencyMatrix g, int m)
        {
            G = g;
            ColorNum = m;
            Colors = new int[G.N];
            bool isPossible = true;

            for (int i = 0; i < G.N; i++)
            {
                for (int j = 0; j < ColorNum; j++)
                {
                    Colors[i] = j+1;
                    if (IsSafe(i))
                    {
                        break;
                    }
                    if (j == ColorNum - 1)
                    {
                        isPossible = false;
                        goto End;
                    }
                }
            }

            End:
            if (isPossible)
            {
                for (int i = 0; i < G.N; i++)
                {
                    Console.Write(Colors[i]+" ");
                }
            }
            else
            {
                Console.WriteLine("Impossible");
            }
        }

        public static bool IsSafe(int v)
        {
            for (int i = 0; i < G.N; i++)
            {
                if (i == v) continue;
                if(G.Value[v, i]==1 && Colors[v] == Colors[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
