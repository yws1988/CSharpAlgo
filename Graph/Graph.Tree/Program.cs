//namespace graph.Tree
//{
//    using System;

//    public class Program
//    {
//        static void Main()
//        {
//            // NAryTreeDiameter
//            AdjacencyList tree = new AdjacencyList(12);
//            tree.AddEdge(0, 1);
//            tree.AddEdge(0, 2);
//            tree.AddEdge(1, 3);
//            tree.AddEdge(1, 4);
//            tree.AddEdge(3, 8);
//            tree.AddEdge(4, 5);
//            tree.AddEdge(8, 9);
//            tree.AddEdge(8, 10);
//            tree.AddEdge(5, 6);
//            tree.AddEdge(5, 7);
//            tree.AddEdge(6, 11);

//            Console.WriteLine(NAryTreeDiameter.GetNAryTreeDiameter(tree.G));
//            Console.WriteLine(NAryTreeDiameter.GetNAryTreeDiameter(tree.G));
//            NAryTreeDiameterWithBFS.PrintNAryTreeDiameter(tree.G);

//            Console.Read();
//        }
//    }
//}
