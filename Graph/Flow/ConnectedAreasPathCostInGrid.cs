/*
    Give a char matrix,  in the char grid it contains the following characters:
    '.' represents a crossable cell
    '#' represents a wall cell, is not crossable
    '?' an door cell
    's' source crossable cell
    'd' destination crossable cell
    How many doors do you have to close at least to cut all the passages connecting sources and destinations?

    Input char grid like this:
    .?.#.?.
    p#.#.#c
    .#.#.#.
    ##.?.##
    .#.#.#.
    p#.#.#c
    .?.#.?.

    You just have to close the door (?) in the center of the grid to separate the sources from
    the destinations, so the expected answer is 1.
 */

namespace CSharpAlgo.Graph.Flow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectedAreasPathCostInGrid
    {
        static int n;
        static int[] dx = { 1, 0, -1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        public static int GetMaxFlow(string[] graph)
        {
            n = graph.Length;
            var costs = BuildConnectedAreasCostMatrix(graph);
            if (costs == null)
            {
                return -1;
            }

            int numOfVetexes = costs.GetLength(0);

            return FordFulkersonMaximumFlow.GetMaximunFlow(costs, 0, numOfVetexes - 1);
        }

        public static int[,] BuildConnectedAreasCostMatrix(string[] graph, char symbolSource = 'p', char symbolDestination = 'c', char symbolCost = '?', char symbolWall = '#')
        {
            var vs = new bool[n, n];

            int counter = 0;
            int[,] areas = new int[n, n];
            int nTwinNodes = 0;
            int[,] twins = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i][j] == symbolCost)
                    {
                        twins[i, j] = ++nTwinNodes;
                        areas[i, j] = ++counter;
                        vs[i, j] = true;
                    }
                    else if (graph[i][j] == symbolWall)
                    {
                        vs[i, j] = true;
                    }
                    else
                    {
                        if (!vs[i, j])
                        {
                            ++counter;
                            BuildAreasWithDfs(graph, vs, areas, counter, i, j);
                        }
                    }
                }
            }

            int numOfVetexes = counter + nTwinNodes + 2;
            var costs = new int[numOfVetexes, numOfVetexes];

            var sources = new HashSet<int>();
            var destinations = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i][j] == 'p')
                    {
                        sources.Add(areas[i, j]);
                    }
                    else if (graph[i][j] == 'c')
                    {
                        destinations.Add(areas[i, j]);
                    }
                    else if (graph[i][j] == '?')
                    {
                        int sNode = areas[i, j];
                        int dNode = twins[i, j] == 0 ? sNode : twins[i, j] + counter;
                        costs[sNode, dNode] = 1;
                        for (int h = 0; h < 4; h++)
                        {
                            int tx = i + dx[h];
                            int ty = j + dy[h];

                            if (IsSafe(tx, ty) && areas[tx, ty] != 0)
                            {
                                int tsNode = areas[tx, ty];
                                int tdNode = twins[tx, ty] == 0 ? tsNode : twins[tx, ty] + counter;
                                costs[tdNode, sNode] = 1;
                                costs[dNode, tsNode] = 1;
                            }
                        }
                    }
                }
            }

            // Add the super source and destination
            foreach (var patient in sources)
            {
                costs[0, patient] = int.MaxValue;
            }

            foreach (var canard in destinations)
            {
                costs[canard, numOfVetexes - 1] = int.MaxValue;
            }

            if (sources.Intersect(destinations).Any())
            {
                Console.WriteLine("-1");
                return null;
            }

            return costs;
        }



        static void BuildAreasWithDfs(string[] graph, bool[,] vs, int[,] area, int counter, int x, int y)
        {
            vs[x, y] = true;
            area[x, y] = counter;

            for (int i = 0; i < 4; i++)
            {
                int tx = x + dx[i];
                int ty = y + dy[i];

                if (IsSafe(tx, ty) && !vs[tx, ty] && graph[tx][ty] != '?' && graph[tx][ty] != '#')
                {
                    BuildAreasWithDfs(graph, vs, area, counter, tx, ty);
                }
            }
        }

        static bool IsSafe(int tx, int ty)
        {
            return tx >= 0 && tx < n && ty >= 0 && ty < n;
        }
    }
}