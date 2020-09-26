using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAlgo.Excercise.Excercises.BranchAndBounds
{
    /// <summary>
    /// Given two integer arrays val[0..n-1] and wt[0..n-1] that represent values and weights associated with n items
    /// respectively. Find out the maximum value subset of val[] such that sum of the weights of this subset is smaller than or equal
    /// to Knapsack capacity cap.
    /// </summary>
    public class Knapsack
    {
        public static double GetMaxValue((double, double)[] arr, double capacity)
        {
            var orderedNodesByAverageValue = new Node[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                orderedNodesByAverageValue[i] = new Node(arr[i].Item1, arr[i].Item2, arr[i].Item2 / arr[i].Item1);
            }

            orderedNodesByAverageValue = orderedNodesByAverageValue.OrderByDescending(s => s.Average).ToArray();

            Queue<CumulativeNode> queue = new Queue<CumulativeNode>();

            CumulativeNode u, v;
            u = new CumulativeNode(0, 0, -1);
            queue.Enqueue(u);
            double maxP = GetInitialPossibleMaxValue(orderedNodesByAverageValue, capacity);
            int n = orderedNodesByAverageValue.Length;

            while (queue.Count > 0)
            {
                u = queue.Dequeue();
                if (u.Level == n - 1) continue;

                int cLevel = u.Level + 1;

                v = new CumulativeNode(u.CumulativeWeight + orderedNodesByAverageValue[cLevel].Weight, u.CumulativeValue + orderedNodesByAverageValue[cLevel].Value, cLevel);
                if (v.CumulativeWeight <= capacity && v.CumulativeValue > maxP)
                {
                    maxP = v.CumulativeValue;
                }

                v.Bound = GetBound(orderedNodesByAverageValue, v, capacity, n);

                if (v.Bound > maxP)
                {
                    queue.Enqueue(v);
                }

                v = new CumulativeNode(u.CumulativeWeight, u.CumulativeValue, cLevel);
                v.Bound = GetBound(orderedNodesByAverageValue, v, capacity, n);

                if (v.Bound > maxP)
                {
                    queue.Enqueue(v);
                }
            }

            return maxP;
        }

        static double GetBound(Node[] orderedNodesByAverageValue, CumulativeNode cumulativeNode, double capacity, int n)
        {
            double w = cumulativeNode.CumulativeWeight;
            if (w > capacity) return 0;

            double bound = cumulativeNode.CumulativeValue;
            int l = cumulativeNode.Level + 1;

            while (l < n && w + orderedNodesByAverageValue[l].Weight <= capacity)
            {
                w += orderedNodesByAverageValue[l].Weight;
                bound += orderedNodesByAverageValue[l].Value;
                l++;
            }

            if (l < n)
            {
                bound += orderedNodesByAverageValue[l].Average * (capacity - w);
            }

            return bound;
        }

        static double GetInitialPossibleMaxValue(Node[] orderedNodesByAverageValue, double capacity)
        {
            double weight = 0;
            double value = 0;

            for (int i = 0; i < orderedNodesByAverageValue.Length; i++)
            {
                weight += orderedNodesByAverageValue[i].Weight;

                if (weight <= capacity)
                {
                    value += orderedNodesByAverageValue[i].Value;
                }
                else
                {
                    break;
                }
            }

            return value;
        }

        class Node
        {
            public double Weight { get; set; }
            public double Value { get; set; }
            public double Average { get; set; }

            public Node(double weight, double value, double average)
            {
                Weight = weight;
                Value = value;
                Average = average;
            }
        }

        class CumulativeNode
        {
            public double CumulativeWeight { get; set; }
            public double CumulativeValue { get; set; }
            public double Bound { get; set; }
            public int Level { get; set; }

            public CumulativeNode(double cumulativeWeight, double cumulativeValue, int level)
            {
                CumulativeWeight = cumulativeWeight;
                CumulativeValue = cumulativeValue;
                Level = level;
            }
        }
    }
}

