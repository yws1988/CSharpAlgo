namespace Graph.Tree
{
    using System;

    public class PrefixTree
    {
        static readonly int ALPHABET_SIZE = 26;
        public static TreeNode root = new TreeNode();

        // trie node 
        public class TreeNode
        {
            public TreeNode[] children = new TreeNode[ALPHABET_SIZE];

            // isEndOfWord is true if the node represents 
            // end of a word 
            public bool isEndOfWord;

            public TreeNode()
            {
                isEndOfWord = false;
                for (int i = 0; i < ALPHABET_SIZE; i++)
                    children[i] = null;
            }
        };

        // If not present, inserts key into trie 
        // If the key is prefix of trie node,  
        // just marks leaf node 
        public static void Insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TreeNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TreeNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf 
            pCrawl.isEndOfWord = true;
        }

        // Returns true if key  
        // presents in trie, else false 
        public static bool Search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TreeNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }
  }
}
