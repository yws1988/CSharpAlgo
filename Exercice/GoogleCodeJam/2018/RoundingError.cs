using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class RoundingError
    {
        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\RoundingError.txt");
#endif
            int t = Convert.ToInt32(input.ReadLine());

            int[][] Ns = new int[t][];
            int[][] numss = new int[t][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                numss[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int i = 0; i < t; i++)
            {
                int N = Ns[i][0];
                int L = Ns[i][1];
                int[] nums = numss[i];
                List<double> higherScores = new List<double>();
                PriorityQueue<double> lowerScores = new PriorityQueue<double>((a, b)=> { return Math.Sign((b - Math.Floor(b)) - (a - Math.Floor(a))); });
                int left = N;
                double result = 0;
                double p = 100.0 / N;

                for (int m = 0; m < nums.Length; m++)
                {
                    left -= nums[m];
                    double r = nums[m] * p;
                    
                    if (IsHigherScore(r))
                    {
                        higherScores.Add(r);
                    }
                    else
                    {
                        lowerScores.Enqueue(r);
                    } 
                }

                while (left>0)
                {
                    if (lowerScores.Count() > 0)
                    {
                        double v = lowerScores.Dequeue();
                        v += p;
                        if (IsHigherScore(v))
                        {
                            higherScores.Add(v);
                        }
                        else
                        {
                            lowerScores.Enqueue(v);
                        }
                    }
                    else
                    {
                        if (IsHigherScore(p))
                        {
                            higherScores.Add(p);
                        }
                        else
                        {
                            lowerScores.Enqueue(p);
                        }
                    }
                    left--;
                }

                foreach (var r in higherScores)
                {
                    result += Math.Round(r, MidpointRounding.AwayFromZero);
                }

                foreach (var r in lowerScores.Data())
                {
                    result += Math.Round(r, MidpointRounding.AwayFromZero);
                }

                Output(i + 1, (int)result);
            }

            Console.Read();
           
        }

        public static bool IsHigherScore(double num) {
            return num-Math.Floor(num)>=0.5;
        }


        public static void Output(int caseNum, int result)
        {
            input.Write("Case #" + caseNum + ": "+result);
 
            input.WriteLine();
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

            public IReadOnlyCollection<T> Data(){
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
