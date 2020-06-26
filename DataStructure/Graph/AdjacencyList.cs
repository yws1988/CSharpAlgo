namespace CSharpAlgo.DataStructure.Graph
{
    using System.Collections.Generic;

    public class AdjacencyList<T>
    {
        public int V { get; set; }
        public List<T>[] G { get; set; }

        public AdjacencyList(int v)
        {
            V = v;
            G = new List<T>[V];

            for (var i = 0; i < G.Length; i++)
            {
                G[i]=new List<T>();
            }
        }

        public List<T> this[int index]
        {
            get
            {
                return G[index];
            }
            set
            {
                G[index] = value;
            }
        }
    }
}
