using System.Diagnostics;

namespace Trie
{
    [DebuggerDisplay("Character={Character}")]
    public class TrieNode
    {
        public char Character { get; private set; }
        public TrieNode[] Nodes { get; private set; } = new TrieNode[26];
        public int Frequence { get; set; } = 0; 

        public TrieNode()
        {
        }

        public TrieNode(char c)
        {
            this.Character = c;
        }
    }
}
