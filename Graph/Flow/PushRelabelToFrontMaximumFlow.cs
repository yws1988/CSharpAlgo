namespace CSharpAlgo.Graph.Flow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PushRelabelToFrontMaximumFlow
    {
        static Vetex[] Vetexes;
        static int[,] ResidualGraph;
        static int V;
        static List<int> List = new List<int>();
        static int currentIdx = 0;

        public static int GetMaximunFlow(int[,] graph, int s, int d)
        {
            V = graph.GetLength(0);

            for (int i = 0; i < V; i++)
            {
                if(i!=s && i != d)
                {
                    List.Add(i);
                }
            }

            ResidualGraph = new int[V, V];
            Vetexes = Enumerable.Range(0, V).Select(s => new Vetex()).ToArray();

			for (int i = 0; i < V; i++)
			{
				for (int j = 0; j < V; j++)
				{
                    ResidualGraph[i,j] = graph[i, j];
                }
			}

            PreFlow(s);

            int idx = GetIndexOfOverflowVetexInList();
            while (idx != -1)
            {
                int u = List[idx];
                if (!Push(u))
                {
                    Relabel(u);
                    MoveRelabelVetexToFront(idx);
                }

                idx = GetIndexOfOverflowVetexInList();
            }

            return Vetexes[d].ExcessFlow;
        }

        static void PreFlow(int s)
        {
            Vetexes[s].H = V;

            for (int i = 0; i < V; i++)
            {
                if(ResidualGraph[s, i] > 0)
                {
                    int flow = ResidualGraph[s, i];
                    ResidualGraph[s, i] = 0;
                    Vetexes[i].ExcessFlow += flow;
                    ResidualGraph[i, s] += flow;
                }
            }
        }

        static bool Push(int i)
        {
            int excessFlow = Vetexes[i].ExcessFlow;

            for (int j = 0; j < V; j++)
            {
                if (ResidualGraph[i, j] > 0 && Vetexes[i].H > Vetexes[j].H)
                {
                    int flow = Math.Min(excessFlow, ResidualGraph[i, j]);
                    Vetexes[i].ExcessFlow -= flow;
                    Vetexes[j].ExcessFlow += flow;
                    ResidualGraph[i, j]-= flow;
                    ResidualGraph[j, i] += flow;
                    return true;
                }
            }

            return false;
        }

        static void Relabel(int i)
        {
            int minH = int.MaxValue;

            for (int j = 0; j < V; j++)
            {
                if(ResidualGraph[i, j] > 0)
                {
                    minH = Math.Min(minH, Vetexes[j].H);
                }
            }

            Vetexes[i].H = minH + 1;
        }

        static void MoveRelabelVetexToFront(int idx)
        {
            int u = List[idx];
            int temp = u;
            List[idx] = List[0];
            List[0] = temp;
            currentIdx = 0;
        }

        static int GetIndexOfOverflowVetexInList()
        {
            while (currentIdx < List.Count)
            {
                if (Vetexes[List[currentIdx]].ExcessFlow > 0)
                {
                    return currentIdx;
                }

                currentIdx++;
            }

            return -1;
        }
        
        struct Vetex
        {
            public int H { get; set; }
            public int ExcessFlow { get; set; }
        }
    }
}