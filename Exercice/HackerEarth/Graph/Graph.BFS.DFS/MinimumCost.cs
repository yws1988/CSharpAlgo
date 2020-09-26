using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MinimumCost
{
    public static int n,t;
    public static int[] ns;
    static List<Node>[] g;

    public void Solve()
    {
        PriorityQueue<Node> pq = new PriorityQueue<Node>();
        foreach (var item in g[0])
        {
            pq.Enqueue(item);
        }

        bool[] vs = new bool[n];
        while (pq.Count() > 0)
        {
            var p = pq.Dequeue();
            vs[p.d] = true;
            if (p.d == n - 1)
            {
                Console.WriteLine(p.sw);
                return;
            }

            foreach (var c in g[p.d])
            {
                if (!vs[c.d])
                {
                    pq.Enqueue(new Node(c.d, c.w, c.w + p.sw));
                }
            }
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\MinimumCost.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        t = ReadInt();

        for (int i = 0; i < t; i++)
        {
            n = ReadInt();
            ns = ReadIntArray();
            g = CreateListArray<Node>(n);

            g[0].Add(new Node(ns[0]-1, 0, 0));

            for (int j = 1; j < n; j++)
            {
                g[j].Add(new Node(j - 1, 1, 1));
                g[j-1].Add(new Node(j, 1, 1));
                g[j].Add(new Node(ns[j]-1, 0, 0));
            }

            new MinimumCost().Solve();
        }
       
        reader.Close();
    }

    public struct Node : IComparable<Node>
    {
        public int d;
        public int w;
        public int sw;

        public Node(int td, int tw, int tsw)
        {
            d = td;
            w = tw;
            sw = tsw;
        }

        public int CompareTo(Node other)
        {
            return this.sw.CompareTo(other.sw);
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;
        private Func<T, T, int> CompareExpression { get; set; }

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public PriorityQueue(Func<T, T, int> compareExpression)
        {
            this.data = new List<T>();
            this.CompareExpression = compareExpression;

        }

        public PriorityQueue(T[] array)
        {
            this.data = new List<T>();
            foreach (var item in array)
            {
                this.Enqueue(item);
            }
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1; // child index; start at end
            while (ci > 0)
            {
                int pi = (ci - 1) / 2; // parent index
                if (this.Compare(data[ci], data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            // assumes pq is not empty; up to calling code
            int li = data.Count - 1; // last index (before removal)
            T frontItem = data[0];   // fetch the front
            data[0] = data[li];
            data.RemoveAt(li);

            --li; // last index (after removal)
            int pi = 0; // parent index. start at front of pq
            while (true)
            {
                int ci = pi * 2 + 1; // left child index of parent
                if (ci > li) break;  // no children so done
                int rc = ci + 1;     // right child
                if (rc <= li && Compare(data[rc], data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                    ci = rc;
                if (Compare(data[pi], data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }

        public int Compare(T o1, T o2)
        {
            if (this.CompareExpression != null)
            {
                return this.CompareExpression(o1, o2);
            }
            else
            {
                return o1.CompareTo(o2);
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }

    } // PriorityQueue


    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    #endregion

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}