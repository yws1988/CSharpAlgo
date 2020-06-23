using System.Collections.Generic;

namespace Graph.ShortestPath
{
    using System;

    public class Program
    {
        public const int INF = int.MaxValue;

        static void Main(string[] args)
        {

            //Shortest path with Djkast
            //Graph Djkast
            //int[,] graph = new int[,]{
            //    {0, 4, 0, 0, 0, 0, 0, 8, 0},
            //    {4, 0, 8, 0, 0, 0, 0, 11, 0},
            //    {0, 8, 0, 7, 0, 4, 0, 0, 2},
            //    {0, 0, 7, 0, 9, 14, 0, 0, 0},
            //    {0, 0, 0, 9, 0, 10, 0, 0, 0},
            //    {0, 0, 4, 14, 10, 0, 2, 0, 0},
            //    {0, 0, 0, 0, 0, 2, 0, 1, 6},
            //    {8, 11, 0, 0, 0, 0, 1, 0, 7},
            //    {0, 0, 2, 0, 0, 0, 6, 7, 0}
            //};
            //DijsktraShortestPath t = new DijsktraShortestPath(graph);
            //t.CalculateShortestPath(0);

            //Console.WriteLine("---------------------------------");
            //Console.WriteLine(WarshallShortestPath.GetShortestPath(0, 8, graph));

            // BellmanFord algorithm
            //int[,] graph =  {
            //                 {0, -1, 4, 0, 0},
            //                 {0, 0, 3, 2, 2},
            //                 {0, 0, 0, 0, 0},
            //                 {0, 1, 5, 0, 0},
            //                 {0, 0, 0, -3, 0}
            //                };
            //BellmanFordShortestPath be = new BellmanFordShortestPath(graph);
            //be.CalculateShortestPath(0);

            //Console.WriteLine("---------------------------------");
            /* Let us create the following graph 
              (0)--(1)--(2) 
               |   / \   | 
               |  /   \  | 
               | /     \ | 
              (3)-------(4)    */
            //int[,] graph =  {
            //                 {0, 1, 0, 1, 0}, 
            //                 {1, 0, 1, 1, 1}, 
            //                 {0, 1, 0, 0, 1}, 
            //                 {1, 1, 0, 0, 1}, 
            //                 {0, 1, 1, 1, 0}, 
            //                };
            //HamiltonianPath.GetPath(graph);
            //HamiltonianPath.GetCircle(graph);
            //int[,] graph =  {
            //                 {0, 10, 15, 20},
            //                 {10, 0, 35, 25},
            //                 {15, 35, 0, 30},
            //                 {20, 25, 30, 0}
            //                };
            //SalesmanTravelling.GetShortestDp(graph);

            //Multi Stage Graph
            //const int INF = int.MaxValue;
            //int[,] graph = new int[,]
            //  {{INF, 1, 2, 5, INF, INF, INF, INF},
            //   {INF, INF, INF, INF, 4, 11, INF, INF},
            //   {INF, INF, INF, INF, 9, 5, 16, INF},
            //   {INF, INF, INF, INF, INF, INF, 2, INF},
            //   {INF, INF, INF, INF, INF, INF, INF, 18},
            //   {INF, INF, INF, INF, INF, INF, INF, 13},
            //   {INF, INF, INF, INF, INF, INF, INF, 2}};

            //MultiStageShortestPath mssp = new MultiStageShortestPath(graph);
            //mssp.CalculateShortestPath(0, 7);

            // Karp’s minimum mean (or average) weight cycle 

            //int[,] graph =  {
            //                 {INF, 1, 10, INF},
            //                 {INF, INF, 3, INF},
            //                 {INF, INF, INF, 2},
            //                 {8, 0, INF, INF}
            //                };
            //MinimumMeanWeightCycle.PrintShortestAverageWeightCycle(graph);

            //List<(int, int, int)> g = new List<(int, int, int)>();
            //g.Add((0, 1, 4));
            //g.Add((0, 7, 8));
            //g.Add((1, 2, 8));
            //g.Add((1, 7, 11));
            //g.Add((2, 3, 7));
            //g.Add((2, 8, 1));
            //g.Add((2, 5, 4));
            //g.Add((3, 4, 9));
            //g.Add((3, 5, 14));
            //g.Add((4, 5, 10));
            //g.Add((5, 6, 2));
            //g.Add((6, 7, 1));
            //g.Add((6, 8, 6));
            //g.Add((7, 8, 7));

            //MinimumWeightCycle.PrintShortestWeightCycle(GraphHelper<int>.ConvertListToGraphMatrix(g, 9));

            //int[,] graph =
            //{
            //    { 31, 100, 65, 12, 18 },
            //    { 10, 13, 47, 157, 6 },
            //    { 100, 113, 174, 11, 33 },
            //    { 88, 124, 41, 20, 140 },
            //    { 99, 32, 111, 41, 20 }
            //};

            //MinimumGridAllDirectionCostPath.PrintShortestPath(graph);

            Console.Read();
        }
    }
}
