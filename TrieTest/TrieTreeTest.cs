using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trie;

namespace TrieTest
{
    [TestClass]
    public class TrieTreeTest
    {
        [TestMethod]
        public void AddNodes()
        {
            TrieTree tree = new TrieTree();
            tree.AddNodes("and");
            tree.AddNodes("ane");

        }
    }
}
