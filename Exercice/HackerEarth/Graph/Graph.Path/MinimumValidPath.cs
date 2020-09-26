namespace HackerEarth.Graph.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using input = System.Console;

    public class MinimumValidPath
    {
        public static int m;
        public static int n;
        public static int k;
        public static long[,] ws;
        public static List<Pair>[] es;
        public static int[] sp;
        public static int x;
        public static int y;

        public static void MainF()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\MinimumValidPath.txt");
#endif
            var temp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = temp[0];
            m = temp[1];
            es = Enumerable.Range(0, n+1).Select(s => new List<Pair>()).ToArray();
            for (int i = 1; i <= m; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                es[tt[0]].Add(new Pair(tt[1], tt[2]));
            }

            k = int.Parse(input.ReadLine());
            sp = new int[n+1];
            temp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < temp.Length; i++)
            {
                sp[temp[i]] = 1;
            }

            temp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            x = temp[0];
            y = temp[1];
            ws = new long[n + 1, 2];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    ws[i, j] = long.MaxValue;
                }
            }

            ws[x, sp[x]] = 0;

            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            PriorityQueue<Node> qu = new PriorityQueue<Node>();
            HashSet<ValueTuple<int, int, int>> set = new HashSet<ValueTuple<int, int, int>>();
            set.Add(new ValueTuple<int, int, int>(1, 2, 3));

            qu.Enqueue(new Node(x, 0, 0, sp[x]));

            while (qu.Count() > 0)
            {
                var node = qu.Dequeue();
                int s = node.src;
                int csp = node.sp;
                if (s == y && csp==1)
                {
                    Console.WriteLine(node.tw);
                    return;
                }

                int cw = node.cw;
                set.Add(new ValueTuple<int, int, int>(s, cw, csp));

                for (int i = 0; i < es[s].Count; i++)
                {
                    var des = es[s][i].d;
                    var nw = es[s][i].w;

                    if (cw > 0 && (cw * 0.5 > nw || cw * 2 < nw)) continue;
                    if (csp == 1 && sp[des] == 1) continue;

                    if (csp == 1 || sp[des] == 1)
                    {
                        if (!set.Contains(new ValueTuple<int,int,int>(des, nw, 1)))
                        {
                            qu.Enqueue(new Node(des, nw, node.tw + nw, 1));
                        }
                    }
                    else
                    {
                        if (!set.Contains(new ValueTuple<int, int, int>(des, nw, 0)))
                        {
                            qu.Enqueue(new Node(des, nw, node.tw + nw, 0));
                        }
                    }
                }
            }

            Console.WriteLine(-1);
        }
    }

    public struct Pair
    {
        public int d { get; set; }
        public int w { get; set; }

        public Pair(int i, int j)
        {
            d = i;
            w = j;
        }
    }

    struct Node:IComparable<Node>
    {
        public int src { get; set; }
        public int cw { get; set; }
        public long tw { get; set; }
        public int sp { get; set; }

        public Node(int i, int j, long h, int m)
        {
            src = i;
            cw = j;
            tw = h;
            sp = m;
        }

        public int CompareTo(Node other)
        {
            return this.tw.CompareTo(other.tw);
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
