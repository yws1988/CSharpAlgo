//using System;
//using System.Collections.Generic;
//using graph.Base;

//namespace Algorithmne
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            //Adjacency Matrix
//            //AdjacencyMatrix.Generate();
//            //AdjacencyMatrix.Print();

//            //Adjacency List
//            //BFS Display
//            //AdjacencyList adjacencyList = new AdjacencyList(5);
//            //adjacencyList.AddEdge(0, 1);
//            //adjacencyList.AddEdge(0, 4);
//            //adjacencyList.AddEdge(1, 2);
//            //adjacencyList.AddEdge(1, 3);
//            //adjacencyList.AddEdge(1, 4);
//            //adjacencyList.AddEdge(2, 3);
//            //adjacencyList.AddEdge(3, 4);
            
//            ////adjacencyList.Print();
//            ////adjacencyList.DisplayGraphBFS();
//            //Console.Write("Please enter the start point for DFS : ");
//            //int start = int.Parse(Console.ReadLine());
//            //adjacencyList.DisplayGraphDFS(start);

//            ////Longest Path
//            //Graph 1.0.1
//            //LongestPath adjacencyList = new LongestPath(6);
//            //adjacencyList.AddEdge(0, 1, 5);
//            //adjacencyList.AddEdge(0, 2, 3);
//            //adjacencyList.AddEdge(1, 3, 6);
//            //adjacencyList.AddEdge(1, 2, 2);
//            //adjacencyList.AddEdge(2, 4, 4);
//            //adjacencyList.AddEdge(2, 5, 2);
//            //adjacencyList.AddEdge(2, 3, 7);
//            //adjacencyList.AddEdge(3, 5, 1);
//            //adjacencyList.AddEdge(3, 4, -1);
//            //adjacencyList.AddEdge(4, 5, -2);

//            ////adjacencyList.CalculateLongestPathWithTopologicalOrder(1);
//            //adjacencyList.CalculateLongestPathWithRecursiveWay(1);

//            //Strongly Connected Componenets -- Kosaraju’s algorithm
//            //Graph 1.0.2
//            //AdjacencyList adjacencyList = new AdjacencyList(7, true);
//            //adjacencyList.AddEdge(0, 1);
//            //adjacencyList.AddEdge(1, 2);
//            //adjacencyList.AddEdge(2, 0);
//            //adjacencyList.AddEdge(2, 3);
//            //adjacencyList.AddEdge(2, 6);
//            //adjacencyList.AddEdge(3, 4);
//            //adjacencyList.AddEdge(4, 5);
//            //adjacencyList.AddEdge(5, 3);
//            //FindMotherVertex findMotherVertex= new FindMotherVertex(adjacencyList);
//            //findMotherVertex.Print();

//            //IDDF Searching
//            //Graph 1.0.0
//            //AdjacencyList adjacencyList = new AdjacencyList(8, true);
//            //adjacencyList.AddEdge(0, 1);
//            //adjacencyList.AddEdge(0, 2);
//            //adjacencyList.AddEdge(1, 3);
//            //adjacencyList.AddEdge(1, 4);
//            //adjacencyList.AddEdge(2, 5);
//            //adjacencyList.AddEdge(5, 6);
//            //adjacencyList.AddEdge(6, 7);
//            //adjacencyList.AddEdge(4, 3);
//            //adjacencyList.AddEdge(4, 6);
//            //IDDF iddf = new IDDF(adjacencyList);
//            ////iddf.DisplayPath(0, 4);
//            //int target = Convert.ToInt32(Console.ReadLine());
//            //if (iddf.Find(0, target, 3))
//            //{
//            //    Console.WriteLine("The value is found");
//            //}
//            //else
//            //{
//            //    Console.WriteLine("The value is not found");
//            //}

//            //Print KCore Graph
//            //Graph 1.0.3
//            //AdjacencyList adjacencyList = new AdjacencyList(9);
//            //adjacencyList.AddEdge(0, 1);
//            //adjacencyList.AddEdge(0, 2);
//            //adjacencyList.AddEdge(1, 2);
//            //adjacencyList.AddEdge(1, 5);
//            //adjacencyList.AddEdge(2, 3);
//            //adjacencyList.AddEdge(2, 4);
//            //adjacencyList.AddEdge(2, 5);
//            //adjacencyList.AddEdge(2, 6);
//            //adjacencyList.AddEdge(3, 4);
//            //adjacencyList.AddEdge(3, 6);
//            //adjacencyList.AddEdge(3, 7);
//            //adjacencyList.AddEdge(4, 6);
//            //adjacencyList.AddEdge(4, 7);
//            //adjacencyList.AddEdge(5, 6);
//            //adjacencyList.AddEdge(5, 8);
//            //adjacencyList.AddEdge(6, 7);
//            //adjacencyList.AddEdge(6, 8);

//            //KCore kcoreGraph = new KCore(adjacencyList);
//            //kcoreGraph.Print(3);

//            Console.Read();

//        }
//    }
//}
