using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace DynamiqueProgramming
{
    public class BalckAndWhite
    {
        public static int m;
        public static int n;
        public static List<Node>[] g;
        public static int[] c;
        const int max = 10000001;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\BalckAndWhite.txt");
#endif
            var tp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = tp[0];
            m = tp[1];
            g = Enumerable.Range(1, n+1).Select(s => new List<Node>()).ToArray();

            for (int i = 0; i < m; i++)
            {
                tp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                g[tp[0]].Add(new Node(tp[1], tp[2], 0));
            }

            c = input.ReadLine().Split(' ').Select(s=>int.Parse(s)==0 ? -1:1).ToArray();
            
            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            PriorityQueue<Node> nodes = new PriorityQueue<Node>();
            nodes.Enqueue(new Node(1, 0, c[0]));
            int shift = 1000;
            bool[,] vs = new bool[2001, n + 1];
            vs[shift+c[0], 1] = true;

            while (nodes.Count() > 0)
            {
                var nn = nodes.Dequeue();
                int pd = nn.d;
                int pw = nn.w;
                int pdiff = nn.diff;

                vs[pdiff+shift, pd] = true;

                if (pd == n && Math.Abs(pdiff) <= 1)
                {
                    Console.WriteLine(pw);
                    return;
                }

                foreach (var item in g[pd])
                {
                    int cd = item.d;
                    int cw = item.w;
                    int cdiff = pdiff + c[cd - 1];
                    if (cdiff > 1000 || cdiff < -1000) continue;
                    if (!vs[cdiff+shift, cd])
                    {
                        nodes.Enqueue(new Node(cd, cw+pw, cdiff));
                    }
                }
            }

            Console.WriteLine(-1);
        }

        public class Node:IComparable<Node>
        {
            public int d { get; set; }
            public int w { get; set; }
            public int diff { get; set; }

            public Node(int td, int tw, int tdiff)
            {
                d = td;
                w = tw;
                diff = tdiff;
            }

            public int CompareTo(Node other)
            {
                return this.w.CompareTo(other.w);
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
    }
}
