/*
 Given two graph contains the same edges, the vertexes of the first graph is labled by numbers, the vetexes
 of the second graph is labeled by strings, give the matching relations between the numbers and strings to
 make the graphs to be same.

 For example, first graph contains 14 vertexes with following edges:

 edges : {
            ( 0, 5), ( 0, 9), ( 0, 12),( 1, 10), ( 1, 2), ( 1, 7),
            ( 2, 3), ( 2, 6), ( 3, 6), ( 3, 11), ( 4, 12), ( 4, 6),
            ( 4, 13), ( 5, 8), ( 5, 10), ( 7, 8), ( 7, 9),
            ( 8, 11), ( 9, 13), ( 10, 11), ( 12, 13)
        };
   
  The second graph contains following edges:
    Earaindir Rithralas
    Hilad Fioldor
    Delanduil Rithralas
    Urarion Elrebrimir
    Elrebrimir Fioldor
    Eowul Fioldor
    Beladrieng Anaramir
    Urarion Eowul
    Earaindir Sanakil
    Delanduil Isilmalad
    Earylas Isilmalad
    Rithralas Sanakil
    Unithral Elrebrimir
    Earylas Eowul
    Beladrieng Hilad
    Isilmalad Sanakil
    Unithral Earylas
    Earaindir Anaramir
    Unithral Beladrieng
    Hilad Anaramir
    Delanduil Urarion

    Output:
    Returns the number and string matching relations
 */
namespace CSharpAlgo.Graph.Tranversal.DFS
{
    using System.Collections.Generic;
    using System.Linq;
    using Utils.Helper;

    public class IntegerToStringGraphMatching
    {
        /// <summary>
        /// Get the number to string matches array
        /// </summary>
        /// <param name="oldGraph">number index graph</param>
        /// <param name="newGraph">string index graph</param>
        /// <returns></returns>
        public static string[] GetMatches(HashSet<int>[] oldGraph, Dictionary<string, HashSet<string>> newGraph)
        {
           

            var availableNodes = new Queue<string>(newGraph.Keys);
            var match = new string[14];

            Dfs(0, match, availableNodes, oldGraph, newGraph);

            return match;
        }

        public static bool Dfs(int src, string[] match, Queue<string> availableNodes, HashSet<int>[] oldGraph, Dictionary<string, HashSet<string>> newGraph)
        {
            List<string> used = new List<string>();

            while (availableNodes.Count > 0)
            {
                var node = availableNodes.Dequeue();
                var hypoMatch = ArrayHelper.CopyArray(match);
                hypoMatch[src] = node;

                bool isConsistent = true;

                foreach (var c in oldGraph[src])
                {
                    if (!string.IsNullOrEmpty(hypoMatch[c]))
                    {
                        if (!newGraph[hypoMatch[c]].Contains(hypoMatch[src]))
                        {
                            isConsistent = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!Dfs(c, hypoMatch, new Queue<string>(used.Concat(availableNodes)), oldGraph, newGraph))
                        {
                            isConsistent = false;
                            break;
                        }
                    }
                }

                if (isConsistent)
                {
                    hypoMatch.CopyTo(match, 0);
                    return true;
                }
                else
                {
                    used.Add(node);
                }
            }

            return false;
        }
    }
}
