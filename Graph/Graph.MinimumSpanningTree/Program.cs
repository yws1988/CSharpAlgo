using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //MinimumSpanningTree.Set(5);
            //MinimumSpanningTree.AddEdge(0, 1, 1);
            //MinimumSpanningTree.AddEdge(0, 2, 7);
            //MinimumSpanningTree.AddEdge(1, 2, 5);
            //MinimumSpanningTree.AddEdge(1, 3, 4);
            //MinimumSpanningTree.AddEdge(1, 4, 3);
            //MinimumSpanningTree.AddEdge(2, 4, 6);
            //MinimumSpanningTree.AddEdge(3, 4, 2);
            //Console.WriteLine(MinimumSpanningTree.GetMinimumSpanningTree());*

            /* Let us create the following graph 
              2 3 
              (0)--(1)--(2) 
              | / \ | 
              6| 8/ \5 |7 
              | / \ | 
              (3)-------(4) 
                  9 
            */
            int[,] graph = new int[,] {{0, 2, 0, 6, 0},
                                       {2, 0, 3, 8, 5},
                                       {0, 3, 0, 0, 7},
                                       {6, 8, 0, 0, 9},
                                       {0, 5, 7, 9, 0}};

            Console.WriteLine(MinimumSpanningTreeMatrix.GetMinimumSpanningTree(graph));

            Console.ReadLine();
        }
    }
}
