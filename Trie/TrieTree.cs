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
            int i = 0, depth = 0;
            AddNodeCore(this.Nodes, word, ref i, ref depth);
        }

        public string FindPrefix(string word)
        {
            return string.Empty;
        }

        public IList<TrieNode> GetDesendantNodes()
        {
            if (this.Nodes.Count == 0) return this.Nodes;

            IList<TrieNode> nodes = new List<TrieNode>();
            int i = 0;
            while (i < this.Nodes.Count)
            {
                TrieNode node = this.Nodes[i];
                nodes.Add(node);
                GetDesendantNodesCore(node, nodes);
                i = i + 1;
            }
            return nodes;
        }
        
        private static void AddNodeCore(IList<TrieNode> nodes, string word, ref int i, ref int depth)
        {
            int currentIndex = i;
            TrieNode node = nodes.FirstOrDefault(n => n.Character == word[currentIndex]);
            if (node == null)
            {
                node = new TrieNode(word[i]);
                node.Depth = depth;
                depth = depth + 1;
                nodes.Add(node);
                Add(node, word, ref i, ref depth);
            }
            else
            {
                depth = depth + 1;
                Add(node, word, ref i, ref depth);
            }
        }

        private static void Add(TrieNode node, string word, ref int i, ref int depth)
        {
            if (i + 1 < word.Length)
            {
                i = i + 1;
                node.IsComplete = false;
                AddNodeCore(node.Nodes, word, ref i, ref depth);
            }
            else
            {
                node.IsComplete = true;
            }
        }

        private static void GetDesendantNodesCore(TrieNode parent, IList<TrieNode> nodes)
        {
            int i = 0;
            while (i < parent.Nodes.Count)
            {
                TrieNode node = parent.Nodes[i];
                nodes.Add(node);
                GetDesendantNodesCore(node, nodes);
                i = i + 1;
            }
        }
    }
}
