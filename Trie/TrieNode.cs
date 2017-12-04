using System.Collections.Generic;
using System.Diagnostics;

namespace Trie
{
    [DebuggerDisplay("Character={Character} Depth={Depth}")]
    public class TrieNode
    {
        public char Character { get; private set; }
        public IList<TrieNode> Nodes { get; private set; } = new List<TrieNode>();
        public bool IsComplete { get; set; }
        public int Depth { get; set; }

        public TrieNode(char c)
        {
            this.Character = c;
        }          
    }
}
