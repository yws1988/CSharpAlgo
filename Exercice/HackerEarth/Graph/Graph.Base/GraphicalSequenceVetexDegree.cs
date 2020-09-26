using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace DynamiqueProgramming
{
    public class GraphicalSequenceVetexDegree
    {
        public static int n;
        public static int[] ns;
        static int sum;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\GraphicalSequenceVetexDegree.txt");
#endif
            n = int.Parse(input.ReadLine());
            ns = new int[n+1];

            for (int i = 0; i <= n; i++)
            {
                ns[i]= int.Parse(input.ReadLine());
            }

            sum = ns.Sum();
            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            var res = new List<int>();

            for (int i = 0; i <= n; i++)
            {
                if (IsGraph(i))
                {
                    res.Add(i);
                }
            }

            Console.WriteLine(res.Count());
            foreach (var item in res)
            {
                Console.WriteLine(item+1);
            }
        }

        static bool IsGraph(int idx)
        {
            if ((sum - ns[idx]) % 2 == 1) return false;

            PriorityQueue<int> queue = new PriorityQueue<int>((s, t)=>t-s);
            for (int k = 0; k <= n; k++)
            {
                if (k != idx) queue.Enqueue(ns[k]);
            }

            while (queue.Count() > 0)
            {
                int nn = queue.Dequeue();
                if (nn == 0) return true;
                if (nn > queue.Count()) return false;

                var nList = new List<int>();
                for (int i = 0; i < nn; i++)
                {
                    int tn = queue.Dequeue();
                    tn--;
                    if (tn < 0) return false;
                    if (tn > 0) nList.Add(tn);
                }

                foreach (var item in nList)
                {
                    queue.Enqueue(item);
                }
            }

            return true;
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
