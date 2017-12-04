using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Trie;

namespace TrieTest
{
    [TestClass]
    public class TrieTreeTest
    {
        [TestMethod]
        public void When_Root_Has_OneNode()
        {
            TrieTree tree = new TrieTree();
            tree.AddNodes("and");
            tree.AddNodes("ane");
            tree.AddNodes("anee");

            IList<TrieNode> nodes = tree.GetDesendantNodes();
            
            Assert.AreEqual(1, nodes.Count(x => x.Depth == 0));
            Assert.AreEqual(1, nodes.Count(x => x.Depth == 1));
            Assert.AreEqual(2, nodes.Count(x => x.Depth == 2));
            Assert.AreEqual(1, nodes.Count(x => x.Depth == 3));
        }

        [TestMethod]
        public void When_Root_Has_MoreThanOneNode()
        {
            TrieTree tree = new TrieTree();
            tree.AddNodes("and");
            tree.AddNodes("bne");
            tree.AddNodes("bnd");
            tree.AddNodes("cnee");

            IList<TrieNode> nodes = tree.GetDesendantNodes();

            Assert.AreEqual(3, nodes.Count(x => x.Depth == 0));
            Assert.AreEqual(3, nodes.Count(x => x.Depth == 1));
            Assert.AreEqual(4, nodes.Count(x => x.Depth == 2));
            Assert.AreEqual(1, nodes.Count(x => x.Depth == 3));
        }
    }
}
