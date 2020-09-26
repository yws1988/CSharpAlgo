using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class AlienRhyme
    {
        static int T;
        static string[] strs;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\AlienRhyme.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(input.ReadLine());
                strs = new string[n];
                for (int j = 0; j < n; j++)
                {
                    strs[j] = new string(input.ReadLine().Reverse().ToArray());
                }
                
                Solve(i+1, n);
            }
        }

        public static void Solve(int t, int n)
        {
            HashSet<string> sff = new HashSet<string>();
            PriorityQueue<node> pq = new PriorityQueue<node>();
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    int h = 0;
                    int len = Math.Min(strs[i].Length, strs[j].Length);
                    while (h < len)
                    {
                        if (strs[i][h] == strs[j][h]) h++;
                        else break;
                    }

                    if (h > 0)
                    {
                        pq.Enqueue(new node(i, j, strs[i].Substring(0, h)));
                    }
                }
            }

            bool[] vs = new bool[n];

            while (pq.Count() > 0)
            {
                var cn = pq.Dequeue();
                if (!vs[cn.i] && !vs[cn.j])
                {
                    string pfx = cn.str;
                    while(pfx.Length>0 && sff.Contains(pfx))
                    {
                        pfx = pfx.Substring(0, pfx.Length - 1);
                    }

                    if (pfx.Length > 0)
                    {
                        ans += 2;
                        vs[cn.i] = true;
                        vs[cn.j] = true;
                        sff.Add(pfx);
                    }
                }
            }

            Output(t, ans);
        }

        public static void Output(int caseNum, int result)
        {
            Console.WriteLine("Case #" + caseNum + ": " + result);
        }
    }

    class node : IComparable<node>
    {
        public int i;
        public int j;
        public string str;

        public node(int ii, int jj, string ss)
        {
            i = ii;
            j = jj;
            str = ss;
        }

        public int CompareTo(node other)
        {
            return Math.Sign(other.str.Length-this.str.Length);
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

        public IReadOnlyCollection<T> Data()
        {
            return this.data;
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
