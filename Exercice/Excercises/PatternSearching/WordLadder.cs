/// <summary>
/// Given two words (beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s)
/// from beginWord to endWord, such that:
/// Only one letter can be changed at a time
/// Each transformed word must exist in the word list.Note that beginWord is not a transformed word.
/// </summary>

//string beginWord = "hit";
//string endWord = "cog";
//var wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };

//var result = WordLadder.FindLadders(beginWord, endWord, wordList);

// Expected Output:
// [
//  ["hit", "hot", "dot", "dog", "cog"],
//  ["hit","hot","lot","log","cog"]
// ]

namespace CSharpAlgo.Excercise.Excercises.PatternSearching
{
    using System.Collections.Generic;
    using System.Linq;

    public class WordLadder
    {
        public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var list = new HashSet<string>(wordList);
            if (!list.Contains(endWord))
            {
                return new List<IList<string>>();
            }

            int cn = beginWord.Length;

            Queue<List<string>> queue = new Queue<List<string>>();

            queue.Enqueue(new List<string>() { beginWord });
            int min = int.MaxValue;
            var result = new List<IList<string>>();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic[beginWord] = 0;

            nextE:
            while (queue.Count > 0)
            {
                var path = queue.Dequeue();
                int cLevel = path.Count - 1;
                var cStr = path.Last();

                if (cLevel >= min) break;

                int nL = cLevel + 1;
                var cCs = cStr.ToCharArray();
                for (int i = 0; i < cn; i++)
                {
                    for (char j = 'a'; j <= 'z'; j++)
                    {
                        if (j != cCs[i])
                        {
                            char tc = cCs[i];
                            cCs[i] = j;
                            string nStr = new string(cCs);
                            cCs[i] = tc;

                            if (list.Contains(nStr))
                            {
                                if (nStr == endWord)
                                {
                                    min = nL;
                                    var newPath = new List<string>(path);
                                    newPath.Add(nStr);
                                    result.Add(newPath);
                                    goto nextE;
                                }
                                else
                                {
                                    if (nL == min || (dic.ContainsKey(nStr) && nL != dic[nStr]))
                                    {
                                        continue;
                                    }

                                    dic[nStr] = nL;

                                    var newPath = new List<string>(path);
                                    newPath.Add(nStr);
                                    queue.Enqueue(newPath);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
