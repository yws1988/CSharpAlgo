namespace Graph.Connectivity
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Strongly Connected Componenets -- Kosaraju’s algorithm
            //Graph 1.0.2
            //AdjacencyList adjacencyList = new AdjacencyList(7, true);
            //adjacencyList.AddEdge(0, 1);
            //adjacencyList.AddEdge(1, 2);
            //adjacencyList.AddEdge(2, 0);
            //adjacencyList.AddEdge(2, 3);
            //adjacencyList.AddEdge(2, 6);
            //adjacencyList.AddEdge(3, 4);
            //adjacencyList.AddEdge(4, 5);
            //adjacencyList.AddEdge(5, 3);
            //StronglyConnectedComponentList scc = new StronglyConnectedComponentList(adjacencyList);
            //scc.PrintSCC();

            //Strongly Connected Graph or not
            //int[,] graph =
            //{
            //    { 0, 1, 0, 0, 0 },
            //    { 0, 0, 1, 0, 0 },
            //    { 0, 0, 0, 1, 1 },
            //    { 1, 0, 0, 0, 0 },
            //    { 0, 0, 1, 0, 0 }
            //};

            //IsStronglyConnectedMatrix isScc = new IsStronglyConnectedMatrix(graph);
            //Console.WriteLine(isScc.IsSC());

            // Articulation point Test
            //int[,] graph = new int[6, 6]
            //              {{0, 1, 0, 0, 0, 1},
            //               {1, 0, 1, 1, 0, 0},
            //               {0, 1, 0, 1, 1, 0},
            //               {0, 1, 1, 0, 1, 0},
            //               {0, 0, 1, 1, 0, 0},
            //               {1, 0, 0, 0, 0, 0}};
            //ArticulationPoints.PrintAP(graph);

            //int[,] graph = new int[4, 4]
            //              {
            //                  {0, 1, 0, 0},
            //                  {1, 0, 1, 0},
            //                  {0, 1, 0, 1},
            //                  {0, 0, 1, 0},
            //              };
            //ArticulationPoints.PrintAP(graph);

            //List<(int, int)> list = new List<(int, int)>();
            //list.Add((0, 1));
            //list.Add((1, 2));
            //list.Add((1, 3));
            //list.Add((2, 3));
            //list.Add((2, 4));
            //list.Add((3, 4));
            //list.Add((1, 5));
            //list.Add((0, 6));
            //list.Add((5, 6));
            //list.Add((5, 7));
            //list.Add((5, 8));
            //list.Add((7, 8));
            //list.Add((8, 9));
            //list.Add((10, 11));
            //BiConnected.PrintBiconnectedComponents(GraphHelper<int>.ConvertListToGraphMatrix(list, 12));

            // Print all the briges in graph
            //List<(int, int)> list = new List<(int, int)>();
            //list.Add((0, 1));
            //list.Add((1, 2));
            //list.Add((2, 0));
            //list.Add((1, 3));
            //list.Add((1, 4));
            //list.Add((1, 6));
            //list.Add((3, 5));
            //list.Add((4, 5));
            //Briges.PrintBriges(GraphHelper<int>.ConvertListToGraphMatrix(list, 7));

            //Eulerian path or cycle

            //Testcase 1
            //List<(int, int)> list = new List<(int, int)>();
            //list.Add((1, 0));
            //list.Add((0, 2));
            //list.Add((2, 1));
            //list.Add((0, 3));
            //list.Add((3, 4));
            //list.Add((4, 0));

            //EulerianPathAndCircle.IsCircleOrPath(GraphHelper<int>.ConvertListToGraphMatrix(list, 5));

            //Testcase 2
            //int[,] graph ={
            //                { 0, 1, 0, 0, 1},
            //                { 1, 0, 1, 1, 1},
            //                { 0, 1, 0, 1, 0},
            //                { 0, 1, 1, 0, 1},
            //                { 1, 1, 0, 1, 0}
            //              };

            //EulerianPathAndCircle.IsCircleOrPath(graph);

            //Transitive Closure Matrix
            //int[,] graph = {{1, 1, 0, 1},
            //                {0, 1, 1, 0},
            //                {0, 0, 1, 1},
            //                {0, 0, 0, 1}};
            //TransitiveClosureGraph.PrintWarshallMethod(graph);
            //TransitiveClosureGraph.PrintDFSMethod(graph);

            //int[,] graph = {{1, 1, 0, 0, 0},
            //                {0, 1, 0, 0, 1},
            //                {1, 0, 0, 1, 1},
            //                {0, 0, 0, 0, 0},
            //                {1, 0, 1, 0, 1}};

            //NumConnectedGraphInMatrix.PrintConnectedGraphNum(graph);

            Console.Read();
        }
    }
}
