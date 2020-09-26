using CSharpAlgo.DataStructure.Heap;
using System;

/// <summary>
/// https://www.geeksforgeeks.org/job-assignment-problem-using-branch-and-bound/
/// </summary>
namespace CSharpAlgo.Excercise.Excercises.BranchAndBounds
{
    public class NodeJob:IComparable<NodeJob>
    {
        public double C { get; set; }
        public double Bound { get; set; }
        public int Worker { get; set; }
        public int Job { get; set; }
        public bool[] available { get; set; }
        public NodeJob P { get; set; }

        public NodeJob(double c, int worker)
        {
            C = c;
            Worker = worker;
        }

        public NodeJob Clone()
        {
            var node = (NodeJob)this.MemberwiseClone();
            node.available = new bool[this.available.Length];
            this.available.CopyTo(node.available, 0);
            node.Worker = this.Worker + 1;
            node.P = null;

            return node;
        }

        public int CompareTo(NodeJob other)
        {
            double result = this.Bound - other.Bound;
            if (result > 0) return 1;
            else if (result == 0) return 0;
            else return -1;
        }
    }

    public class JobAssignment
    {
        public static int N;
        public static double[][] G;

        public static void Start(double[][] jobs)
        {
            N = jobs.GetLength(0);
            G = jobs;

            NodeJob root = new NodeJob(0, -1);
            bool[] avs = new bool[N];
            for (int i = 0; i < N; i++)
            {
                avs[i] = true;
            }
            root.available = avs;
            root.P = null;

            PriorityQueue<NodeJob> queue = new PriorityQueue<NodeJob>();
            queue.Enqueue(root);
            while (queue.Count() > 0)
            {
                var min = queue.Dequeue();
                if (min.Worker == N - 1)
                {
                    Print(min);
                    return;
                }

                for (int i = 0; i < N; i++)
                {
                    if (min.available[i])
                    {
                        var child = min.Clone();
                        child.P = min;
                        child.available[i] = false;
                        child.Job = i;
                        child.C = min.C + G[child.Worker][i];
                        child.Bound = GetBound(child);
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public static void Print(NodeJob node)
        {
            Console.WriteLine(node.C);
            while (node.P != null)
            {
                Console.WriteLine(node.Worker+" : "+node.Job);
                node = node.P;
            }
        }

        public static double GetBound(NodeJob n)
        {
            double b = n.C;
            for (int i = n.Worker+1; i < N; i++)
            {
                double min = double.MaxValue;
                for (int j = 0; j < N; j++)
                {
                    if (n.available[j] && G[i][j]<min)
                    {
                        min = G[i][j];
                    }
                }
                b += min;
            }

            return b;
        }
    }
}
