using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Trie
{
    [DebuggerDisplay("{Character}")]
    public class TrieNode
    {
        public char Character { get; private set; }
        public IList<TrieNode> Nodes { get; private set; } = new List<TrieNode>();
        public bool IsComplete { get; set; }

        public TrieNode(char c)
        {
            this.Character = c;
        }

        public void AddNodes(string word)
        {
            if (string.IsNullOrEmpty(word)) return;
            int i = 0;
            AddNodeCore(this, word, ref i);
        }

        private static void AddNodeCore(TrieNode parentNode, string word, ref int i)
        {
            int currentIndex = i;
            TrieNode node = parentNode.Nodes.FirstOrDefault(n => n.Character == word[currentIndex]);
            if (node == null)
            {
                TrieNode child = new TrieNode(word[currentIndex]);
                node.Nodes.Add(child);
                if (currentIndex + 1 < word.Length)
                {
                    i = i + 1;
                    AddNodeCore(child, word, ref i);
                }
            }
            else
            {
                i = i + 1;
            }
        }
    }
}
