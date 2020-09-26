/*
In computer, given the directory hierarchy as a list of pairs, find the path which contains the most number
of characters:

Example

Given the input:
5
C: WINDOWS
FOO BAR
WINDOWS SYSTEM32
C: FOO
BAR XYZZY

The answer is C:WINDOWSSYSTEM32 since its length 19 is greater than 16 (the length of C:FOOBARXYZZY).
*/

namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System.Collections.Generic;

    public class LongestDirectoryName
    {
        public static string GetLongestDirectoryName(Dictionary<string, List<string>> directories, string root)
        {
            var queue = new Queue<(string, string)>();
            queue.Enqueue((root, root));

            string maxDirectoryName = root;

            while (queue.Count > 0)
            {
                var cNode = queue.Dequeue();

                if (cNode.Item2.Length > maxDirectoryName.Length)
                {
                    maxDirectoryName = cNode.Item2;
                }

                if (directories.ContainsKey(cNode.Item1))
                {
                    foreach (var cDirectory in directories[cNode.Item1])
                    {
                        queue.Enqueue((cDirectory, cNode.Item2 + cDirectory));
                    }
                }
            }

            return maxDirectoryName;
        }
    }
}
