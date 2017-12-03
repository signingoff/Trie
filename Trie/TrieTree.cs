using System.Collections.Generic;
using System.Linq;

namespace Trie
{
    public class TrieTree
    {
        public IList<TrieNode> Nodes { get; private set; } = new List<TrieNode>();

        public void AddNodes(string word)
        {
            if (string.IsNullOrEmpty(word)) return;
            int i = 0;
            AddNodeCore(this.Nodes, word, ref i);
        }

        private static void AddNodeCore(IList<TrieNode> nodes, string word, ref int i)
        {
            int currentIndex = i;
            TrieNode node = nodes.FirstOrDefault(n => n.Character == word[currentIndex]);
            if (node == null)
            {
                node = new TrieNode(word[i]);
                nodes.Add(node);
                if (i + 1 < word.Length)
                {
                    i = i + 1;
                    AddNodeCore(node.Nodes, word, ref i);
                }
            }
            else
            {
                i = i + 1;
                AddNodeCore(node.Nodes, word, ref i);
            }
        }

        //private static void AddNodeCore(TrieNode parentNode, string word, ref int i)
        //{
        //    int currentIndex = i;
        //    TrieNode node = parentNode.Nodes.FirstOrDefault(n => n.Character == word[currentIndex]);
        //    if (node == null)
        //    {
        //        TrieNode child = new TrieNode(word[currentIndex]);
        //        node.Nodes.Add(child);
        //        if (currentIndex + 1 < word.Length)
        //        {
        //            i = i + 1;
        //            AddNodeCore(child, word, ref i);
        //        }
        //    }
        //    else
        //    {
        //        i = i + 1;
        //        AddNodeCore(child, word, ref i);
        //    }
        //}
    }
}
