using System.Collections.Generic;

namespace Trie
{
    public class TrieTree : TrieNode
    {
        public TrieTree()
        { }

        private TrieTree(char c) : base(c)
        {
        }

        public TrieNode AddNodes(string word)
        {
            if (string.IsNullOrEmpty(word)) return null;
            int i = 0;
            TrieNode node = null;
            TrieNode paretNode = this;
            while (i < word.Length)
            {
                int index = GetIndex(word[i]);
                node = paretNode.Nodes[index];
                if (node == null)
                {
                    node = new TrieNode(word[i] < 91 ? (char)(word[i] + 32) : word[i]);
                    paretNode.Nodes[index] = node;
                }
                paretNode = node;
                i = i + 1;
            }
            node.Frequence = node.Frequence + 1;
            return node;
        }

        private int GetIndex(char c)
        {
            if (c < 91)
                return c - 65;
            else
                return c - 97;
        }

        public TrieNode Search(string word)
        {
            if (string.IsNullOrEmpty(word)) return null;
            int i = 0;
            TrieNode paretNode = this;
            while (i < word.Length)
            {
                int index = GetIndex(word[i]);
                paretNode = paretNode.Nodes[index];
                i = i + 1;
            }
            return paretNode;
        }

        public IList<TrieNode> GetDesendantNodes()
        {
            IList<TrieNode> nodes = new List<TrieNode>();
            int i = 0;
            while (i < this.Nodes.Length)
            {
                TrieNode node = this.Nodes[i];
                if (node == null)
                {
                    i = i + 1;
                    continue;
                }

                nodes.Add(node);
                GetDesendantNodesCore(node, nodes);
                i = i + 1;
            }
            return nodes;
        }

        private static void GetDesendantNodesCore(TrieNode parent, IList<TrieNode> nodes)
        {
            int i = 0;
            while (i < parent.Nodes.Length)
            {
                TrieNode node = parent.Nodes[i];
                if (node == null)
                {
                    i = i + 1;
                    continue;
                }
                nodes.Add(node);
                GetDesendantNodesCore(node, nodes);
                i = i + 1;
            }
        }
    }
}
